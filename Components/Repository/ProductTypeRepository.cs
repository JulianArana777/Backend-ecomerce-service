using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ProductTypeRepository:IproductTypeRepository
    {
        private readonly StoreContext _config;

        public ProductTypeRepository(StoreContext config)
        {
            _config=config;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _config.ProductsType.ToListAsync() ??
            throw new Exception ("Type wasn't found");
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _config.ProductsType.FindAsync(id) ??
            throw new Exception ("Type wasn't found");
        }

        
    }
}