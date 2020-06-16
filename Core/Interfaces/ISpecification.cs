using System.Linq.Expressions;
using System;
using System.Collections.Generic;
namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, Object>>> Includes { get; }
    }

}