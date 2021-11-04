using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models;
using ItemManagement.ViewModels.Catalog;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllPaging([FromQuery] GetOrderPagingRequest request)
        {
            var order = await _orderRepository.GetAllPaging(request);
            return Ok(order);
        }

        //http://localhost:port/product/1
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var order = await _orderRepository.GetAOrder(orderId);

            if (order == null)
                return BadRequest("Not found product");

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderViewModel orderViewModel)
        {
            var orderId = await _orderRepository.CreateNewOrder(orderViewModel);
            if (orderId == 0)
                return BadRequest();

            var order = await _orderRepository.GetAOrder(orderId);

            return CreatedAtAction(nameof(GetById), new { id = orderId }, order);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _orderRepository.UpdateOrder(orderViewModel);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var affectedResult = await _orderRepository.DeleteOrder(orderId);

            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
    }
}