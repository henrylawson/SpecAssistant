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
    public class MinAgeSpecificationTest
    {
        private Specification<Person> _minAgeSpecification;

        [SetUp]
        public void SetUp()
        {
            _minAgeSpecification = new MinAgeSpecification(18);
        }

        [Test]
        public void ShouldBeSatisfiedIfPersonOver18()
        {
            var date19YearsAgo = DateTime.Now.AddYears(-19);
            var over18Person = new Person(date19YearsAgo, 1);
            Assert.True(_minAgeSpecification.IsSatisfiedBy(over18Person));
        }

        [Test]
        public void ShouldBeSatisfiedIsPersonIs18()
        {
            var date18YearsAgo = DateTime.Now.AddYears(-18);
            var over18Person = new Person(date18YearsAgo, 1);
            Assert.True(_minAgeSpecification.IsSatisfiedBy(over18Person));
        }

        [Test]
        public void ShouldNotBeSatisfiedIfPersonIsUnder18()
        {
            var date5YearsAgo = DateTime.Now.AddYears(-5);
            var under18Person = new Person(date5YearsAgo, 1);
            Assert.False(_minAgeSpecification.IsSatisfiedBy(under18Person));
        }
    }
}
