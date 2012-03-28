using System;

namespace SpecAssistantExample
{
    public class Person
    {
        private readonly int _age;
        private readonly int _height;

        public Person(DateTime birthDate, int height)
        {
            if (birthDate > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("birthDate");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }
            _height = height;
            _age = DateTime.Now.Year - birthDate.Year;
        }

        public int Age
        {
            get { return _age; }
        }

        public int Height
        {
            get { return _height; }
        }
    }
}
