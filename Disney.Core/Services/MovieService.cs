using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Movie>> GetMovies(MovieQueryFilter filters)
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

                if (filters.Order == "ASC") {
                    movies = from m in movies
                        orderby m.Title
                        select m;
                }
                else if (filters.Order == "DESC") {
                    movies = from m in movies
                        orderby m.Title descending
                        select m;
                }
            }
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _unitOfWork.MovieRepository.GetById(id);
        }

        public async Task InsertMovie(Movie genre)
        {
            await _unitOfWork.MovieRepository.Add(genre);
        }

        public async Task<bool> UpdateMovie(Movie genre)
        {
            await _unitOfWork.MovieRepository.Update(genre);
            return true;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            await _unitOfWork.MovieRepository.Delete(id);
            return true;
        }
    }
}