using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces;

namespace Disney.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _unitOfWork.GenreRepository.GetAll();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _unitOfWork.GenreRepository.GetById(id);
        }

        public async Task InsertGenre(Genre genre)
        {
            await _unitOfWork.GenreRepository.Add(genre);
        }

        public async Task<bool> UpdateGenre(Genre genre)
        {
            await _unitOfWork.GenreRepository.Update(genre);
            return true;
        }

        public async Task<bool> DeleteGenre(int id)
        {
            await _unitOfWork.GenreRepository.Delete(id);
            return true;
        }
    }
}