using Api.DTO;
using API.Entities;
using AutoMapper;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, String>
    {
        public readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config=config;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.pictureurl))
            {
                return _config["ApiUrl"] + source.pictureurl;
            }
            return null;
        }
    }
}