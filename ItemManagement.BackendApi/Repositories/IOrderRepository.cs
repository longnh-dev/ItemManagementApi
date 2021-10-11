using ItemManagement.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrder();

        Task<Order> GetAOrder(int orderId);

        Task<Order> Create(Order order);

        Task Update(Order order);

        Task Delete(int orderId);
    }
}