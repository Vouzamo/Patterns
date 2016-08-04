namespace Patterns.Specification.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T subject);
    }
}
