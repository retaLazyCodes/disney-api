using System.Collections.Generic;
using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;

namespace Disney.Core.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies(MovieQueryFilter filters);
        Task<Movie> GetMovieById(int id);
        Task InsertMovie(Movie movie);
        Task<bool> UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(int id);
    }
}