using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// This method to get all Order info
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await _orderRepository.GetAllOrder();
        }

        /// <summary>
        /// This method to get a Order info
        /// </summary>
        //Get Department
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetAOrder(int orderId)
        {
            return await _orderRepository.GetAOrder(orderId);
        }

        /// <summary>
        /// This method to create new order
        /// </summary>
        /// /// <param name="Order">Request's payload</param>
        /// <returns></returns>
        /// <response code="201">Order created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Order>> CreateNewOrder([FromBody] Order order)
        {
            var newOrder = await _orderRepository.CreateNewOrder(order);
            return CreatedAtAction(nameof(GetAOrder), new { OrderId = newOrder.Id }, newOrder);
        }

        /// <summary>
        /// This method to update order info
        /// </summary>
        [HttpPut("{orderId}")]
        public async Task<ActionResult> UpdateOrder(int orderId, [FromForm] Order order)
        {
            if (orderId != order.Id)
            {
                return BadRequest();
            }
            await _orderRepository.UpdateOrder(order);
            return Ok();
        }

        /// <summary>
        /// This method to delete
        /// </summary>
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var orderToDelete = await _orderRepository.GetAOrder(orderId);
            if (orderToDelete == null)
                return NotFound();

            await _orderRepository.DeleteOrder(orderToDelete.Id);
            return Ok();
        }
    }
}