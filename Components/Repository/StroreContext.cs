
using System.Reflection;
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
    public DbSet<ProductBrand> ProductsBrand {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}