using Disney.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure.Data
{
    public class DisneyContext : DbContext
    {
        public DisneyContext()
        {
            
        }

        public DisneyContext(DbContextOptions<DisneyContext> options)
            : base(options)
        {
            
        }
        
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}