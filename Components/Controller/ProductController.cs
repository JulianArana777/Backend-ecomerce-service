using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    
    [ApiController]
    [ Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public String GetProducts()
        {
            return "Product";
        }

        [HttpGet("{id}")]
        public String GetProductById(long id)
        {
            return "This product";
        }

        [HttpPost]
        public void CreateProduct()
        {
            
        }
       
    }
}