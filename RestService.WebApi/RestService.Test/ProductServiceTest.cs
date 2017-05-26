using AutoMapper;
using Moq;
using NUnit.Framework;
using RestService.Domain.Entities;
using RestService.Domain.Models;
using RestService.Domain.Repositories;
using RestService.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsHelper;


namespace RestService.Test
{
    [TestFixture]
    public class ProductServiceTest
    {
        //IProductRepository _productRepository;

        IProductService _productService;
        List<ProductModel> _randomProductList;

        [Test]
        public async Task ServiceShouldReturnAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            Assert.That(products, Is.EqualTo(_randomProductList));
        }

        [SetUp]
        public async Task Setup()
        {
            _randomProductList = await SetupProducts();
            _productService = SetupProductService();
        }

        public async Task<List<ProductModel>> SetupProducts()
        {
            int _counter = new int();
            List<ProductModel> _products = await DataLoader.ListAllProductsAsync();

            foreach (ProductModel _product in _products)
                _product.Id = ++_counter;
            
            return _products;
        }

        public IProductService SetupProductService()
        {
            // Init repository
            var service = new Mock<IProductService>();

            // Setup mocking behavior
            service.Setup(r => r.GetProductsAsync()).ReturnsAsync(_randomProductList);

            service.Setup(r => r.GetProductAsync(It.IsAny<int>()))
               .ReturnsAsync(new Func<int, ProductModel>(
                   id => _randomProductList.Find(a => a.Id.Equals(id))));


            service.Setup(r => r.InsertProductAsync(It.IsAny<ProductModel>()))
                .Callback(new Action<ProductModel>(newProduct =>
                {
                    dynamic maxProductID = _randomProductList.Count;
                    dynamic nextProductID = maxProductID + 1;
                    newProduct.Id = nextProductID;
                    newProduct.Description = "New Description " + nextProductID;
                     _randomProductList.Add(newProduct);
                }));

            service.Setup(r => r.UpdateProductAsync(It.IsAny<ProductModel>()))
                .Callback(new Action<ProductModel>(x =>
                {
                    var oldProduct = _randomProductList.Find(a => a.Id == x.Id);
                    oldProduct.Description = "Update Description " + DateTime.Now;
                    oldProduct = x;
                }));
           
            // Return mock implementation
            return service.Object;
        }

        


        /// </summary>
        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
            //_productRepository = null;
            _productService = null;
            _randomProductList = null;
        }


    }
}
