using SpecAssistant;

namespace SpecAssistantExample
{
    public class MinAgeSpecification : Specification<Person>
    {
        private readonly int _minAge;

        public MinAgeSpecification(int minAge)
        {
            _minAge = minAge;
        }

        public override bool IsSatisfiedBy(Person person)
        {
            return person.Age >= _minAge;
        }
    }
}
