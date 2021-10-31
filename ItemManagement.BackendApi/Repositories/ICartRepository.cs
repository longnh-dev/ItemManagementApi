using ItemManagement.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllCart();

        Task<Cart> GetACart(int cartId);

        Task<Cart> CreateNewCart(Cart cart);

        Task UpdateCart(Cart cart);

        Task DeleteCart(int cartId);
    }
}