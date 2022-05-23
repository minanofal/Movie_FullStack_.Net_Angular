using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApiRepositoryUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.EF.Configurations
{
    internal class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
       public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(250);

           
        }
    }
}
