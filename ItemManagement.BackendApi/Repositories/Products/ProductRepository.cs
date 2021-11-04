using ItemManagement.BackendApi.Exceptions;
using ItemManagement.Data.Models.Entities;
using ItemManagement.ViewModels.Catalog;
using ItemManagement.ViewModels.Common;
using ItemManagerment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagemenkt.Application.Catalog.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ItemManagementDbContext _context;

        public ProductRepository(ItemManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Id = request.Id,
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new ItemManagementException($"Cannot find a product: {productId}");
            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products

                        select new { p };

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.ProductName.Contains(request.Keyword));

            int toralRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    ProductName = x.p.ProductName,
                    Description = x.p.Description,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock
                }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = toralRow,
                Items = data
            };

            return pagedResult;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock
            };
            return productViewModel;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null) throw new ItemManagementException($"Không tìm thấy id của sản phẩm: {request.Id}");

            //query to data
            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Price = request.Price;
            product.OriginalPrice = request.OriginalPrice;
            product.Stock = request.Stock;

            return await _context.SaveChangesAsync();
        }
    }
}