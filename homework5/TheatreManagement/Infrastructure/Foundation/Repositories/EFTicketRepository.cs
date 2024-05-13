using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class EFTicketRepository : ITicketRepository
{
    private readonly TheatreManagementDbContext _dbContext;

    public EFTicketRepository( TheatreManagementDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Ticket> GetAllTickets()
    {
        return _dbContext.Set<Ticket>().ToList();
    }

    public void Save(Ticket ticket )
    {
        _dbContext.Set<Ticket>().Add( ticket );
        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        Ticket existingTicket = GetTicketById( id );
        _dbContext.Set<Ticket>().Remove( existingTicket );
        _dbContext.SaveChanges();
    }

    private Ticket GetTicketById( int id )
    {
        return _dbContext.Set<Ticket>().FirstOrDefault( t => t.Id == id );
    }
}
