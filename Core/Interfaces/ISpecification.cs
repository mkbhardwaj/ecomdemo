using System.Linq.Expressions;
using System;
using System.Collections.Generic;
namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, Object>>> Includes { get; }

        Expression<Func<T,Object>>  OrderBy { get; }
        Expression<Func<T, Object>> OrderByDesc { get; }
        int Skip { get; }
        int Take { get; }
        Boolean IsPaginated { get; }


    }

}