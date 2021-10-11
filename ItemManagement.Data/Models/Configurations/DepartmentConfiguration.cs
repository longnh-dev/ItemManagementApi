using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemManagement.Data.Models.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(e => e.DepartmentId);
            builder.Property(e => e.DepartmentName).IsRequired().HasColumnName("DepartmentName").HasMaxLength(50);
            builder.Property(e => e.Leader).IsRequired().HasColumnName("Leader").HasMaxLength(40);
            builder.Property(e => e.DateOfEstablish).IsRequired().HasColumnName("DateOfEstablish").HasMaxLength(50);
        }
    }
}