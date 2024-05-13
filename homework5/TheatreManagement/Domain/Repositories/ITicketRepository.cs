using Domain.Entities;

namespace Domain.Repositories;

public interface ITicketRepository
{
    IReadOnlyList<Ticket> GetAllTickets();

    void Save(Ticket ticket);

    void Delete( int id );
}
