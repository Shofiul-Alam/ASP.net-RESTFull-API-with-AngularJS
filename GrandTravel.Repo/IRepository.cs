using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandTravel.Repo
{
    //This is the core functionality that any repository should have
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        T GetById(long id);
        IList<T> GetAll();
        IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter);
    }
}
