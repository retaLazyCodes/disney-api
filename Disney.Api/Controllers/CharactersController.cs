using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Api.Responses;
using Disney.Api.ViewModels;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Disney.Core.QueryFilters;
using System.Text.Json;
using Disney.Core.CustomEntities;
using Disney.Infrastructure.Interfaces;

namespace Disney.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CharactersController(ICharacterService characterService, IMapper mapper, IUriService uriService)
        {
            _characterService = characterService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all characters
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetCharacters))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseWithMeta<IEnumerable<CharacterViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCharacters([FromQuery] CharacterQueryFilter filters)
        {
            var characters = await _characterService.GetCharacters(filters);
            var characterViewModels = _mapper.Map<IEnumerable<CharacterViewModel>>(characters);

            var metadata = new Metadata()
            {
                TotalCount = characters.TotalCount,
                PageSize = characters.PageSize,
                CurrentPage = characters.CurrentPage,
                TotalPages = characters.TotalPages,
                HasNextPage = characters.HasNextPage,
                HasPreviousPage = characters.HasPreviousPage,
                NextPageUrl = _uriService.GetCharacterPaginationUri(filters, Url.RouteUrl(nameof(GetCharacters))).ToString(),
                PreviousPageUrl = _uriService.GetCharacterPaginationUri(filters, Url.RouteUrl(nameof(GetCharacters))).ToString()
            };
            var response =
                ResponseWithMeta<IEnumerable<CharacterViewModel>>
                    .CreateSuccessResult(characterViewModels, metadata);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(response);
        }

        /// <summary>
        /// Retrieve a character given an id
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationResult<CharacterWithMovies>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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

        /// <summary>
        /// Retrieve the inserted character
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationResult<CharacterDto>))]
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

        /// <summary>
        /// Return a true if the character was updated successful
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationResult<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCharacter(int id, CharacterDto characterDto)
        {
            var character = _mapper.Map<Character>(characterDto);
            character.Id = id;
            var result = await _characterService.UpdateCharacter(character, characterDto.MovieIds);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }

        /// <summary>
        /// Return a true if the character was deleted successful
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationResult<bool>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteCharacter(id);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }
    }
}