using ItemManagement.Data.Models.Entities;
using ItemManagerment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ItemManagementDbContext _context;

        public ProductRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateNewProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
            var productToDelete = await _context.Products.FindAsync(productId);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetAProduct(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}