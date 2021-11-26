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
        
        [HttpPost]
        public async Task<IActionResult> InsertCharacter(CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            await _characterService.InsertCharacter(character);

            characterDto = _mapper.Map<CharacterDto>(character);
            
            return  Ok(characterDto);
        }
    }
}