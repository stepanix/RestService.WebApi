using RestService.Domain.Entities;
using RestService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestService.Service.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProductAsync(int id);
        Task<ProductModel> InsertProductAsync(ProductModel product);
        Task<ProductModel> UpdateProductAsync(ProductModel product);
        void DeleteProduct(int id);
    }
}
