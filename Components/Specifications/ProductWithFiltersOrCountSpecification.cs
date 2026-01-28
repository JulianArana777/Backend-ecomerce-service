using API.Entities;

namespace API.Specifications
{
    public class ProductWithFiltersOrCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersOrCountSpecification(ProductSpecParams par) :
         base (x=> (!par.Brand.HasValue || x.productbrandid == par.Brand) && (!par.Type.HasValue || x.producttypeid==par.Type))
        {
        }
    }
}