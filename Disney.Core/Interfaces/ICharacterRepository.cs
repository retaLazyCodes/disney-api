using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface ICharacterRepository : IRepository<Character>
    {
        public IEnumerable<Character> GetCharactersByMovie(int movieId);
        public Task<CharacterWithMovies> GetCharacterDetailById(int characterId);
        public Character InsertCharacter(Character character, List<int> moviesIds);
        public Task<bool> UpdateCharacter(Character character, List<int> moviesIds);
    }
}