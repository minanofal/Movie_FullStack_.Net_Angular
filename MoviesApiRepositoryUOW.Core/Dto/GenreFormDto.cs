using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApiRepositoryUOW.Core.Dto
{
    public class GenreFormDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
