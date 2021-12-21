using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.CustomEntities;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;

namespace Disney.Core.Interfaces
{
    public interface ICharacterService
    {
        Task<PagedList<Character>> GetCharacters(CharacterQueryFilter filters);
        Task<CharacterWithMovies> GetCharacterById(int id);
        Character InsertCharacter(Character character, List<int> moviesIds);
        Task<bool> UpdateCharacter(Character character, List<int> moviesIds);
        Task<bool> DeleteCharacter(int id);
    }
}