using Api.Interface;
using API.Entities;
using API.Interface;
using API.Repository;

namespace Api.Service
{
    public class ProductBrandService
    {

        private readonly StoreContext _context;
        private readonly IGenericRepository<ProductBrand> _repo;
        public ProductBrandService(StoreContext  context, IGenericRepository<ProductBrand> repo)
        {
            _context=context;
             _repo=repo;
        }
         public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrands (){
            return await _repo.GetAllAsync();
        }

        public async Task<ProductBrand> GetProductBrandById(int id)
        {
           return await _repo.GetByIdAsync(id);
            
        } 
    }
}