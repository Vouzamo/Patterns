using System;
using System.Linq;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public class OrWhereSpecification<T> : WhereSpecification<T>
    {
        public OrWhereSpecification(IWhereSpecification<T> left, IWhereSpecification<T> right)
        {
            var parameter = Expression.Parameter(typeof(T), "subject");

            Predicate = Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    Expression.Invoke(left.Predicate, parameter),
                    Expression.Invoke(right.Predicate, parameter)
                ),
                parameter
            );
        }

        public override IQueryable<T> SatisfiesMany(IQueryable<T> queryable)
        {
            return queryable.Where(Predicate);
        }
    }
}
