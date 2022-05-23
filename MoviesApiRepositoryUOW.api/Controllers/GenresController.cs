using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesApiRepositoryUOW.Core;
using MoviesApiRepositoryUOW.Core.Dto;
using MoviesApiRepositoryUOW.Core.Models;

namespace MoviesApiRepositoryUOW.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitofwork; 

        public GenresController(IUnitOfWork unitOfwork , IMapper mapper)
        {
            _unitofwork = unitOfwork;
            _mapper = mapper;
        }
        [HttpGet("allGeners")]
        public async Task<IActionResult> GetAll()
        {
            var genres = _unitofwork.Genres.GetAll();
            var data = _mapper.Map<IEnumerable<GenreDto>>(genres);
            return Ok(data);
        }
        [HttpGet("GenreMovies/{id}")]
        public async Task<IActionResult> GetGenreMovies([FromRoute]int id)
        {
            var genres = _unitofwork.Genres.GetDetail(G=>G.Id == id ,"Movies");
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(genres.Movies);
            return Ok(data);
        }

        [HttpPost("CreateGenre")]
        public async Task<IActionResult> CreateGenre([FromBody] GenreFormDto genre)
        {
            if (genre == null)
                return BadRequest("The Data Required");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "Something went wrong");
                return BadRequest(genre);
            }
            var data = _mapper.Map<Genre>(genre);
            _unitofwork.Genres.Add(data);
            _unitofwork.Complete();

            var returngenre = _mapper.Map<GenreDto>(data);
            return Ok(returngenre);

        }
        [HttpPut("Update/{id}")]

        public async Task<IActionResult> UpdateGenre(int id, [FromBody] GenreFormDto genre)
        {
            if (!_unitofwork.Genres.Exist(x => x.Id == id))
                return NotFound($"No Genre with id = {id}");
            if (genre == null)
                return BadRequest("The Data Required");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "Something went wrong");
                return BadRequest(genre);
            }
            
            var genres = _unitofwork.Genres.GetDetail(G => G.Id == id);
            genres .Name= genre.Name;
            _unitofwork.Genres.Update(genres);
            _unitofwork.Complete();

            var returngenre = _mapper.Map<GenreDto>(genres);
            return Ok(returngenre);

        }
        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> UpdateDelete(int id)
        {
            if (!_unitofwork.Genres.Exist(x => x.Id == id))
                return NotFound($"No Genre with id = {id}");
            var genres= _unitofwork.Genres.Delete(G=>G.Id == id);
            _unitofwork.Complete();
            var returngenre = _mapper.Map<GenreDto>(genres);
            return Ok(returngenre);

        }

    }
}
