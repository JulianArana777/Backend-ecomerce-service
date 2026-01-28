using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Api.DTO;
using Api.Interface;
using Api.Repository;
using API.Entities;
using API.ERRORS;
using API.Helper;
using API.Repository;
using API.Specifications;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Service
{
    public class ProductService
    {

        private readonly StoreContext _context;
        private readonly IGenericRepository<Product> _repo;
        private readonly IMapper _mapper;
        public ProductService(StoreContext context, IGenericRepository<Product> repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper= mapper;
        }
        public async Task<Pagination<ProductDTO>> GetAllProducts(ProductSpecParams par)
        {
            var spec = new ProductsBransTypeSpecification(par);
            var countspec= new ProductWithFiltersOrCountSpecification(par);
            var totalitems= await _repo.CountAsyn(countspec);
            var products = await _repo.ListAsync(spec);
            var data
          = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(products);
          return new Pagination<ProductDTO>(par.PageIndex,par.PageSize,totalitems,data);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var spec = new ProductsBransTypeSpecification(id);
            var product = await _repo.GetEntityWithSpecificationAsync(spec);
            return _mapper.Map<Product,ProductDTO>(product);

        }

      /*  public async Task<ProductDTO> CreateProduct(Product product)
        {

          
            var DTO = new ProductDTO
            {
                name =  product.name,
                description =  product.description,
                price =  product.price,
                pictureurl =  product.pictureurl,
                producttype =  product.producttype.name,
                productbrand =  product.productbrand.name
            };
            _context.Products.Add(DTO);
            await _context.SaveChangesAsync();
            return DTO;
        }*/
    }
}