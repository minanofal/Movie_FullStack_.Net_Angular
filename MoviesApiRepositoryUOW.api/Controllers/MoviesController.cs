using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApiRepositoryUOW.Core;
using MoviesApiRepositoryUOW.Core.Const;
using MoviesApiRepositoryUOW.Core.Dto;
using MoviesApiRepositoryUOW.Core.Models;
using MoviesApiRepositoryUOW.EF;

namespace MoviesApiRepositoryUOW.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly  IUnitOfWork _unitofwork;
        public MoviesController(IUnitOfWork unitofwork , IMapper mapper)
        {
           _unitofwork = unitofwork;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var movies = _unitofwork.Movies.GetAll("Genre");
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);

            return Ok(data);
        }
        [HttpGet("GitMovieDetail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var m = _unitofwork.Movies.GetDetail(M=>M.Id ==id,"Genre");
            var da = _mapper.Map<MovieDetailsDto>(m);
            return Ok(da);
           
        }
        [HttpPost("CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromForm] MovieFormDto movie)
        {
            if (movie == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!ImageConstants.ImageExtention.Contains(Path.GetExtension(movie.Poster.FileName).ToLower()))
                return BadRequest(".png and .jpg Images only");
            if (ImageConstants.MaxLength < movie.Poster.Length)
                return BadRequest("max 1mg");
            using var datastream = new MemoryStream();
            movie.Poster.CopyTo(datastream);
            var data = _mapper.Map<Movie>(movie);
            data.Poster = datastream.ToArray();

            _unitofwork.Movies.Add(data);
            _unitofwork.Complete(); 
            return Ok(data);

        }
        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie([FromForm] MovieUpdateDto movie, int id)
        {
            if(id==null)
                return BadRequest();
            if (!_unitofwork.Movies.Exist(x => x.Id == id))
                return NotFound($"No movie with id {id}");
            if (movie == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _unitofwork.Movies.GetDetail(x => x.Id == id);
            if (movie.Poster != null)
            {
                if (!ImageConstants.ImageExtention.Contains(Path.GetExtension(movie.Poster.FileName).ToLower()))
                    return BadRequest(".png and .jpg Images only");
                if (ImageConstants.MaxLength < movie.Poster.Length)
                    return BadRequest("max 1mg");
                using var datastream = new MemoryStream();
                movie.Poster.CopyTo(datastream);
                data.Poster = datastream.ToArray();
            }
          
            data.Title = movie.Title;
            data.Storyline = movie.Storyline;
            data.Rate   = movie.Rate;
            data.GenreId= movie.GenreId;
            data.Year = movie.Year;
            _unitofwork.Movies.Update(data);
            _unitofwork.Complete();
            return Ok(data);

        }
        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie( int id)
        {
            if (id == null)
                return BadRequest();
            if (!_unitofwork.Movies.Exist(x => x.Id == id))
                return NotFound($"No movie with id {id}");
         
           var movie= _unitofwork.Movies.Delete(x=>x.Id == id);
            _unitofwork.Complete();
            return Ok(movie);

        }
    }
}
