using API.Entities;

namespace API.Specifications
{
    public class ProductsBransTypeSpecification : BaseSpecification<Product>
    {
        public ProductsBransTypeSpecification()
        {
            AddInclude(x=>x.productbrand);
            AddInclude(x=>x.producttype);
        }
    }
}