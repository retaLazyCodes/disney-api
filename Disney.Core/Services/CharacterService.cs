using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.CustomEntities;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Core.QueryFilters;
using Microsoft.Extensions.Options;

namespace Disney.Core.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public CharacterService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<PagedList<Character>> GetCharacters(CharacterQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 
                ? _paginationOptions.DefaultPageNumber 
                : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 
                ? _paginationOptions.DefaultPageSize 
                : filters.PageSize;
            
            var characters = await _unitOfWork.CharacterRepository.GetAll();

            if (filters.Movie != null)
            {
                characters = _unitOfWork.CharacterRepository.GetCharactersByMovie((int)filters.Movie);
            }

            if (filters.Name != null)
            {
                characters = characters.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            }

            if (filters.Age != null)
            {
                characters = characters.Where(x => x.Age == filters.Age);
            }

            var pagedCharacters =
                PagedList<Character>
                .Create(characters, filters.PageNumber, filters.PageSize);
            return pagedCharacters;
        }

        public async Task<CharacterWithMovies> GetCharacterById(int id)
        {
            return await _unitOfWork.CharacterRepository.GetCharacterDetailById(id);
        }

        public Character InsertCharacter(Character character, List<int> moviesIds)
        {
            return _unitOfWork.CharacterRepository.InsertCharacter(character, moviesIds);
        }

        public async Task<bool> UpdateCharacter(Character character, List<int> moviesIds)
        {
            var existingCharacter = await _unitOfWork.CharacterRepository.GetById(character.Id);
            if (existingCharacter != null)
            {
                await _unitOfWork.CharacterRepository.UpdateCharacter(character, moviesIds);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var existingCharacter = await _unitOfWork.CharacterRepository.GetById(id);
            if (existingCharacter != null)
            {
                await _unitOfWork.CharacterRepository.Delete(id);
                return true;
            }
            return false;
        }
    }
}