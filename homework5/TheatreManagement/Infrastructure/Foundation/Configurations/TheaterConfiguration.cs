using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Foundation.Configurations;

internal class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure(EntityTypeBuilder<Theater> builder)
    {
        builder.ToTable(nameof(Theater))
               .HasKey(t => t.Id);

        builder.Property(t => t.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(t => t.Adress)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(t => t.PhoneNumber)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(t => t.Director)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(t => t.OpeningDate)
               .IsRequired();

        builder.HasMany(t => t.Plays)
               .WithOne(/*p => p.Theater*/)
               .HasForeignKey(p => p.TheaterId);
    }
}
