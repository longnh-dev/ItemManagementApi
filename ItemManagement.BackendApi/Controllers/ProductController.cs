using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)

        {
            _productRepository = productRepository;
        }

        //Get all department
        /// <summary>
        /// This method to get all Product info
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        //Get Department
        /// <summary>
        /// This method to get a Product info
        /// </summary>
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetAProduct(int productId)
        {
            return await _productRepository.GetAProduct(productId);
        }

        /// <summary>
        /// This method to create new Product
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateDepartment([FromBody] Product product)
        {
            var newProduct = await _productRepository.CreateNewProduct(product);
            return CreatedAtAction(nameof(GetAProduct), new { ProductId = newProduct.Id }, newProduct);
        }

        /// <summary>
        /// This method to update Product info
        /// </summary>
        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(int productId, [FromForm] Product product)
        {
            if (productId != product.Id)
            {
                return BadRequest();
            }
            await _productRepository.UpdateProduct(product);
            return Ok();
        }

        /// <summary>
        /// This method to delete Product
        /// </summary>
        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var productToDelete = await _productRepository.GetAProduct(productId);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.DeleteProduct(productToDelete.Id);
            return Ok();
        }
    }
}