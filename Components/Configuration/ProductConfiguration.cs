using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.description).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.name).IsRequired();
            builder.Property(p=>p.pictureurl).IsRequired();
            builder.Property(p=>p.price).HasColumnType("decimal(18,2)");
            builder.HasOne(b=>b.productbrand).WithMany().HasForeignKey(p=>p.productbrandid);
            builder.HasOne(b=>b.producttype).WithMany().HasForeignKey(p=>p.producttypeid);
        }
    }
}