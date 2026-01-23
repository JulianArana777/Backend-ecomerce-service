using System.Security.Cryptography.X509Certificates;
using Api.DTO;
using Api.Service;
using API.Entities;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controller
{
    
    [ApiController]
    [ Route("/api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ProductBrandService _brand;
        private readonly ProductTypeService _Type;
        public ProductController(ProductService service,ProductBrandService brand,ProductTypeService Type)
        {
            _service=service;
            _brand=brand;
            _Type=Type;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _service.GetAllProducts();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product =await _service.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        {
         return Ok(await _brand.GetAllProductBrands());   
        }
        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
        {
         return Ok(await _Type.GetAllProductTypes());   
        }

       /* [HttpPost]
        public async Task<IActionResult> CreateProduct ([FromBody] ProductDTO dto)
        {
          var product = await _service.CreateProduct(dto);
           return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product
            );
        }
       */
    }
}