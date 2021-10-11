using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemManagement.Data.Models.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(e => e.OrderId).HasColumnName("OrderId");
            builder.Property(e => e.ProductId).HasColumnName("ProductId");
            builder.Property(e => e.Customer).HasColumnName("Customer").HasMaxLength(30);
            builder.Property(e => e.OrderDate).IsRequired();
        }
    }
}