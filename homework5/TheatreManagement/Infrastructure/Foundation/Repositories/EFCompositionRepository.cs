using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class EFCompositionRepository : ICompositionRepository
{
    private readonly TheatreManagementDbContext _dbContext;

    public EFCompositionRepository( TheatreManagementDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Composition> GetAllCompositions()
    {
        return _dbContext.Set<Composition>().ToList();
    }

    public void Save(Composition composition )
    {
        _dbContext.Set<Composition>().Add( composition );
        _dbContext.SaveChanges();
    }

    public void Update(Composition composition )
    {
        Composition existingComposition = GetCompositionById( composition.Id );
        existingComposition.CopyFrom( composition );
        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        Composition existingComposition = GetCompositionById( id );
        _dbContext.Set<Composition>().Remove( existingComposition );
        _dbContext.SaveChanges();
    }

    private Composition GetCompositionById( int id )
    {
        return _dbContext.Set<Composition>().FirstOrDefault( c => c.Id == id );
    }
}
