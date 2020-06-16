using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsyc();
        Task<T> GetByIdAsync(int id);

        Task<T> GetBySpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

       
    }
}