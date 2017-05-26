using RestService.Domain.Entity;
using RestService.Domain.Entity.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestService.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(int id);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
