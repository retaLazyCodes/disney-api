using System.Threading.Tasks;
using Disney.Core.CustomEntities;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;

namespace Disney.Core.Interfaces
{
    public interface IMovieService
    {
        Task<PagedList<Movie>> GetMovies(MovieQueryFilter filters);
        Task<MovieWithCharacters> GetMovieById(int id);
        Task InsertMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
    }
}