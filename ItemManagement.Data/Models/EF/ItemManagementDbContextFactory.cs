using ItemManagerment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ItemManagementData.Models.EF
{
    public class ItemManagementDbContextFactory : IDesignTimeDbContextFactory<ItemManagementDbContext>
    {
        public ItemManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("ItemManagementDb");

            var optionBuilder = new DbContextOptionsBuilder<ItemManagementDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new ItemManagementDbContext(optionBuilder.Options);
        }
    }
}