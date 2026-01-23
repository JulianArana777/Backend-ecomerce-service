using API.Entities;

namespace Api.DTO
{
    public class ProductDTO()
    {


        public int Id { get; set; }
        public String? name { get; set; }
        public String? description { get; set; }
        public float price { get; set; }
        public String? pictureurl { get; set; }
        public String producttype { get; set; }       
        public String productbrand { get; set; }
       

    }
}