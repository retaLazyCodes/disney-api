using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<GenreWithMovies> GetGenreById(int id);
        Task InsertGenre(Genre genre);
        Task<bool> UpdateGenre(Genre genre);
        Task<bool> DeleteGenre(int id);
    }
}