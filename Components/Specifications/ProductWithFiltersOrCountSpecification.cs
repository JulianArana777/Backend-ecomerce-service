using API.Entities;

namespace API.Specifications
{
    public class ProductWithFiltersOrCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersOrCountSpecification(ProductSpecParams par) :
         base (x=> (string.IsNullOrEmpty(par.search ) || x.name.ToLower().Contains(par.search)) && 
         (!par.Brand.HasValue || x.productbrandid == par.Brand) && 
         (!par.Type.HasValue || x.producttypeid==par.Type))
        {
        }
    }
}