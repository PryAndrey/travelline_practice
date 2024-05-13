using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListActorRepository : IActorRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Actor> _actors = new();

    public IReadOnlyList<Actor> GetAllActors()
    {
        return _actors;
    }

    public void Save( Actor actor )
    {
        _actors.Add( actor );
    }

    public void Update( Actor modifiedActor )
    {
        Actor actor = _actors.FirstOrDefault( a => a.Id == modifiedActor.Id );
        if ( actor is null )
        {
            Save( modifiedActor );
            return;
        }

        actor.CopyFrom( modifiedActor );
    }

    public void Delete( int id )
    {
        int index = _actors.FindIndex( a => a.Id == id );
        if ( index >= 0 )
        {
            _actors.RemoveAt( index );
        }
    }
}
