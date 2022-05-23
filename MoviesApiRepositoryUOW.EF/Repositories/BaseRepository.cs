using Microsoft.EntityFrameworkCore;
using MoviesApiRepositoryUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.EF.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) => _context = context;
        public T Add(T entity) 
        {
             _context.Add(entity);
            return entity;
         }

        public T Delete(Expression<Func<T, bool>> match)
        {
            var entity =_context.Set<T>().SingleOrDefault(match);
            _context.Remove(entity);
            return entity;
        }

        public  T GetDetail(Expression<Func<T,bool>> match,string include = null)
        {
            if(include == null)
                return _context.Set<T>().SingleOrDefault(match);
           return _context.Set<T>().Include(include).SingleOrDefault(match);
        }

        public IEnumerable<T> GetAll(string include = null)
        {
            if (include == null)
                return _context.Set<T>().ToList();
            return  _context.Set<T>().Include(include).ToList();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public bool Exist(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Any(match);
        }
    }
}
