using System.Collections.Generic;
using Core.Interfaces;
using System;
using System.Linq.Expressions;
namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            this.Criteria = criteria;
        }
        public BaseSpecification()
        {

        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, Object>>> Includes { get; } = new List<Expression<Func<T, Object>>>();
        public void AddInludes(Expression<Func<T, Object>> include)
        {
            this.Includes.Add(include);
        }
    }
}