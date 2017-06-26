using DentistaFavoritoApp.Entity;
using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace DentistaFavoritoApp.Repositories
{
    /// <summary>
    /// Clase abstracta que implementa las funciones basicas de un repositorio
    /// </summary>
    /// <typeparam name="T">Entidad asociada al repositorio</typeparam>
    public class RepositorioBase<T> : IRepository<T> where T:class
    {
        /// <summary>
        /// Contexto de base de datos
        /// </summary>
        private DentistaContext dbContext;
        /// <summary>
        /// set de entidades de base de datos
        /// </summary>
        protected  IDbSet<T> dbSet;

        /// <summary>
        /// Inicializa el contexto de base de datos
        /// </summary>
        public RepositorioBase()
        {
            this.dbContext = new DentistaContext();
            dbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Asigna el contexto de base de datos
        /// </summary>
        /// <param name="dbContext"></param>
        public RepositorioBase(DentistaContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        /// <summary>
        ///  Añade o actualiza una entidad especifica en base de datos
        /// </summary>
        /// <param name="entity">entidad a añadir o actualizar</param>
        /// <returns></returns>
        public T AddOrUpdate(T entity)
        {
            dbSet.AddOrUpdate(entity);
            dbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Obtiene toda las entidades
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<T> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Obtiene la entidad asociada al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Obtiene una lista de entidades que cumplan la condicion
        /// </summary>
        /// <param name="where">condicion de busqueda</param>
        /// <returns></returns>
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        /// <summary>
        /// Elimina una entidad en base de datos
        /// </summary>
        /// <param name="entity">entidad a eliminar</param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();            
        }

        /// <summary>
        /// Elimina una lista de entidades en base de datos
        /// </summary>
        /// <param name="entity">lista de entidades a eliminar</param>
        public void RemoveRange(IEnumerable<T> entity)
        {
            foreach (var entityToRemove in entity)
            {
                Remove(entityToRemove);
            }
        }
    }
}