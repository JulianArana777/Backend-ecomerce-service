using API.Entities;
using API.Interface;
using API.Repository;

namespace Api.Service
{
    public class ProductTypeService
    {

        private readonly StoreContext _context;
        private readonly IGenericRepository<ProductType> _repo;
        public ProductTypeService(StoreContext  context, IGenericRepository<ProductType> repo)
        {
            _context=context;
             _repo=repo;
        }
         public async Task<IReadOnlyList<ProductType>> GetAllProductTypes (){
            return await _repo.GetAllAsync();
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
           return await _repo.GetByIdAsync(id);
            
        } 
    }
}