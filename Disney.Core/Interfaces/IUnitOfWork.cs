using System;
using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Character> CharacterRepository { get; }
        public IRepository<Genre> GenreRepository { get; }
        public IRepository<Movie> MovieRepository { get; }
        
        void SaveChanges();
        Task SaveChangesAsync();
    }
}