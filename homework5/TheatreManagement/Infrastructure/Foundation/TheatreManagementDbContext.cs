using Infrastructure.Foundation.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Foundation;

public class TheatreManagementDbContext : DbContext
{
    public TheatreManagementDbContext( DbContextOptions options )
        : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration(new ActorConfiguration());
        modelBuilder.ApplyConfiguration(new CompositionConfiguration());
        modelBuilder.ApplyConfiguration(new PlayConfiguration());
        modelBuilder.ApplyConfiguration(new TheaterConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
    }
}
