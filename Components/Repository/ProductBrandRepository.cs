using Api.Interface;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ProductBrandRepository:IproductBrandRepository
    {
        private readonly StoreContext _config;

        public ProductBrandRepository(StoreContext config)
        {
            _config=config;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _config.ProductsBrand.ToListAsync() ??
            throw new Exception ("Brand wasn't found");
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            return await _config.ProductsBrand.FindAsync(id) ??
            throw new Exception ("Brand wasn't found");
        }

     
    }
}