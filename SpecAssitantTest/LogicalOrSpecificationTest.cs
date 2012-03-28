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
    public class LogicalOrSpecificationTest
    {
        private Specification<Person> _minAgeOrHeightSpecification;

        [SetUp]
        public void SetUp()
        {
            var minAgeSpec = new MinAgeSpecification(18);
            var minHeightSpec = new MinHeightSpecification(170);
            _minAgeOrHeightSpecification = minAgeSpec.Or(minHeightSpec);
        }

        [Test]
        public void ShouldNotBeSatisfiedIfHeightNotOkAndAgeNotOk()
        {
            var person = new Person(DateTime.Now, 169);
            Assert.False(_minAgeOrHeightSpecification.IsSatisfiedBy(person));
        }

        [Test]
        public void ShouldBeSatisfiedIfHeightOkAndAgeNotOk()
        {
            var person = new Person(DateTime.Now, 171);
            Assert.True(_minAgeOrHeightSpecification.IsSatisfiedBy(person));
        }

        [Test]
        public void ShouldBeSatisfiedIfHeightNotOkAndAgeOk()
        {
            var person = new Person(DateTime.Now.AddYears(-19), 171);
            Assert.True(_minAgeOrHeightSpecification.IsSatisfiedBy(person));
        }
    }
}
