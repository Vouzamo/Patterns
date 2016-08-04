using System;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public static class Helpers
    {
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static IWhereSpecification<T> And<T>(this IWhereSpecification<T> left, IWhereSpecification<T> right)
        {
            return new AndWhereSpecification<T>(left, right);
        }

        public static IWhereSpecification<T> Or<T>(this IWhereSpecification<T> left, IWhereSpecification<T> right)
        {
            return new OrWhereSpecification<T>(left, right);
        }

        public static IOrderBySpecification<T> OrderBy<T, TKey>(this IWhereSpecification<T> specification, Expression<Func<T, TKey>> keySelector) where TKey : IComparable<TKey>
        {
            return new OrderBySpecification<T, TKey>(specification, keySelector);
        }

        public static IOrderBySpecification<T> OrderByDescending<T, TKey>(this IWhereSpecification<T> specification, Expression<Func<T, TKey>> keySelector) where TKey : IComparable<TKey>
        {
            return new OrderByDescendingSpecification<T, TKey>(specification, keySelector);
        }

        public static IThenBySpecification<T> ThenBy<T, TKey>(this IOrderBySpecification<T> specification, Expression<Func<T, TKey>> keySelector) where TKey : IComparable<TKey>
        {
            return new ThenBySpecification<T, TKey>(specification, keySelector);
        }

        public static IThenBySpecification<T> ThenByDescending<T, TKey>(this IOrderBySpecification<T> specification, Expression<Func<T, TKey>> keySelector) where TKey : IComparable<TKey>
        {
            return new ThenByDescendingSpecification<T, TKey>(specification, keySelector);
        }
    }
}
