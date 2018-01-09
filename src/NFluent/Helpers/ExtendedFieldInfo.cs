﻿#region File header

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedFileInfo.cs" company="">
//   Copyright 2014 Cyrille DUPUYDAUBY, Thomas PIERRAIN
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

#endregion

namespace NFluent.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Extensions;
    using static System.String;

    internal class ExtendedFieldInfo
    {
        private readonly string nameInSource;
        private readonly string prefix;

        public ExtendedFieldInfo(string prefix, Type type, string infoName)
        {
            this.prefix = prefix;
            this.ValueType = type;
            if (EvaluateCriteria(AutoPropertyMask, infoName, out this.nameInSource))
            {
                this.FieldLabel = $"autoproperty '{this.LongFieldName}' (field '{infoName}')";
            }
            else if (EvaluateCriteria(AnonymousTypeFieldMask, infoName, out this.nameInSource))
            {
                this.FieldLabel = $"field '{this.LongFieldName}'";
            }
            else
            {
                this.nameInSource = infoName;
                this.FieldLabel = $"field '{this.LongFieldName}'";
            }
        }

        public string LongFieldName => IsNullOrEmpty(this.prefix)
            ? this.nameInSource
            : $"{this.prefix}.{this.nameInSource}";

        public string FieldLabel { get; private set; }

        public string NameInSource => this.nameInSource;

        public object Value { get; private set; }

        public Type ValueType { get; private set; }

        public bool IsArray => this.ValueType.IsArray;

        public void SetFieldValue(object obj)
        {
            this.Value = obj;
        }

        public bool ChecksIfImplementsEqual()
        {
            return this.ValueType.ImplementsEquals();
        }

        internal List<FieldMatch> CompareValue(
            ExtendedFieldInfo actualFieldDescription,
            IList<object> scanned,
            int depth, BindingFlags flags)
        {
            var result = new List<FieldMatch>();
            if (this.Value != null && scanned.Contains(this.Value))
            {
                return result;
            }

            if (depth <= 0 && this.ChecksIfImplementsEqual())
            {
                result.Add(new FieldMatch(this, actualFieldDescription));
            }
            else
            {
                scanned.Add(this.Value);
                if (this.Value == null || actualFieldDescription.Value == null)
                {
                    result.Add(new FieldMatch(this, actualFieldDescription));
                }
                else if (this.IsArray)
                {
                    var array = (Array) this.Value;
                    var actualArray = (Array) actualFieldDescription.Value;
                    if (actualArray.Length != array.Length)
                    {
                        result.Add(new FieldMatch(this, actualFieldDescription));
                    }
                    else
                    {
                        result.AddRange(
                            this.ScanFields(
                                actualFieldDescription,
                                scanned,
                                depth - 1, flags));
                    }
                }
                else
                {
                    result.AddRange(
                        this.ScanFields(
                            actualFieldDescription,
                            scanned,
                            depth - 1, flags));
                }
            }

            return result;
        }

        private IEnumerable<FieldMatch> ScanFields(ExtendedFieldInfo actual, IList<object> scanned, int depth, BindingFlags flags)
        {
            var result = new List<FieldMatch>();

            foreach (var fieldInfo in this.GetSubExtendedFieldInfosFields(flags))
            {
                var actualFieldMatching = actual.FindField(fieldInfo, flags);

                // field not found in SUT
                if (actualFieldMatching == null)
                {
                    result.Add(new FieldMatch(fieldInfo, null));
                    continue;
                }

                result.AddRange(fieldInfo.CompareValue(actualFieldMatching, scanned, depth - 1, flags));
            }

            return result;
        }

        private IEnumerable<ExtendedFieldInfo> GetSubExtendedFieldInfosFields(BindingFlags flags)
        {
            var result = new List<ExtendedFieldInfo>();
            if (this.IsArray)
            {
                var array = (Array) this.Value;
                var fieldType = array.GetType().GetElementType();
                for (var i = 0; i < array.Length; i++)
                {
                    var prefixWithIndex = $"[{i}]";
                    var expectedEntryDescription = new ExtendedFieldInfo(
                        this.LongFieldName,
                        fieldType,
                        prefixWithIndex);
                    expectedEntryDescription.SetFieldValue(array.GetValue(i));
                    result.Add(expectedEntryDescription);
                }
            }
            else
            {
                var currentType = this.ValueType;
                while (currentType != null)
                {
                    var fieldsInfo = currentType.GetFields(flags);
                    currentType = currentType.GetBaseType();
                    foreach (var info in fieldsInfo)
                    {
                        var expectedValue = info.GetValue(this.Value);
                        var extended = new ExtendedFieldInfo(this.LongFieldName,
                            expectedValue?.GetType() ?? info.FieldType,
                            info.Name);
                        extended.SetFieldValue(expectedValue);
                        result.Add(extended);
                    }
                }
            }
            return result;
        }

        private ExtendedFieldInfo FindField(ExtendedFieldInfo other, BindingFlags flags)
        {
            var fields = this.GetSubExtendedFieldInfosFields(flags);
            foreach (var info in fields)
            {
                if (other.nameInSource == info.nameInSource)
                {
                    return info;
                }
            }

            return null;
        }

        /// <summary>
        ///     The anonymous type field mask.
        /// </summary>
        private static readonly Regex AnonymousTypeFieldMask;

        /// <summary>
        ///     The auto property mask.
        /// </summary>
        private static readonly Regex AutoPropertyMask;

        /// <summary>
        ///     Initializes static members of the <see cref="ObjectFieldsCheckExtensions" /> class.
        /// </summary>
        static ExtendedFieldInfo()
        {
            AutoPropertyMask = new Regex("^<(.*)>k_");
            AnonymousTypeFieldMask = new Regex("^<(.*)>(i_|\\z)");
        }

        internal static string ExtractFieldNameAsInSourceCode(string name)
        {
            if (EvaluateCriteria(AutoPropertyMask, name, out var result))
            {
                return result;
            }

            if (EvaluateCriteria(AnonymousTypeFieldMask, name, out result))
            {
                return result;
            }

            result = name;
            return result;
        }

        private static bool EvaluateCriteria(Regex expression, string name, out string actualFieldName)
        {
            var regTest = expression.Match(name);
            if (regTest.Groups.Count >= 2)
            {
                actualFieldName = name.Substring(regTest.Groups[1].Index, regTest.Groups[1].Length);
                return true;
            }

            actualFieldName = Empty;
            return false;
        }
    }
}