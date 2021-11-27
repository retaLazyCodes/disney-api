using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
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
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetMovies();
            var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
            
            return Ok(moviesDto);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertMovie(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieService.InsertMovie(movie);

            movieDto = _mapper.Map<MovieDto>(movie);
            
            return Ok(movieDto);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            movie.Id = id;
            var result = await _movieService.UpdateMovie(movie);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovie(id);
            return Ok(result);
        }
    }
}