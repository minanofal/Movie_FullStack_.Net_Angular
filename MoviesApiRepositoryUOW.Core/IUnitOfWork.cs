using MoviesApiRepositoryUOW.Core.Interfaces;
using MoviesApiRepositoryUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Genre> Genres { get; }
        IBaseRepository<Movie> Movies { get; }

        int Complete();
    }
}
