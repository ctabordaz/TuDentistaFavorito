using DentistaFavoritoApp.Entity;
using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace DentistaFavoritoApp.Repositories
{
    public class RepositorioBase<T> : IRepository<T> where T:class
    {
        private DentistaContext dbContext;
        protected  IDbSet<T> dbSet;

        public RepositorioBase()
        {
            this.dbContext = new DentistaContext();
            dbSet = dbContext.Set<T>();
        }

        public RepositorioBase(DentistaContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual ICollection<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;
        }
    }
}