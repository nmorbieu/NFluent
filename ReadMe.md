NFluent overview
==============
*author:* thomas@pierrain.net
*date:* February 6th 2013

NFluent provides some method extensions for Easy Software Testing in .NET. NFluent is __highly inspired by the awesome Java FEST Fluent__ assertion/reflection library (http://fest.easytesting.org/)

- - -

Usage sample
------------

With NFluent, you can write some assertions like this:
	
	var integers = new int[] { 1, 2, 3, 4, 5, 666 };
    Assert.That(integers.ContainsExactly(1, 2, 3, 4, 5, 666));

	var guitarHeroes = new[] { "Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell" };
    Assert.That(guitarHeroes.ContainsExactly("Hendrix", "Paco de Lucia", "Django Reinhardt", "Baden Powell"));

(note: the Assert.That is part of the NUnit library)

- - - 

with NFluent, you can also write something like this:

	 var enumerable = new List<Person>
                                 {
                                     new Person { Name = "Thomas", Age = 38 },
                                     new Person { Name = "Achille", Age = 10, Nationality = Nationality.French },
                                     new Person { Name = "Anton", Age = 7, Nationality = Nationality.French },
                                     new Person { Name = "Arjun", Age = 7, Nationality = Nationality.Indian }
                                 };

     Assert.That(enumerable.Properties("Name").ContainsExactly("Thomas", "Achille", "Anton", "Arjun"));
     Assert.That(enumerable.Properties("Age").ContainsExactly(38, 10, 7, 7));
     Assert.That(enumerable.Properties("Nationality").ContainsExactly(Nationality.Unknown, Nationality.French, Nationality.French, Nationality.Indian));

- - -
