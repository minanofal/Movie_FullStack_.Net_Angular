using AutoMapper;
using MoviesApiRepositoryUOW.Core.Dto;
using MoviesApiRepositoryUOW.Core.Models;

namespace MoviesApiRepositoryUOW.api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreFormDto>().ReverseMap();

            CreateMap<MovieFormDto, Movie>().
                ForMember(src => src.Poster, opt => opt.Ignore());


        }
    }
}
