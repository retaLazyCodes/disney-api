using System;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICharacterRepository CharacterRepository { get; }
        public IRepository<Genre> GenreRepository { get; }
        public IMovieRepository MovieRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}