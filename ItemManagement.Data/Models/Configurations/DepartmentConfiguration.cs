using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemManagement.Data.Models.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.DepartmentName).IsRequired().HasColumnName("DepartmentNames").HasMaxLength(30);
            builder.Property(e => e.Leader).IsRequired().HasColumnName("Leaders").HasMaxLength(30);
            builder.Property(e => e.Personnel).IsRequired().HasColumnName("Personnels").HasMaxLength(30);
            builder.Property(e => e.DateOfEstablish).IsRequired().HasColumnName("DateOfEstablish");
        }
    }
}