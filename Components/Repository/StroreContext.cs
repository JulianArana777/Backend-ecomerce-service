
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class StoreContext: DbContext
    {
         public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products {get;set;}
    public DbSet<ProductType> ProductsType {get;set;}
    public DbSet<ProductBrand> ProductBrands {get;set;}
    }
}