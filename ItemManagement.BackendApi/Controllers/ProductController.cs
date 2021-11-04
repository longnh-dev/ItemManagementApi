using ItemManagemenkt.Application.Catalog.Products;
using ItemManagement.BackendApi.Repositories;
using ItemManagement.Data.Models.Entities;
using ItemManagement.ViewModels.Catalog;
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

        //http://localhost:port/product?pageIndex=1&pageSize=10&CategoryId=
        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductPagingRequest request)
        {
            var products = await _productRepository.GetAllPaging(request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null)
                return BadRequest("Not found product");

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {

            var productId = await _productRepository.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productRepository.GetById(productId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _productRepository.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _productRepository.Delete(productId);

            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
    }
}