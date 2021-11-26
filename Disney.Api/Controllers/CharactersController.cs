using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Core.Services;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _characterService.GetCharacters();
            var characterDto = _mapper.Map<IEnumerable<CharacterDto>>(characters);
            
            return Ok(characterDto);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _characterService.GetCharacterById(id);
            if (character != null)
            {
                return Ok(character);
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertCharacter(CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            await _characterService.InsertCharacter(character);

            characterDto = _mapper.Map<CharacterDto>(character);
            
            return  Ok(characterDto);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePost(int id, CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            character.Id = id;
            var result = await _characterService.UpdateCharacter(character);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _characterService.DeleteCharacter(id);
            return Ok(result);
        }
    }
}