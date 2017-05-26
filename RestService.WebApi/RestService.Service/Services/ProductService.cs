
using System.Collections.Generic;
using System.Threading.Tasks;
using RestService.Domain.Entities;
using RestService.Domain.Models;
using AutoMapper;
using RestService.Domain.Repositories;
using System;

namespace RestService.Service.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        IMapper mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
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
            productForUpdate.ModifiedDate = DateTime.Now;
            productForUpdate.Description = product.Description;
            
            await productRepository.SaveChangesAsync();
            return mapper.Map<ProductModel>(productForUpdate);
        }

    }
}
