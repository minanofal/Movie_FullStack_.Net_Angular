using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
       IEnumerable<T> GetAll(string include = null);
        T GetDetail(Expression<Func<T, bool>> match,string include = null );
        T Delete(Expression<Func<T, bool>> match);
        bool Exist(Expression<Func<T, bool>> match);

    }
}
