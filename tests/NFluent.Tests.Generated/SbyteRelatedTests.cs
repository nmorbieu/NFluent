﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="SbyteRelatedTests.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent.Tests
{
    using NUnit.Framework;
    using Helpers;
    using System;
    using NFluent.Helpers;


    [TestFixture]
    public class SbyteRelatedTests
    {
        #pragma warning disable 169

        //// ---------------------- WARNING ----------------------
        //// AUTO-GENERATED FILE WHICH SHOULD NOT BE MODIFIED!
        //// To change this class, change the one that is used
        //// as the golden source/model for this autogeneration
        //// (i.e. the one dedicated to the integer values).
        //// -----------------------------------------------------

        // Since this class is the model/template for the generation of the tests on all the other numbers types, don't forget to re-generate all the other classes every time you change this one. To do that, just save the .\T4" + Environment.NewLine + "umberTestsGenerator.tt file within Visual Studio 2012. This will trigger the T4 code generation process.
        private const sbyte Twenty = 20;
        private const sbyte Two = 2;
        private const sbyte Zero = 0;
        private const sbyte One = 1;
        private CultureSession cultureSession;

        [OneTimeSetUp]
        public void ForceCulture()
        {
            this.cultureSession = new CultureSession("fr-FR");
        }

        [OneTimeTearDown]
        public void RestoreCulture()
        {
            this.cultureSession.Dispose();
        }


        #region IsNotZero

        [Test]
        public void IsNotZeroWorks()
        {
            Check.That(Two).IsNotZero();
        }

        [Test]
        public void IsNotZeroThrowsExceptionWhenFails()
        {
            Check.ThatCode(() =>
            {
                Check.That(Zero).IsNotZero();
            }).
            IsAFaillingCheckWithMessage("",
                    "The checked value is equal to zero whereas it must not.",
                    "The checked value:",
                    "\t[0]");
        }

        #endregion

        #region NotIsZero

        [Test]
        public void NotIsZeroWorks()
        {
            Check.That(Two).Not.IsZero();
        }

        [Test]
        public void NotIsZeroThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Zero).Not.IsZero();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is equal to zero whereas it must not.",
                    "The checked value:",
                    "\t[0]");
        }

        #endregion

        #region NotIsNotZero

        [Test]
        public void NotIsNotZeroWorks()
        {
            Check.That(Zero).Not.IsNotZero();
        }

        [Test]
        public void NotIsNotZeroThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Two).Not.IsNotZero();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is different from zero.",
                    "The checked value:",
                    "\t[2]");
        }

        #endregion

        #region IComparable checks

        [Test]
        public void IsBeforeWorks()
        {
            Check.That(Two).IsBefore(Twenty);
        }

        [Test]
        public void NotIsBeforeWorks()
        {
            Check.That(Twenty).Not.IsBefore(Two);
        }

        [Test]
        public void IsBeforeThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).IsBefore(Two);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is not before the reference value.",
                    "The checked value:",
                    "\t[20]",
                    "The expected value: before",
                    "\t[2]");
        }

        [Test]
        public void IsBeforeThrowsExceptionWhenGivingTheSameValue()
        {
            Check.ThatCode(() =>
            {
                Check.That(Two).IsBefore(Two);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is not before the reference value.",
                    "The checked value:",
                    "\t[2]",
                    "The expected value: before",
                    "\t[2]");
        }

        [Test]
        public void NotIsBeforeThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Two).Not.IsBefore(Twenty);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is before the reference value whereas it must not.",
                    "The checked value:",
                    "\t[2]",
                    "The expected value: after",
                    "\t[20]");
        }

        [Test]
        public void IsAfterWorks()
        {
            Check.That(Twenty).IsAfter(Two);
        }

        [Test]
        public void NotIsAfterWorks()
        {
            Check.That(Two).Not.IsAfter(Twenty);
        }

        [Test]
        public void IsAfterThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Two).IsAfter(Two);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is not after the reference value.",
                    "The checked value:",
                    "\t[2]",
                    "The expected value: after",
                    "\t[2]");
        }

        [Test]
        public void NotIsAfterThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).Not.IsAfter(Two);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is after the reference value whereas it must not.",
                    "The checked value:",
                    "\t[20]",
                    "The expected value: before",
                    "\t[2]");
        }

        #endregion

        #region IsLessThan
#pragma warning disable 618

        [Test]
        public void IsLessThanWorks()
        {
            Check.That(One).IsLessThan(Twenty);
        }

        [Test]
        public void NotIsLessThanWorks()
        {
            Check.That(Twenty).Not.IsLessThan(One);
        }

        [Test]
        public void NotIsLessThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).Not.IsLessThan(Twenty);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is less than the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: strictly greater than",
                    "\t[20]");
        }

