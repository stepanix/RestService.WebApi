using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestService.Domain.Entities;
using RestService.Repository.Repository.Base;
using RestService.Service.Services.Base;
using RestService.Domain.Models;
using AutoMapper;

namespace RestService.Service.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IDomainService domainService;
        IMapper mapper;

        public ProductService(IMapper mapper,IRepository<Product> productRepository, IDomainService domainService)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.domainService = domainService;
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
        }

        public async Task<ProductModel> GetProductAsync(int id)
        {
           return mapper.Map<ProductModel>(await productRepository.GetAsync(id));
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return mapper.Map<IEnumerable<ProductModel>>(await productRepository.GetAllAsync());
        }

        public async Task<ProductModel> InsertProductAsync(ProductModel product)
        {
            var newProduct = await productRepository.InsertAsync(mapper.Map<Product>(product));
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(newProduct);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel product)
        {
            var productForUpdate = await productRepository.GetAsync(product.Id);
            productForUpdate.Description = product.Description;
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(productForUpdate);
        }
    }
}
