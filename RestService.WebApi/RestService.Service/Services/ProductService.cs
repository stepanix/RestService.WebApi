using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestService.Domain.Entities;
using RestService.Repository.Repository;
using RestService.Service.Services.Base;

namespace RestService.Service.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IDomainService domainService;

        public ProductService(IRepository<Product> productRepository, IDomainService domainService)
        {
            this.productRepository = productRepository;
            this.domainService = domainService;
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> InsertProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
