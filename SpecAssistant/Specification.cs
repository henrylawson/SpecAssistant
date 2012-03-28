using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecAssistant
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfiedBy(T value);

        public Specification<T> And(Specification<T> otherSpecification)
        {
            return new LogicalAnd(this, otherSpecification);
        }

        public Specification<T> Or(Specification<T> otherSpecification)
        {
            return new LogicalOr(this, otherSpecification);
        }


        public Specification<T> Not()
        {
            return new LogicalNot(this);
        }

        private class LogicalNot : Specification<T>
        {
            private Specification<T> _spec;

            public LogicalNot(Specification<T> spec)
            {
                _spec = spec;
            }

            public override bool IsSatisfiedBy(T value)
            {
                return !_spec.IsSatisfiedBy(value);
            }
        }

        private abstract class TwoSpecificationLogicalOperation : Specification<T>
        {
            protected readonly Specification<T> Specification;
            protected readonly Specification<T> OtherSpecification;

            protected TwoSpecificationLogicalOperation(Specification<T> specification, Specification<T> otherSpecification)
            {
                Specification = specification;
                OtherSpecification = otherSpecification;
            }
        }

        private class LogicalAnd : TwoSpecificationLogicalOperation
        {
            public LogicalAnd(Specification<T> specification, Specification<T> otherSpecification) : base(specification, otherSpecification)
            {
                //empty
            }

            public override bool IsSatisfiedBy(T value)
            {
                return Specification.IsSatisfiedBy(value) && OtherSpecification.IsSatisfiedBy(value);
            }
        }

        private class LogicalOr : TwoSpecificationLogicalOperation
        {
            public LogicalOr(Specification<T> specification, Specification<T> otherSpecification) : base(specification, otherSpecification)
            {
                //empty
            }

            public override bool IsSatisfiedBy(T value)
            {
                return Specification.IsSatisfiedBy(value) || OtherSpecification.IsSatisfiedBy(value);
            }
        }
    }
}
