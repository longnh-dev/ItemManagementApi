using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemManagement.Data.Models.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.OrderId).HasColumnName("OrderId").IsRequired();
            builder.Property(e => e.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(e => e.Customer).HasColumnName("Customer").IsRequired().HasMaxLength(30);
            builder.Property(e => e.ProductQuantity).HasColumnName("ProductQuantity").IsRequired();
            builder.Property(e => e.DateCreated).HasColumnName("DateCreated").IsRequired();
        }
    }
}