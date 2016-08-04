using System;
using System.Linq;
using System.Linq.Expressions;

namespace Patterns.Specification.Interfaces
{
    public interface IWhereSpecification<T> : ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
        IQueryable<T> SatisfiesMany(IQueryable<T> queryable);
    }
}
