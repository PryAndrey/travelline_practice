using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Foundation.Configurations;

internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        //Установили связь между таблицей и сущностью
        //Установили PK
        builder.ToTable(nameof(Actor))
               .HasKey(a => a.Id);

        //IsRequired(false); - maby null
        builder.Property(a => a.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(a => a.Surname)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(a => a.PhoneNumber)
               .HasMaxLength(50)
               .IsRequired();

        //datetime2 - тип если что на далекое будущее)
        builder.Property(a => a.DateOfBirth)
               .IsRequired();

        //Иначе все возьмет
        builder.Ignore(a => a.FullName);
    }
}

