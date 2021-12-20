using System.Threading.Tasks;
using Disney.Core.Entities;
using Disney.Core.Interfaces;
using Disney.Infrastructure.Data;

namespace Disney.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DisneyContext _context;
        private ICharacterRepository _characterRepository;
        private IGenreRepository _genreRepository;
        private IMovieRepository _movieRepository;

        public UnitOfWork(DisneyContext context)
        {
            _context = context;
        }

        public ICharacterRepository CharacterRepository => 
            _characterRepository ?? 
            new CharacterRepository(_context);
        
        public IGenreRepository GenreRepository => 
            _genreRepository ?? 
            new GenreRepository(_context);
        
        public IMovieRepository MovieRepository => 
            _movieRepository ?? 
            new MovieRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}