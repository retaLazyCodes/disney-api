using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Api.Responses;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genreService.GetGenres();
            var genresDto = _mapper.Map<IEnumerable<GenreDto>>(genres);
            var response =
                    OperationResult<IEnumerable<GenreDto>>.CreateSuccessResult(genresDto);
            return Ok(response);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreById(id);
            if (genre != null)
            {
                var response = OperationResult<GenreWithMovies>.CreateSuccessResult(genre);
                return Ok(response);
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertGenre(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreService.InsertGenre(genre);

            genreDto = _mapper.Map<GenreDto>(genre);
            var response = OperationResult<GenreDto>.CreateSuccessResult(genreDto);
            return Ok(response);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGenre(int id, GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            genre.Id = id;
            var result = await _genreService.UpdateGenre(genre);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _genreService.DeleteGenre(id);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }
    }
}