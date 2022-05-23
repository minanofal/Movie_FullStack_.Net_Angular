using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Dto
{
    public class MovieUpdateDto
    {
        [MaxLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        public string Storyline { get; set; }

        public IFormFile? Poster { get; set; }

        public byte GenreId { get; set; }
    }
}
