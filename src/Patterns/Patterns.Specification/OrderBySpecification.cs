using System;
using System.Linq;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public class OrderBySpecification<T, TKey> : IOrderBySpecification<T> where TKey : IComparable<TKey>
    {
        public IWhereSpecification<T> Specification { get; protected set; }
        public Expression<Func<T, TKey>> KeySelector { get; protected set; }

        public OrderBySpecification(IWhereSpecification<T> specification, Expression<Func<T, TKey>> keySelector)
        {
            Specification = specification;
            KeySelector = keySelector;
        }

        public IOrderedQueryable<T> SatisfiesMany(IQueryable<T> queryable)
        {
            IQueryable<T> prelim = Specification.SatisfiesMany(queryable);

            return prelim.OrderBy(KeySelector);
        }
    }
}
