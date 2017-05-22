using RestService.Domain.Core;
using RestService.Domain.Entity;
using RestService.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Repository.Repository.Base
{
    public class Repository<T> : IRepository<T>,IDisposable where T : BaseEntity
    {
        private DataContext context;
        private DbSet<T> table;
        string errorMessage = string.Empty;

        public Repository(DataContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entity = table.Local.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                if (entity == null)
                {
                    return;
                }
            }
            DeleteSoft(entity);
        }

        private void DeleteSoft(T entity)
        {
            if (entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = true;
            }
            else
            {
                table.Remove(entity);
            }
        }

        public T Get(int id)
        {
            return table.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return table.AsEnumerable();
        }

        public T Insert(T entity)
        {
            table.Add(entity);            
            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await context.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await table.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await Task.FromResult(table.Add(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
