using Disney.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Disney.Infrastructure.Data.Configurations
{
    public class CharacterMovieConfiguration : IEntityTypeConfiguration<CharacterMovie>
    {
        public void Configure(EntityTypeBuilder<CharacterMovie> builder)
        {
            builder.ToTable("CharacterMovie");

            builder.HasKey(cm => new {cm.CharacterId, cm.MovieId});

            builder
                .HasOne(cm => cm.Character)
                .WithMany(c => c.Movies)
                .HasForeignKey(cm => cm.CharacterId);

            builder
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.Characters)
                .HasForeignKey(cm => cm.MovieId);
        }
    }
}