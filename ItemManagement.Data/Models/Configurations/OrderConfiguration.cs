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

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Customer).HasColumnName("Customer").HasMaxLength(30);
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId").IsRequired();
            builder.Property(e => e.Address).HasColumnName("Address").IsRequired().HasMaxLength(30);
            builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(30);
            builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(30);
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.Status).IsRequired();
        }
    }
}