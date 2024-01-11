using Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class,  new()
    {
        private readonly WebSiteContext _context;
        public EfCoreRepository(WebSiteContext context) {
            _context = context;
        }   

        private DbSet<TEntity> _entities { get => _context.Set<TEntity>(); }
        public void Delete(Guid id)
        {
            TEntity entity = GetById(id);
            _entities.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _entities.Find(id);
        }

        public void Save(TEntity entity)
        {
            _entities.Add(entity);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate = null,params Expression<Func<TEntity,object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public TEntity GetEntity(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query.Single();
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public List<TEntity> OrderByDescending(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var property in includeProperties)
                {
                    query = query.OrderByDescending(property);
                }
            }
            
            return query.ToList();
        }
    }
}
