namespace Propformat.Test
{
    using System;
    using System.Globalization;

    using NUnit.Framework;

    [TestFixture]
    public class PorpertyFormatterTest
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
            var formattedString = "Hello {0}!".FormatUsingProperties<Person>(defaultPerson, x => x.Name);

            Assert.That(formattedString, Is.EqualTo("Hello Henry!"));
        }

        [Test]
        public void ShouldFormatMultiplePropertiesIntoAString()
        {
            var formattedString = "Hello {0}, You are {1} this year!".FormatUsingProperties(
                defaultPerson, 
                x => x.Name, 
                x => x.Age.ToString(CultureInfo.InvariantCulture));

            Assert.That(formattedString, Is.EqualTo("Hello Henry, You are 23 this year!"));
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ShouldThrowAnErrorWhenThereIsACountMismatch()
        {
            "{0} {1} {2}".FormatUsingProperties(defaultPerson, x => x.Name);
        }

        [Test]
        public void ShouldFormatMyHtmlStringWithProperties()
        {
            const string HtmlString = "<div class=\"name\">{0}</div><div class=\"age\">{1}</div>";
            
            var formattedHtml = HtmlString.FormatUsingProperties(
                defaultPerson,
                x => x.Name, 
                x => x.Age.ToString(CultureInfo.InvariantCulture));

            Assert.That(formattedHtml, Is.EqualTo("<div class=\"name\">Henry</div><div class=\"age\">23</div>"));
        }
    }
}