#pragma warning restore 618
        #endregion

        #region IsStrictlyLessThan

        [Test]
        public void IsStrictlyLessThanWorks()
        {
            Check.That(One).IsStrictlyLessThan(Twenty);
        }

        [Test]
        public void NotIsStrictlyLessThanWorks()
        {
            Check.That(Twenty).Not.IsStrictlyLessThan(One);
        }

        [Test]
        public void IsStrictlyLessThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).IsStrictlyLessThan(One);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is equal to the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: strictly less than",
                    "\t[1]");
            Check.ThatCode(() =>
            {
                Check.That(One).IsStrictlyLessThan(Zero);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is greater than the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: strictly less than",
                    "\t[0]");
        }

        [Test]
        public void NotIsStrictlyLessThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).Not.IsStrictlyLessThan(Twenty);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is strictly less than the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: greater than",
                    "\t[20]");
        }

        #endregion



        #region IsGreaterThan
#pragma warning disable 618

        [Test]
        public void IsGreaterThanWorks()
        {
            Check.That(Twenty).IsGreaterThan(One);
        }

        [Test]
        public void IsGreaterThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).IsGreaterThan(Twenty);
            })
                .IsAFaillingCheckWithMessage("",
                    "The checked value is strictly less than the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: greater than",
                    "\t[20]");

        }

        [Test]
        public void NotIsGreaterThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).Not.IsGreaterThan(One);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is greater than the given one.",
                    "The checked value:",
                    "\t[20]",
                    "The expected value: strictly less than",
                    "\t[1]");
        }

