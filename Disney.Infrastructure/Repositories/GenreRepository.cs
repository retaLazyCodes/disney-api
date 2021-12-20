using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DisneyContext context) : base(context)
        {
        }

        public async Task<GenreWithMovies> GetGenreDetailById(int genreId)
        {
            var genres = await _context.Genres
                .Include(g => g.Movies)
                .FirstOrDefaultAsync(x => x.Id == genreId);

            if (genres == null)
            {
                return null;
            }

            var movieList = new List<MovieDto>();

            foreach (var movie in genres.Movies)
            {
                var movieDto = new MovieDto()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Image = movie.Image,
                    ReleaseDate = movie.ReleaseDate,
                    Score = movie.Score,
                    GenreId = movie.GenreId
                };

                movieList.Add(movieDto);
            }

            var genreWithMovies = new GenreWithMovies()
            {
                Id = genres.Id,
                Name = genres.Name,
                Image = genres.Image,
                Movies = movieList
            };

            return genreWithMovies;
        }
    }
}