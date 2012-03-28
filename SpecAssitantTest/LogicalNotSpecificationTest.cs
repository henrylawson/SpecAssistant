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
    public class LogicalNotSpecificationTest
    {
        private Specification<Person> _minHeightSpecification;  

        [SetUp]
        public void SetUp()
        {
            _minHeightSpecification = new MinHeightSpecification(170);
        }

        [Test]
        public void ShouldBeFalseWhenSatisfied()
        {
            var person = new Person(DateTime.Now, 171);
            Assert.True(_minHeightSpecification.IsSatisfiedBy(person));
            Assert.False(_minHeightSpecification.Not().IsSatisfiedBy(person));
        }

        [Test]
        public void ShouldBeTrueWhenNotSatisfied()
        {
            var person = new Person(DateTime.Now, 169);
            Assert.False(_minHeightSpecification.IsSatisfiedBy(person));
            Assert.True(_minHeightSpecification.Not().IsSatisfiedBy(person));
        }
    }
}
