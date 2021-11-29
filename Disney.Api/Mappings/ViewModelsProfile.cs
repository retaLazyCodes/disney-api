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
            CreateMap<Movie, MovieViewModel>();
        }
    }
}