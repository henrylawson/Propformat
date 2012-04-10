namespace Propformat.Test
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    public class PropertyFormatterTest
    {
        private Person defaultPerson;

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [SetUp]
        public void Init()
        {
            defaultPerson = new Person { Name = "Henry", Age = 23 };
        }

        [Test]
        public void ShouldFormatOnePropertyIntoAString()
        {
            var formatter = new PropertyFormatter<Person>("Hello {0}!", x => x.Name);

            var formattedString = formatter.Format(defaultPerson);

            Assert.That(formattedString, Is.EqualTo("Hello Henry!"));
        }

        [Test]
        public void ShouldFormatMultiplePropertiesIntoAString()
        {
            var formatter = new PropertyFormatter<Person>("Hello {0}, You are {1} this year!",
                x => x.Name,
                x => x.Age.ToString(CultureInfo.InvariantCulture));

            var formattedString = formatter.Format(defaultPerson);

            Assert.That(formattedString, Is.EqualTo("Hello Henry, You are 23 this year!"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrowAnErrorWhenThereIsACountMismatch()
        {
            var formatter = new PropertyFormatter<Person>("{0} {1} {2}", x => x.Name);

            formatter.Format(defaultPerson);
        }

        [Test]
        public void ShouldFormatMyHtmlStringWithProperties()
        {
            var htmlFormatter = new PropertyFormatter<Person>("<div class=\"name\">{0}</div><div class=\"age\">{1}</div>",
                x => x.Name, 
                x => x.Age.ToString(CultureInfo.InvariantCulture));
            
            var formattedHtml = htmlFormatter.Format(defaultPerson);

            Assert.That(formattedHtml, Is.EqualTo("<div class=\"name\">Henry</div><div class=\"age\">23</div>"));
        }
    }
}
