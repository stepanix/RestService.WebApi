using RestService.Domain.Entity;
using System.Collections.Generic;

namespace RestService.Repository.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
