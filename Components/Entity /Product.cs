

namespace API.Entities
{
   public class Product : BaseEntity
    {
       
        public String ? name {get;set;}
        public String ? description {get;set;}
        public float price {get;set;}
        public String ? pictureurl {get;set;}
        public ProductType producttype {get;set;}
        public int producttypeid {get;set;}
        public ProductBrand productbrand {get;set;}
        public int productbrandid {get;set;}

        

    }
}