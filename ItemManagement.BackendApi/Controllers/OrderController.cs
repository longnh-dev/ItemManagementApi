using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)

        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _orderRepository.GetAllOrder();
        }

        //Get Department
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetAOrder(int orderId)
        {
            return await _orderRepository.GetAOrder(orderId);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromForm] Order order)
        {
            var newOrder = await _orderRepository.Create(order);
            return CreatedAtAction(nameof(GetAOrder), new { ProductId = newOrder.OrderId }, newOrder);
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult> UpdateOrder(int orderId, [FromForm] Order order)
        {
            if (orderId != order.OrderId)
            {
                return BadRequest();
            }
            await _orderRepository.Update(order);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var orderToDelete = await _orderRepository.GetAOrder(orderId);
            if (orderToDelete == null)
                return NotFound();

            await _orderRepository.Delete(orderToDelete.OrderId);
            return NoContent();
        }
    }
}