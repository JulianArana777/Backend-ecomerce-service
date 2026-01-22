using API.Entities;
using API.Specifications;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context=context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync()??
           throw new Exception("Nothing was found");
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FindAsync(id) ??
           throw new Exception("Nothing was found");
        }

        public async Task<T> GetEntityWithSpecificationAsync(ISpecification<T> spec)
        {
            return await ApplyASpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
           return await ApplyASpecification(spec).ToListAsync();
        }
        private IQueryable<T> ApplyASpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }
    }
}