using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Foundation.Configurations;

internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(nameof(Ticket))
               .HasKey(t => t.Id);

        builder.Property(t => t.Price)
               .IsRequired();

        builder.Property(t => t.RoomType)
                .HasMaxLength(100)
                .IsRequired();

        builder.Property(t => t.PlaysNumber)
               .IsRequired();

        builder.Property(t => t.PlayId)
               .IsRequired();

        builder.Property(t => t.StartingDate)
               .IsRequired();

    }
}
