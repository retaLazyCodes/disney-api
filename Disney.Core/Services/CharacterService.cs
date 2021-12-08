using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using SocialMedia.Core.QueryFilters;

namespace Disney.Core.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Character>> GetCharacters(CharacterQueryFilter filters)
        {
            var characters = await _unitOfWork.CharacterRepository.GetAll();

            if (filters.Name != null)
            {
                characters = characters.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }

            if (filters.Age != null)
            {
                characters = characters.Where(x => x.Age == filters.Age);
            }

            if (filters.Movie != null)
            {
                characters = _unitOfWork.CharacterRepository.GetCharactersByMovie((int)filters.Movie);
            }

            return characters;
        }

        public async Task<CharacterWithMovies> GetCharacterById(int id)
        {
            return await _unitOfWork.CharacterRepository.GetCharacterDetailById(id);
        }

        public Character InsertCharacter(Character character, List<int> moviesIds)
        {
            return _unitOfWork.CharacterRepository.InsertCharacter(character, moviesIds);
        }

        public async Task<bool> UpdateCharacter(Character character)
        {
            await _unitOfWork.CharacterRepository.Update(character);
            return true;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            await _unitOfWork.CharacterRepository.Delete(id);
            return true;
        }
    }
}