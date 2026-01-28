using API.Entities;
using SQLitePCL;

namespace API.Specifications
{
    public class ProductsBransTypeSpecification : BaseSpecification<Product>
    {
        public ProductsBransTypeSpecification(string sort, int ? Brand , int ? Type):
        base (x=> (!Brand.HasValue || x.productbrandid == Brand) && (!Type.HasValue || x.producttypeid==Type))
        {



            AddInclude(x=>x.productbrand);
            AddInclude(x=>x.producttype);
            AddOrderBy(x=>x.name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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