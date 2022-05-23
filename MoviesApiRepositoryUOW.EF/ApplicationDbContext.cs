using Microsoft.EntityFrameworkCore;
using MoviesApiRepositoryUOW.Core.Models;
using MoviesApiRepositoryUOW.EF.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new GenreEntityTypeConfiguration().Configure(modelBuilder.Entity<Genre>());
            new MovieEntityTypeConfiguration().Configure(modelBuilder.Entity<Movie>());
        }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}
