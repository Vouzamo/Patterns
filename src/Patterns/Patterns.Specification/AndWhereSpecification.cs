using System;
using System.Linq;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public class AndWhereSpecification<T> : WhereSpecification<T>
    {
        public AndWhereSpecification(IWhereSpecification<T> left, IWhereSpecification<T> right)
        {
            var parameter = Expression.Parameter(typeof(T), "subject");

            Predicate = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
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
