using RestService.Domain.Entities;
using RestService.Repository.Repository;
using System.Collections.Generic;


namespace RestService.Repository.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product CreateProduct(Product product);
        Product UpdateProduct(int Id);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int Id);
        bool DeleteProduct(int Id);
    }
}
