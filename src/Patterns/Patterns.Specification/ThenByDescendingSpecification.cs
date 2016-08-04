using System;
using System.Linq;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public class ThenByDescendingSpecification<T, TKey> : IThenBySpecification<T> where TKey : IComparable<TKey>
    {
        public IOrderBySpecification<T> Specification { get; protected set; }
        public Expression<Func<T, TKey>> KeySelector { get; protected set; }

        public ThenByDescendingSpecification(IOrderBySpecification<T> specification, Expression<Func<T, TKey>> keySelector)
        {
            Specification = specification;
            KeySelector = keySelector;
        }

        public IOrderedQueryable<T> SatisfiesMany(IQueryable<T> queryable)
        {
            IOrderedQueryable<T> prelim = Specification.SatisfiesMany(queryable);

            return prelim.ThenByDescending(KeySelector);
        }
    }
}
