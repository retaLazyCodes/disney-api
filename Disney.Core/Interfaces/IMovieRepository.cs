using System.Threading.Tasks;
using Disney.Core.DTOs;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public Task<MovieWithCharacters> GetMovieDetailById(int movieId);
    }
}