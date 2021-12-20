using System;
using System.Threading.Tasks;

namespace Disney.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICharacterRepository CharacterRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IMovieRepository MovieRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}