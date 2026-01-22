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

         public ProductsBransTypeSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.productbrand);
            AddInclude(x=>x.producttype);
        }
    }
}