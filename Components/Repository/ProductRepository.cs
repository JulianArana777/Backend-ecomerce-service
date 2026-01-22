using Api.Interface;
using API.Entities;
using API.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class ProductRepository : IproductRepository
    {

        private readonly StoreContext _config;

        public ProductRepository(StoreContext config)
        {
            _config=config;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _config.Products
            .Include(p=>p.producttype)
            .Include(p=>p.productbrand)
            .FirstOrDefaultAsync(p=>p.Id == id) ?? 
            throw new Exception("Product Wasn't Found");
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _config.Products
            .Include(p=>p.producttype)
            .Include(p=>p.productbrand)
            .ToListAsync() ??
            throw new Exception ("There aren't any products");
        }
    }
}