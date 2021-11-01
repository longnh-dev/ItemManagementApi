using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        //Get All Cart
        /// <summary>
        /// This method to get all Cart info
        /// </summary>
        /// <returns>A list of Carts</returns>
        /// <remarks>
        /// Sample request
        /// GET Api/Cart
        /// </remarks>
        [HttpGet]
        public async Task<IEnumerable<Cart>> GetAllCart()
        {
            return await _cartRepository.GetAllCart();
        }

        //Get Cart by Id
        /// <summary>
        /// This method to get a Cart by Id
        /// </summary>
        /// <returns> Return Cart by Id</returns>
        [HttpGet("{cartId}")]
        public async Task<ActionResult<Cart>> GetACart(int cartId)
        {
            return await _cartRepository.GetACart(cartId);
        }

        /// <summary>
        /// This method to Create a Cart
        /// </summary>
        /// <param name="cart">Request's payload</param>
        /// <returns></returns>
        /// <response code="201">Cart created successfully</response>
        //Create New Cart
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Cart>> CreateNewCart([FromBody] Cart cart)
        {
            var newCart = await _cartRepository.CreateNewCart(cart);
            return CreatedAtAction(nameof(GetACart), new { CartId = newCart.Id }, newCart);
        }

        //Update cart information
        /// <summary>
        /// This method to Update information of a Cart
        /// </summary>
        [HttpPut("{cartId}")]
        public async Task<ActionResult> UpdateCart(int cartId, [FromForm] Cart cart)

        {
            if (cartId != cart.Id)
            {
                return BadRequest();
            }
            await _cartRepository.UpdateCart(cart);

            return Ok();
        }

        /// <summary>
        /// This method to Delete Cart
        /// </summary>
        /// <response code="200">Cart deleted successfully</response>
        [HttpDelete("{cartId}")]
        public async Task<ActionResult> DeleteCart(int cartId)
        {
            var cartToDelete = await _cartRepository.GetACart(cartId);
            if (cartToDelete == null)
                return NotFound();

            await _cartRepository.DeleteCart(cartToDelete.Id);
            return Ok();
        }
    }
}