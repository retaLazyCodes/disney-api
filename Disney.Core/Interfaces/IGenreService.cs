using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        Task<Genre> GetGenreById(int id);
        Task InsertGenre(Genre genre);
        Task<bool> UpdateGenre(Genre genre);
        Task<bool> DeleteGenre(int id);
    }
}