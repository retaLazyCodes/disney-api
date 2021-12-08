using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces;

namespace Disney.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Movie>> GetMovies()
        {
            return _unitOfWork.MovieRepository.GetAll();
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