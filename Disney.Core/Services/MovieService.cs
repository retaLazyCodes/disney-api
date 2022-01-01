using System.Linq;
using System.Threading.Tasks;
using Disney.Core.CustomEntities;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Core.QueryFilters;

namespace Disney.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<Movie>> GetMovies(MovieQueryFilter filters)
        {
            var movies = await _unitOfWork.MovieRepository.GetAll();

            if (filters.Title != null)
            {
                movies = movies.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));
            }

            if (filters.Genre != null)
            {
                movies = movies.Where(x => x.GenreId == filters.Genre);
            }

            if (filters.Order != null)
            {
                filters.Order = filters.Order.ToUpper();

                if (filters.Order == "ASC")
                {
                    movies = from m in movies
                             orderby m.Title
                             select m;
                }
                else if (filters.Order == "DESC")
                {
                    movies = from m in movies
                             orderby m.Title descending
                             select m;
                }
            }

            var pagedMovies =
                PagedList<Movie>
                .Create(movies, filters.PageNumber, filters.PageSize);
            return pagedMovies;
        }

        public async Task<MovieWithCharacters> GetMovieById(int id)
        {
            return await _unitOfWork.MovieRepository.GetMovieDetailById(id);
        }

        public async Task InsertMovie(Movie movie)
        {
            await _unitOfWork.MovieRepository.Add(movie);
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var existingGenre = await _unitOfWork.MovieRepository.GetById(movie.Id);
            if (existingGenre != null)
            {
                await _unitOfWork.MovieRepository.Update(movie);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var existingGenre = await _unitOfWork.MovieRepository.GetById(id);
            if (existingGenre != null)
            {
                await _unitOfWork.MovieRepository.Delete(id);
                return true;
            }
            return false;
        }
    }
}