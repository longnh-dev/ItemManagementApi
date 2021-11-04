using ItemManagement.BackendApi.Exceptions;
using ItemManagement.Data.Models;
using ItemManagement.Data.Models.Entities;
using ItemManagement.ViewModels.Catalog;
using ItemManagement.ViewModels.Common;
using ItemManagerment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ItemManagementDbContext _context;

        public OrderRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderViewModel>> GetAllOrder()
        {
            var listDisplayOrder = new List<OrderViewModel>();
            var listOrder = await _context.Orders.ToListAsync();
            if (!listOrder.Any())
                throw new ItemManagementException("Khong co order nao trong csdl"); //Cho nay em tu viet tra ve nhe day laf truong hop listOrder null;

            foreach (var item in listOrder)
            {
                var newOrderModel = new OrderViewModel();
                var listCart = await _context.Carts.Where(x => x.OrderId == item.Id).ToListAsync();
                //em co the dung auto mapper de map du lieu tu Order vao OrderModel hoac lam nhu anh
                newOrderModel.Id = item.Id;
                newOrderModel.OrderDate = item.OrderDate;
                newOrderModel.PhoneNumber = item.PhoneNumber;
                newOrderModel.Status = item.Status;
                newOrderModel.Address = item.Address;
                newOrderModel.Customer = item.Customer;
                newOrderModel.DepartmentId = item.DepartmentId;
                newOrderModel.Email = item.Email;
                newOrderModel.CartList = listCart;
                listDisplayOrder.Add(newOrderModel);
            }
            return listDisplayOrder; //Cho nay em tu viet tra ve nhe;
        }

        public async Task<OrderViewModel> GetAOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            var orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                DepartmentId = order.DepartmentId,
                Customer = order.Customer,
                Address = order.Address,
                PhoneNumber = order.PhoneNumber,
                Email = order.Email,
                OrderDate = DateTime.Now,
                Status = Data.Models.Enums.OrderStatus.Success
            };
            return orderViewModel;
        }

        public async Task<int> CreateNewOrder(OrderViewModel orderViewModel)
        {
            var newOrder = new Order()
            {
                DepartmentId = orderViewModel.DepartmentId,
                Customer = orderViewModel.Customer,
                Address = orderViewModel.Address,
                PhoneNumber = orderViewModel.PhoneNumber,
                Email = orderViewModel.Email,
                OrderDate = DateTime.Now,
                Status = orderViewModel.Status,
            };

            _context.Orders.Add(newOrder);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = await _context.Orders.FindAsync(orderViewModel.Id);

            if (order == null) throw new ItemManagementException($"Khong tim thay Order voi id: {orderViewModel.Id}");

            order.DepartmentId = orderViewModel.DepartmentId;
            order.Customer = orderViewModel.Customer;
            order.Address = orderViewModel.Address;
            order.PhoneNumber = orderViewModel.PhoneNumber;
            order.Email = orderViewModel.Email;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new ItemManagementException($"Không tìm thấy Order với id {orderId}");

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<OrderViewModel>> GetAllPaging(GetOrderPagingRequest request)
        {
            var query = from p in _context.Orders
                        join pt in _context.Carts on p.Id equals pt.OrderId
                        select new { p, pt };

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.Customer.Contains(request.Keyword));

            var totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderViewModel()
                {
                    Id = x.p.Id,
                    DepartmentId = x.p.DepartmentId,
                    Customer = x.p.Customer,
                    Address = x.p.Address,
                    PhoneNumber = x.p.PhoneNumber,
                    Email = x.p.Email,
                    OrderDate = x.p.OrderDate,
                    Status = x.p.Status
                }).ToListAsync();

            var pagedResult = new PagedResult<OrderViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pagedResult;
        }
    }
}