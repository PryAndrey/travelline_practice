using Domain.Entities;

namespace Domain.Repositories;

public interface IPlayRepository
{
    IReadOnlyList<Play> GetAllPlays();

    void Save(Play play);

    void Update(Play play);

    void Delete( int id );
}
