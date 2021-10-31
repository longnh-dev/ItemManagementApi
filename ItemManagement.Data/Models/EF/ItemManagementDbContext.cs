using ItemManagement.Data.Models.Configurations;
using ItemManagement.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemManagerment.Models
{
    public class ItemManagementDbContext : DbContext
    {
        public ItemManagementDbContext()
        {
        }

        public ItemManagementDbContext(DbContextOptions<ItemManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}