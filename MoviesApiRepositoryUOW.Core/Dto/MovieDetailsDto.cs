using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Dto
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        public string Storyline { get; set; }

        public byte[] Poster { get; set; }

        public string GenreName { get; set; }

        public byte GenreId { get; set; }

    }
}
