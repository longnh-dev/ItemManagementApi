using ItemManagement.Data.Models.Entities;
using ItemManagerment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ItemManagementDbContext _context;

        public CartRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> CreateNewCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task DeleteCart(int cartId)
        {
            var cartToDelete = await _context.Carts.FindAsync(cartId);
            _context.Carts.Remove(cartToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetACart(int cartId)
        {
            return await _context.Carts.FindAsync(cartId);
        }

        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task UpdateCart(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}