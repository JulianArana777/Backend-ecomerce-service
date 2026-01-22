using API.Entities;
using API.Interface;
using API.Repository;

namespace Api.Service
{
    public class ProductTypeService
    {

        private readonly StoreContext _context;
        private readonly IproductTypeRepository _repo;
        public ProductTypeService(StoreContext  context, IproductTypeRepository repo)
        {
            _context=context;
             _repo=repo;
        }
         public async Task<IReadOnlyList<ProductType>> GetAllProductTypes (){
            return await _repo.GetProductTypesAsync();
        }

        public async Task<ProductType> GetProductTypeById(int id)
        {
           return await _repo.GetProductTypeByIdAsync(id);
            
        } 
    }
}