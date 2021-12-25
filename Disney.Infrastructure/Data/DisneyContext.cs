using Disney.Core.Entities;
using Disney.Infrastructure.Data.Configurations;
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
        public virtual DbSet<CharacterMovie> CharacterMovie { get; set; }
        public virtual DbSet<Security> Security { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfiguration(new CharacterMovieConfiguration());
        }

    }
}