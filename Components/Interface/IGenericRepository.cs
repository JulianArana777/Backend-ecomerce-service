using API.Entities;
using API.Specifications;

namespace API.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync (int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpecificationAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsyn (ISpecification<T> spec);

    } 
}