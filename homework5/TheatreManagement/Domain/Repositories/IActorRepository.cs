using Domain.Entities;

namespace Domain.Repositories;

public interface IActorRepository
{
    IReadOnlyList<Actor> GetAllActors();

    void Save(Actor actor);

    void Update(Actor actor);

    void Delete( int id );
}
