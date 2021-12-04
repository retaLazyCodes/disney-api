using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using SocialMedia.Core.QueryFilters;

namespace Disney.Core.Interfaces
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetCharacters(CharacterQueryFilter filters);
        Task<Character> GetCharacterById(int id);
        Task InsertCharacter(Character post);
        Task<bool> UpdateCharacter(Character post);
        Task<bool> DeleteCharacter(int id);
    }
}