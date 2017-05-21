using RestService.Domain.Entity;
using RestService.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace RestService.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            return entities.FirstOrDefault(s => s.Id == id);
        }

        public T Get(int id)
        {
            return entities.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            context.SaveChanges();
            return entity;
        }
    }
}
