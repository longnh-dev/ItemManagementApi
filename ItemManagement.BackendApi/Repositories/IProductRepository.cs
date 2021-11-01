using ItemManagement.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemManagement.BackendApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();

        Task<Product> GetAProduct(int productId);

        Task<Product> CreateNewProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int productId);
    }
}