using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentistaFavoritoApp.Repositories
{
    /// <summary>
    /// Interfaz plantilla para los repositorios de entidades
    /// </summary>
    /// <typeparam name="T">Entidad  asociada al repositorio</typeparam>
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Añade o actualiza una entidad especifica en base de datos
        /// </summary>
        /// <param name="entity">entidad a añadir o actualizar</param>
        /// <returns></returns>
        T AddOrUpdate(T entity);
        /// <summary>
        /// Elimina una entidad en base de datos
        /// </summary>
        /// <param name="entity">entidad a eliminar</param>
        void Remove(T entity);
        /// <summary>
        /// Elimina una lista de entidades en base de datos
        /// </summary>
        /// <param name="entity">lista de entidades a eliminar</param>
        void RemoveRange(IEnumerable<T> entity);        
        /// <summary>
        /// Obtiene toda las entidades
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetAll();
        /// <summary>
        /// Obtiene la entidad asociada al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// Obtiene una lista de entidades que cumplan la condicion
        /// </summary>
        /// <param name="where">condicion de busqueda</param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
