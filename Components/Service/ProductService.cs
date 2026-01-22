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
        public ProductService(StoreContext context, IGenericRepository<Product> repo)
        {
            _context = context;
            _repo = repo;
        }
        public async Task<IReadOnlyList<ProductDTO>> GetAllProducts()
        {
            var spec = new ProductsBransTypeSpecification();
            var products = await _repo.ListAsync(spec);
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                name = product.name,
                description = product.description,
                price = product.price,
                pictureurl = product.pictureurl,
                producttype = product.producttype,
                productbrand = product.productbrand

            }).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var spec = new ProductsBransTypeSpecification(id);
            var product = await _repo.GetEntityWithSpecificationAsync(spec);
            return new ProductDTO
            {
                Id = product.Id,
                name = product.name,
                description = product.description,
                price = product.price,
                pictureurl = product.pictureurl,
                producttype = product.producttype,
                productbrand = product.productbrand
            };

        }

        public async Task<Product> CreateProduct(ProductDTO dto)
        {

            if (String.IsNullOrWhiteSpace(dto.name))
            {
                throw new Exception("There isn't a Name");
            }

            if (String.IsNullOrWhiteSpace(dto.description))
            {
                throw new Exception("There is not description");
            }
            var product = new Product
            {
                name = dto.name,
                description = dto.description,
                price = dto.price,
                pictureurl = dto.pictureurl,
                producttype = dto.producttype,
                productbrand = dto.productbrand
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}