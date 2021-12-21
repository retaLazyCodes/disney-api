using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Api.Responses;
using Disney.Api.ViewModels;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Core.QueryFilters;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] MovieQueryFilter filters)
        {
            var movies = await _movieService.GetMovies(filters);
            var movieViewModels = _mapper.Map<IEnumerable<MovieViewModel>>(movies);
            var response =
                OperationResult<IEnumerable<MovieViewModel>>.CreateSuccessResult(movieViewModels);

            var metadata = new
            {
                movies.TotalCount,
                movies.PageSize,
                movies.CurrentPage,
                movies.TotalPages,
                movies.HasNextPage,
                movies.HasPreviousPage
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie != null)
            {
                var response =
                    OperationResult<MovieWithCharacters>.CreateSuccessResult(movie);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieService.InsertMovie(movie);

            movieDto = _mapper.Map<MovieDto>(movie);
            var response = OperationResult<MovieDto>.CreateSuccessResult(movieDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            movie.Id = id;
            var result = await _movieService.UpdateMovie(movie);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovie(id);
            var response = OperationResult<bool>.CreateSuccessResult(result);
            return Ok(response);
        }
    }
}