using Domain.Entities;

namespace Domain.Repositories;

public interface ITheaterRepository
{
    IReadOnlyList<Theater> GetAllTheaters();

    void Save(Theater theater);

    void Update(Theater theater);

    void Delete( int id );
}
