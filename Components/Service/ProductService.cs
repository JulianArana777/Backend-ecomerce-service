using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Api.DTO;
using Api.Interface;
using Api.Repository;
using API.Entities;
using API.Repository;
using API.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Api.Service
{
    public class ProductService
    {

        private readonly StoreContext _context;
        private readonly IGenericRepository<Product> _repo;
        public ProductService(StoreContext  context, IGenericRepository<Product> repo)
        {
            _context=context;
             _repo=repo;
        }
         public async Task<IReadOnlyList<Product>> GetAllProducts (){
            var spec = new ProductsBransTypeSpecification ();
            return await _repo.ListAsync(spec);
        }

        public async Task<Product> GetProductById(int id)
        {
           var spec = new ProductsBransTypeSpecification(id);
           return await _repo.GetEntityWithSpecificationAsync(spec);
            
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
            await _context.SaveChangesAsync();
            return product;
        }
    }
}