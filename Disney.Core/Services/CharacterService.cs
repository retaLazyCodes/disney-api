using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Character> GetCharacters(CharacterQueryFilter filters)
        {
            var characters = _unitOfWork.CharacterRepository.GetAll();

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
                
            }

            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return await _unitOfWork.CharacterRepository.GetById(id);
        }

        public async Task InsertCharacter(Character character)
        {
            await _unitOfWork.CharacterRepository.Add(character);
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