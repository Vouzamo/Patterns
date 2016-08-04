using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public class AndSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> Left { get; protected set; }
        public ISpecification<T> Right { get; protected set; }

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        public bool IsSatisfiedBy(T subject)
        {
            return Left.IsSatisfiedBy(subject) && Right.IsSatisfiedBy(subject);
        }
    }
}
