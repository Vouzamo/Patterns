using System.Linq;

namespace Patterns.Specification.Interfaces
{
    public interface IOrderBySpecification<T>
    {
        IOrderedQueryable<T> SatisfiesMany(IQueryable<T> queryable);
    }
}
