using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemManagement.Data.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProductName).IsRequired().HasColumnName("ProductName").HasMaxLength(30);
            builder.Property(e => e.Description).IsRequired().HasColumnName("Description").HasMaxLength(70);
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.OriginalPrice).IsRequired();
            builder.Property(e => e.Stock).IsRequired().HasDefaultValue(0);
        }
    }
}