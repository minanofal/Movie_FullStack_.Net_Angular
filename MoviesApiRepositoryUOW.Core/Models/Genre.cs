using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
