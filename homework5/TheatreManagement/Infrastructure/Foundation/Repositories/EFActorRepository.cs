using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class EFActorRepository : IActorRepository
{
    private readonly TheatreManagementDbContext _dbContext;

    public EFActorRepository( TheatreManagementDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Actor> GetAllActors()
    {
        return _dbContext.Set<Actor>().ToList();
    }

    public void Save(Actor actor )
    {
        _dbContext.Set<Actor>().Add( actor );
        _dbContext.SaveChanges();
    }

    public void Update(Actor actor )
    {
        Actor existingActor = GetActorById( actor.Id );
        existingActor.CopyFrom( actor );
        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        Actor existingActor = GetActorById( id );
        _dbContext.Set<Actor>().Remove( existingActor );
        _dbContext.SaveChanges();
    }

    private Actor GetActorById( int id )
    {
        return _dbContext.Set<Actor>().FirstOrDefault( a => a.Id == id );
    }
}
