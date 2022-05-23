using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        public string Storyline { get; set; }

        public byte[] Poster { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}
