using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SpecAssistant;
using SpecAssistantExample;

namespace SpecAssitantTest
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void ShouldHaveCorrectAgeForBirthDateBorn1990()
        {
            var birthDate = new DateTime(1990, 1, 1);
            var person = new Person(birthDate, 1);
            Assert.AreEqual(AgeToday(birthDate), person.Age);
        }

        [Test]
        public void ShouldHaveCorrectAgeForBirthDateBorn2000()
        {
            var birthDate = new DateTime(2000, 1, 1);
            var person = new Person(birthDate, 1);
            Assert.AreEqual(AgeToday(birthDate), person.Age);
        }

        [Test]
        public void ShouldHaveAgeZeroIfBornNow()
        {
            var person = new Person(DateTime.Now, 1);
            Assert.AreEqual(0, person.Age);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException), 
            ExpectedMessage = "Specified argument was out of the range of valid values.\r\nParameter name: birthDate")]
        public void ShouldNotBeAbleToMakeWithBirthDateGreaterThenNow()
        {
            new Person(DateTime.Now.AddDays(1), 1);
        }

        [Test]
        public void ShouldHaveCorrectHeight()
        {
            var person = new Person(DateTime.Now, 30);
            Assert.AreEqual(30, person.Height);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException), 
            ExpectedMessage = "Specified argument was out of the range of valid values.\r\nParameter name: height")]
        public void ShouldHaveAHeightGreaterThenZero()
        {
            new Person(DateTime.Now, 0);
        }

        private static int AgeToday(DateTime birthDate)
        {
            var ageToday = DateTime.Now.Year - birthDate.Year;
            return ageToday;
        }
    }
}
