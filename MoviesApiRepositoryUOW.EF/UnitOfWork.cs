using MoviesApiRepositoryUOW.Core;
using MoviesApiRepositoryUOW.Core.Interfaces;
using MoviesApiRepositoryUOW.Core.Models;
using MoviesApiRepositoryUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.EF
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Genre> Genres { get; private set; }
        public IBaseRepository<Movie> Movies { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Genres = new BaseRepository<Genre>(_context);
            Movies = new BaseRepository<Movie>(_context);
        }

        public int Complete()=>
         _context.SaveChanges();
        

        public void Dispose()=>
             _context.Dispose();
        
    }
}
