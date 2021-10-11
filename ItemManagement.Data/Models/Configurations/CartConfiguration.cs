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

            builder.Property(e => e.CartId).HasColumnName("CartId");
            builder.Property(e => e.OrderId).HasColumnName("OrderId");

            builder.HasMany(d => d.Orders).WithOne(d => d.Carts);
        }
    }
}