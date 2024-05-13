using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Foundation.Configurations;

internal class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure(EntityTypeBuilder<Composition> builder)
    {
        builder.ToTable(nameof(Composition))
               .HasKey(t => t.Id);

        builder.Property(t => t.Name)
               .HasMaxLength(100).IsRequired();

        builder.Property(t => t.Author)
               .HasMaxLength(100).IsRequired();

        builder.Property(t => t.Type)
               .HasMaxLength(100).IsRequired();
    }
}
