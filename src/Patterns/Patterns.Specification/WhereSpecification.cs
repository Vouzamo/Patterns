using System;
using System.Linq;
using System.Linq.Expressions;
using Patterns.Specification.Interfaces;

namespace Patterns.Specification
{
    public abstract class WhereSpecification<T> : IWhereSpecification<T>
    {
        private Func<T, bool> _compiledExpression;
        private Func<T, bool> CompiledExpression { get { return _compiledExpression ?? (_compiledExpression = Predicate.Compile()); } }
        public Expression<Func<T, bool>> Predicate { get; protected set; }

        public bool IsSatisfiedBy(T subject)
        {
            return CompiledExpression(subject);
        }

        public virtual IQueryable<T> SatisfiesMany(IQueryable<T> queryable)
        {
            return queryable.Where(Predicate);
        }
    }
}
