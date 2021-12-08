

using Disney.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Disney.Infrastructure.Data.Configurations
{
    public class CharacterMovieConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity<CharacterMovie>
                (cm => cm.HasOne<Movie>().WithMany(),
                    cm => cm.HasOne<Character>().WithMany());
        }

    }
}