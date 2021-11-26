using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces;

namespace Disney.Core.Services
{
    public class CharacterService : Interfaces.ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _unitOfWork.CharacterRepository.GetAll();
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