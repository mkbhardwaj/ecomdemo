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
        public Expression<Func<T,Object>> OrderBy{ get; private set; }
        public Expression<Func<T, Object>> OrderByDesc { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public Boolean IsPaginated { get; private set; }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, Object>>> Includes { get; } = new List<Expression<Func<T, Object>>>();
        public void AddOrderBy(Expression<Func<T, Object>> orderby)
        {
            OrderBy = orderby;
        }
        public void AddOrderByDesc(Expression<Func<T, Object>> orderbydesc)
        {
            OrderByDesc = orderbydesc;
        }
        public void AddInludes(Expression<Func<T, Object>> include)
        {
            this.Includes.Add(include);
        }
        public void AddPagination(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPaginated = true;
        }
    }
}