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
    public class MinHeightSpecificationTest
    {
        private Specification<Person> _minHeightSpecification;

        [SetUp]
        public void SetUp()
        {
            _minHeightSpecification = new MinHeightSpecification(170);
        }

        [Test]
        public void ShouldBeSatisfiedIfPersonHeightOver170()
        {
            var personOver170 = new Person(DateTime.Now, 171);
            Assert.True(_minHeightSpecification.IsSatisfiedBy(personOver170));
        }

        [Test]
        public void ShouldBeSatisfiedIfPersonHeightEqual170()
        {
            var personOver170 = new Person(DateTime.Now, 170);
            Assert.True(_minHeightSpecification.IsSatisfiedBy(personOver170));
        }

        [Test]
        public void ShouldNotBeSatisfiedIfPersonHeightUnder170()
        {
            var personOver170 = new Person(DateTime.Now, 169);
            Assert.False(_minHeightSpecification.IsSatisfiedBy(personOver170));
        }
    }
}
