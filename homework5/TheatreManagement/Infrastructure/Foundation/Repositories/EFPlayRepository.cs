using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class EFPlayRepository : IPlayRepository
{
    private readonly TheatreManagementDbContext _dbContext;

    public EFPlayRepository( TheatreManagementDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Play> GetAllPlays()
    {
        return _dbContext.Set<Play>().ToList();
    }

    public void Save(Play play )
    {
        _dbContext.Set<Play>().Add( play );
        _dbContext.SaveChanges();
    }

    public void Update(Play play )
    {
        Play existingPlay = GetPlayById( play.Id );
        existingPlay.CopyFrom( play );
        _dbContext.SaveChanges();
    }

    public void Delete( int id )
    {
        Play existingPlay = GetPlayById( id );
        _dbContext.Set<Play>().Remove( existingPlay );
        _dbContext.SaveChanges();
    }

    private Play GetPlayById( int id )
    {
        return _dbContext.Set<Play>().FirstOrDefault( p => p.Id == id );
    }
}
