using API.Entities;

namespace API.Specifications
{
    public class ProductsBransTypeSpecification : BaseSpecification<Product>
    {
        public ProductsBransTypeSpecification(ProductSpecParams par):
        base (x=> 
        (string.IsNullOrEmpty(par.search ) || x.name.ToLower().Contains(par.search)) && 
        (!par.Brand.HasValue || x.productbrandid == par.Brand) 
        && 
        (!par.Type.HasValue || x.producttypeid==par.Type))
        {



            AddInclude(x=>x.productbrand);
            AddInclude(x=>x.producttype);
            AddOrderBy(x=>x.name);
            ApplyPaging(par.PageSize * (par.PageIndex-1),par.PageSize);

            if (!string.IsNullOrEmpty(par.sort))
            {
                switch (par.sort)
                {
                    case "priceAsc":
                    AddOrderBy(p=>p.price);
                    break;
                    case "priceDesc":
                    AddOrderByDesc(p=>p.price);
                    break;
                    default:
                    AddOrderBy(n=>n.name);
                    break;
                }
            }
        }

         public ProductsBransTypeSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.productbrand);
            AddInclude(x=>x.producttype);
        }
    }
}