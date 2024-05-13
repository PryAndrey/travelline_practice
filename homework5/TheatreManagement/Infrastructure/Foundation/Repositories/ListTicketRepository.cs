using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListTicketRepository : ITicketRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Ticket> _tickets = new();

    public IReadOnlyList<Ticket> GetAllTickets()
    {
        return _tickets;
    }

    public void Save( Ticket ticket )
    {
        _tickets.Add( ticket );
    }

    public void Delete( int id )
    {
        int index = _tickets.FindIndex( t => t.Id == id );
        if ( index >= 0 )
        {
            _tickets.RemoveAt( index );
        }
    }
}