#pragma warning restore 618
        #endregion

        #region IsStrictlyGreaterThan

        [Test]
        public void IsStrictlyGreaterThanWorks()
        {
            Check.That(Twenty).IsStrictlyGreaterThan(One);
        }

        [Test]
        public void IsStrictlyGreaterThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).IsStrictlyGreaterThan(One);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is equal to the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value: strictly greater than",
                    "\t[1]");
        }

        [Test]
        public void NotIsStrictlyGreaterThanThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).Not.IsStrictlyGreaterThan(One);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is greater than the given one.",
                    "The checked value:",
                    "\t[20]",
                    "The expected value: less than or equal to",
                    "\t[1]");
        }

        #endregion

        [Test]
        public void AndOperatorCanChainMultipleAssertionOnNumber()
        {
            Check.That(Twenty).IsNotZero().And.IsAfter(Zero);
            Check.That(Twenty).IsAfter(Zero).And.IsNotZero();
        }

        #region Equals / IsEqualTo / IsNotEqualTo

        [Test]
        public void IsEqualToWorksWithOtherSameValue()
        {
            const sbyte otherTwenty = 20;

            Check.That(Twenty).IsEqualTo(otherTwenty);
        }

        [Test]
        public void IsEqualFailWhenRelevant()
        {
            Check.ThatCode(() => { Check.That(Twenty).IsEqualTo(0); })
                .IsAFaillingCheckWithMessage("",
            "The checked value is different from the expected one.",
                "The checked value:",
                "\t[20]",
            "The expected value:",
                "\t[0]");
        }

        [Test]
        public void EqualsWorksToo()
        {
            const sbyte otherTwenty = 20;

            Check.That(Twenty).Equals(otherTwenty);

            // check the 'other implementation of equals
            Check.That(Twenty).IsAfter(Zero).And.Equals(otherTwenty);
        }

        [Test]
        public void NotIsEqualToWorks()
        {
            Check.That(One).Not.IsEqualTo(Twenty);
        }

        [Test]
        public void NotIsEqualToThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).Not.IsEqualTo(Twenty);
            })
           .IsAFaillingCheckWithMessage("",
                    "The checked value is equal to the given one whereas it must not.",
                    "The expected value: different from",
                    "\t[20] of type: [sbyte]");
        }

        [Test]
        public void NotEqualsThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).Not.Equals(Twenty);
            })
            .IsAFaillingCheckWithMessage(Environment.NewLine+ "The checked value is equal to the given one whereas it must not." + Environment.NewLine + "The expected value: different from" + Environment.NewLine + "\t[20] of type: [sbyte]");
        }

        [Test]
        public void IsNotEqualToWorks()
        {
            Check.That(One).IsNotEqualTo(Twenty);
        }

        [Test]
        public void IsNotEqualToThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(Twenty).IsNotEqualTo(Twenty);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is equal to the expected one whereas it must not.",
                    "The expected value: different from",
                    "\t[20] of type: [sbyte]");
        }

        [Test]
        public void NotIsNotEqualToThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That(One).Not.IsNotEqualTo(Twenty);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is different from the given one.",
                    "The checked value:",
                    "\t[1]",
                    "The expected value:",
                    "\t[20]");
        }

        #endregion

        #region Nullables

        #region HasAValue

        [Test]
        public void HasValueWorks()
        {
            sbyte? one = 1;

            Check.That(one).HasAValue();
        }

        [Test]
        public void HasValueThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).HasAValue();
            }).IsAFaillingCheckWithMessage("","The checked nullable has no value, which is unexpected.");
        }

        [Test]
        public void NotHasValueWorks()
        {
            Check.That((sbyte?) null).Not.HasAValue();
        }

        [Test]
        public void NotHasValueThrowsExceptionWhenFailing()
        {
            sbyte? one = 1;

            Check.ThatCode(() =>
            {
                Check.That(one).Not.HasAValue();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked nullable has a value, whereas it must not.",
                    "The checked nullable:",
                    "\t[1]");
        }

        [Test]
        public void HasValueSupportsToBeChainedWithTheWhichOperator()
        {
            sbyte? one = 1;

            Check.That(one).HasAValue().Which.IsAfter(Zero).And.IsEqualTo(1);
        }

        [Test]
        public void TryingToChainANullableWithoutAValueIsPossibleButThrowsAnException()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).Not.HasAValue().Which.IsAfter(Zero);
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked nullable has no value to be checked.");
        }

        #endregion

        #region HasNoValue
        
        [Test]
        public void HasNoValueWorks()
        {
            Check.That((sbyte?) null).HasNoValue();
        }

        [Test]
        public void HasNoValueThrowsExceptionWhenFailing()
        {
            sbyte? one = 1;

            Check.ThatCode(() =>
            {
                Check.That(one).HasNoValue();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked nullable has a value, whereas it must not.",
                    "The checked nullable:", 
                    "\t[1]");
        }

        [Test]
        public void NotHasNoValueWorks()
        {
            sbyte? one = 1;

            Check.That(one).Not.HasNoValue();
        }

        [Test]
        public void NotHasNoValueThrowsExceptionWhenFailing()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).Not.HasNoValue();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked nullable has no value, which is unexpected.");
        }

        #endregion

        #region IsInstanceOf (which is linkable)

        [Test]
        public void IsInstanceOfWorksWithNullable()
        {
            sbyte? one = 1;

            Check.That(one).IsInstanceOf<sbyte?>().And.HasAValue().Which.IsEqualTo(1);
        }

        [Test]
        public void IsInstanceOfWithNullableIsLinkable()
        {
            sbyte? one = 1;

            Check.That(one).IsInstanceOf<sbyte?>().And.HasAValue().Which.IsEqualTo(1);
            Check.That(one).HasAValue().And.IsInstanceOf<sbyte?>();
        }

        [Test]
        public void NotIsInstanceOfWorksWithNullable()
        {
            sbyte? one = 1;

            Check.ThatCode(() =>
            {
                Check.That(one).Not.IsInstanceOf<sbyte?>();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is an instance of [sbyte?] whereas it must not.",
                    "The checked value:",
                    "\t[1] of type: [sbyte?]",
                    "The expected value: different from",
                    "\tan instance of type: [sbyte?]");
        }

        [Test]
        public void IsInstanceOfWorksIfValueIsNullButOfSameNullableType()
        {
            Check.That((sbyte?) null).IsInstanceOf<sbyte?>();
        }

        [Test]
        public void NotIsInstanceOfThrowsIfValueIsNullButOfSameNullableType()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).Not.IsInstanceOf<sbyte?>();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is an instance of [sbyte?] whereas it must not.",
                    "The checked value:",
                    "\t[null] of type: [sbyte?]",
                    "The expected value: different from",
                    "\tan instance of type: [sbyte?]");
        }

        [Test]
        public void IsInstanceOfThowsExceptionWhenFailingWithNullable()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).IsInstanceOf<string>();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is not an instance of [string].",
                    "The checked value:",
                    "\t[null] of type: [sbyte?]",
                    "The expected value:",
                    "\tan instance of type: [string]");
        }

        #endregion

        #region IsNotInstance

        [Test]
        public void IsNotInstanceOfWorksWithNullable()
        {
            sbyte? one = 1;

            Check.That(one).IsNotInstanceOf<sbyte>().And.HasAValue().Which.IsEqualTo(1);
        }

        [Test]
        public void IsNotInstanceOfThrowsWithValueIsOfSameNullableType()
        {
            sbyte? one = 1;

            Check.ThatCode(() =>
            {
                Check.That(one).IsNotInstanceOf<sbyte?>();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is an instance of [sbyte?] whereas it must not.",
                    "The checked value:",
                    "\t[1] of type: [sbyte?]",
                    "The expected value: different from",
                    "\tan instance of type: [sbyte?]");
        }

        [Test]
        public void IsNotInstanceOfThrowsIfValueIsNullButOfSameNullableType()
        {
            Check.ThatCode(() =>
            {
                Check.That((sbyte?) null).IsNotInstanceOf<sbyte?>();
            })
            .IsAFaillingCheckWithMessage("",
                    "The checked value is an instance of [sbyte?] whereas it must not.",
                    "The checked value:",
                    "\t[null] of type: [sbyte?]",
                    "The expected value: different from",
                    "\tan instance of type: [sbyte?]");
        }

        #endregion

        #endregion
    }
}
