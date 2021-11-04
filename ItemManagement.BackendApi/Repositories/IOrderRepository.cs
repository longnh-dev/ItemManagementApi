using ItemManagement.Data.Models;
using ItemManagement.Data.Models.Entities;
using ItemManagement.ViewModels.Catalog;
using ItemManagement.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderViewModel>> GetAllOrder();

        Task<OrderViewModel> GetAOrder(int orderId);

        Task<int> CreateNewOrder(OrderViewModel orderViewModel);

        Task<int> UpdateOrder(OrderViewModel orderViewModel);

        Task<int> DeleteOrder(int orderId);

        Task<PagedResult<OrderViewModel>> GetAllPaging(GetOrderPagingRequest request);
    }
}