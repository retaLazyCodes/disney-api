using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DisneyContext context) : base(context)
        {
        }

        public async Task<MovieWithCharacters> GetMovieDetailById(int movieId)
        {
            var movie = await _context.Movies
                .Include(m => m.Characters)
                .FirstOrDefaultAsync(x => x.Id == movieId);

            if (movie == null)
            {
                return null;
            }

            var characterList = new List<CharacterWithoutMovies>();

            foreach (var character in movie.Characters)
            {
                var characterDto = new CharacterWithoutMovies()
                {
                    Id = character.Id,
                    Name = character.Name,
                    Image = character.Image,
                    Age = character.Age,
                    Weight = character.Weight,
                    History = character.History
                };

                characterList.Add(characterDto);
            }

            var movieWithCharacters = new MovieWithCharacters()
            {
                Id = movie.Id,
                Title = movie.Title,
                Image = movie.Image,
                ReleaseDate = movie.ReleaseDate,
                Score = movie.Score,
                GenreId = movie.GenreId,
                Characters = characterList
            };

            return movieWithCharacters;
        }
    }
}