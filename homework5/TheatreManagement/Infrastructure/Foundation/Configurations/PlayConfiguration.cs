using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Foundation.Configurations;

internal class PlayConfiguration : IEntityTypeConfiguration<Play>
{
    public void Configure(EntityTypeBuilder<Play> builder)
    {
        builder.ToTable(nameof(Play))
               .HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.StageDirector)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.StartDate)
               .IsRequired();

        builder.Property(p => p.EndDate)
               .IsRequired();

        builder.HasMany(p => p.Actors)
               .WithMany(a => a.Plays)
               .UsingEntity("ActorToPlay");

        builder.HasMany(p => p.Tickets)
               .WithOne(/*t => t.Play*/)
               .HasForeignKey(t => t.PlayId);

        builder.HasMany(p => p.Compositions)
               .WithMany(c => c.Plays)
               .UsingEntity("CompositionToPlay");
    }
}
