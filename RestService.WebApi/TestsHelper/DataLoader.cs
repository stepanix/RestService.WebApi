

using RestService.Domain.Entities;
using RestService.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsHelper
{
    public class DataLoader
    {
        public static List<Product> ListAllProducts()
        {
                var products = new List<Product>
                {
                    new Product() {Description = "Bread"},
                    new Product() {Description = "Butter"},
                    new Product() {Description = "Milk"}
                };
            return products;
        }

        public static async Task<List<ProductModel>> ListAllProductsAsync()
        {
            var products = new List<ProductModel>
            {
                new ProductModel() {Id = 1,Description = "Bread"},
                new ProductModel() {Id = 2,Description = "Butter"},
                new ProductModel() {Id = 3,Description = "Milk"}
            };
            return await Task.FromResult(products);
        }
    }
}
