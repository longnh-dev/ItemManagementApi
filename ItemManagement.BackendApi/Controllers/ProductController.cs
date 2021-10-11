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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)

        {
            _productRepository = productRepository;
        }

        //Get all department
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        //Get Department
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetAProduct(int productId)
        {
            return await _productRepository.GetAProduct(productId);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateDepartment([FromBody] Product product)
        {
            var newProduct = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetAProduct), new { ProductId = newProduct.ProductId }, newProduct);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(int productId, [FromForm] Product product)
        {
            if (productId != product.ProductId)
            {
                return BadRequest();
            }
            await _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var productToDelete = await _productRepository.GetAProduct(productId);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.Delete(productToDelete.ProductId);
            return NoContent();
        }
    }
}