

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestService.Domain.Entities;
using RestService.Domain.Repositories;
using RestService.EntityFramework.Repositories.Base;

namespace RestService.EntityFramework.Repositories
{
    public class ProductRepository : ORMBaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
