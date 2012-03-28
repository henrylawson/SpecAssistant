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
    public class LogicalAndSpecificationTest
    {
        private Specification<Person> _minAgeAndHeightSpecification;

        [SetUp]
        public void SetUp()
        {
            var minAgeSpec = new MinAgeSpecification(18);
            var minHeightSpec = new MinHeightSpecification(170);
            _minAgeAndHeightSpecification = minAgeSpec.And(minHeightSpec);
        }

        [Test]
        public void ShouldNotBeSatisfiedIfHeightOkAndAgeNotOk()
        {
            var person = new Person(DateTime.Now, 171);
            Assert.False(_minAgeAndHeightSpecification.IsSatisfiedBy(person));
        }

        [Test]
        public void ShouldNotBeSatisfiedIfHeightNotOkAndAgeOk()
        {
            var person = new Person(DateTime.Now.AddYears(-19), 169);
            Assert.False(_minAgeAndHeightSpecification.IsSatisfiedBy(person));
        }

        [Test]
        public void ShouldBeSatisfiedIfHeightOkAndAgeOk()
        {
            var person = new Person(DateTime.Now.AddYears(-19), 171);
            Assert.True(_minAgeAndHeightSpecification.IsSatisfiedBy(person));
        }
    }
}
