

using RestService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestService.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> InsertProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
