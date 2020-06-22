using Core.Interfaces;
using Core.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluater<T> where T : BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
        {

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.IsPaginated)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            if (spec.Includes != null && spec.Includes.Count() > 0)
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            
            return query;
        }
    }
}