using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> GetCharacterById(int id);
        Task InsertCharacter(Character post);
        Task<bool> UpdateCharacter(Character post);
        Task<bool> DeleteCharacter(int id);
    }
}