using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Api.DTO;
using API.Entities;
using API.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Service
{
    public class ProductService
    {

        private readonly StoreContext _context;
        public ProductService(StoreContext  context)
        {
            _context=context;
        }
         public async Task<List<Product>> GetAllProducts (){
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id)
            ?? throw new Exception("Product wasn't found");
            
        } 

        public async Task<Product> CreateProduct(ProductDTO dto)
        {

            if (String.IsNullOrWhiteSpace(dto.name))
            {
                throw new Exception("There isn't a Name");
            }

            if (String.IsNullOrWhiteSpace(dto.description)){
                throw new Exception("There is not description");
            }
            var product = new Product
            {
                name= dto.name,
                description= dto.description
            };
            _context.Products.Add(product);
            return product;
        }
    }
}