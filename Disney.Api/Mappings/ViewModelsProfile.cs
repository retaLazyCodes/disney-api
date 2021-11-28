using AutoMapper;
using Disney.Api.ViewModels;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Api.Mappings
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<Character, CharacterViewModel>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}