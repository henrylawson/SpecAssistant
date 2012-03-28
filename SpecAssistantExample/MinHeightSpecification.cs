using SpecAssistant;

namespace SpecAssistantExample
{
    public class MinHeightSpecification : Specification<Person>
    {
        private readonly int _height;

        public MinHeightSpecification(int height)
        {
            _height = height;
        }

        public override bool IsSatisfiedBy(Person person)
        {
            return person.Height >= _height;
        }
    }
}
