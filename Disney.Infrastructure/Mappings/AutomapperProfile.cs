using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Security, SecurityDto>();
            CreateMap<SecurityDto, Security>();
        }
    }
}