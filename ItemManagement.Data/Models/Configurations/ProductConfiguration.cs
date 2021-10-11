using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.Data.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductName).IsRequired().HasColumnName("ProductName").HasMaxLength(50);
            builder.Property(e => e.Price).IsRequired().HasColumnName("Price").HasMaxLength(30);
            builder.Property(e => e.Stock).IsRequired().HasColumnName("Stock").HasMaxLength(50);
        }
    }
}