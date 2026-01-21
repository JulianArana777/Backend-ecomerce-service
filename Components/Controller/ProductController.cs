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
        public ProductController(ProductService service)
        {
            _service=service;
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

        [HttpPost]
        public async Task<IActionResult> CreateProduct ([FromBody] ProductDTO dto)
        {
          var product = await _service.CreateProduct(dto);
           return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product
            );
        }
       
    }
}