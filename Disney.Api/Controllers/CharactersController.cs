using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Api.Responses;
using Disney.Api.ViewModels;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Disney.Core.QueryFilters;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters([FromQuery] CharacterQueryFilter filters)
        {
            var characters = await _characterService.GetCharacters(filters);
            var characterViewModels = _mapper.Map<IEnumerable<CharacterViewModel>>(characters);
            var response =
                OperationResult<IEnumerable<CharacterViewModel>>.CreateSuccessResult(characterViewModels);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _characterService.GetCharacterById(id);
            if (character != null)
            {
                var response =
                    OperationResult<CharacterWithMovies>.CreateSuccessResult(character);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertCharacter(CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            _characterService.InsertCharacter(character, characterDto.MovieIds);

            characterDto = _mapper.Map<CharacterDto>(character);
            var response =
                OperationResult<CharacterDto>.CreateSuccessResult(characterDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCharacter(int id, CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            character.Id = id;
            var result = await _characterService.UpdateCharacter(character, characterDto.MovieIds);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacter(id);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }
    }
}