using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DentistaFavoritoApp.Repositories
{
    public interface IRepository<T> where T: class
    {
        T Add(T entity);
        void Remove(T entity);
        T Update(T entity);
        ICollection<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
