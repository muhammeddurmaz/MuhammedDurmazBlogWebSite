using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        List<T> GetAll();
        void Save(T entity);
        void Delete(Guid id);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetEntity(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        void Update(T entity);
        List<T> OrderByDescending(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
