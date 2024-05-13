using Domain.Entities;

namespace Domain.Repositories;

public interface ICompositionRepository
{
    IReadOnlyList<Composition> GetAllCompositions();

    void Save(Composition composition);

    void Update(Composition composition);

    void Delete( int id );
}
