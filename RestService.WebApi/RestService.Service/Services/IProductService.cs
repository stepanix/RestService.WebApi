using RestService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestService.Service.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(long id);
        Task<Product> InsertProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        void DeleteProduct(int id);
    }
}
