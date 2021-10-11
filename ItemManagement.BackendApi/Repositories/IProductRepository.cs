using ItemManagement.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();

        Task<Product> GetAProduct(int productId);

        Task<Product> Create(Product product);

        Task Update(Product product);

        Task Delete(int productId);
    }
}