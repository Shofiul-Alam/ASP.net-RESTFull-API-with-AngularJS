using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;

namespace GrandTravel.Repo
{
    public abstract class BaseEFRepository<T> : IRepository<T> where T :class
    {

        private GrandTravelContext _context;
        private DbSet<T> _dbSet;

        public BaseEFRepository()
        {
            _context = new GrandTravelContext();
            _dbSet = _context.Set<T>();
        }
        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            int result = _context.SaveChanges();
            
            return result > 0;
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

    }
}
