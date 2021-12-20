using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public Task<GenreWithMovies> GetGenreDetailById(int genreId);
    }
}