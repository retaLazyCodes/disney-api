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
        }
    }
}