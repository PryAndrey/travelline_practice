using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListPlayRepository : IPlayRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Play> _plays = new();

    public IReadOnlyList<Play> GetAllPlays()
    {
        return _plays;
    }

    public void Save( Play play )
    {
        _plays.Add( play );
    }

    public void Update( Play modifiedPlay )
    {
        Play play = _plays.FirstOrDefault( p => p.Id == modifiedPlay.Id );
        if ( play is null )
        {
            Save( modifiedPlay );
            return;
        }

        play.CopyFrom( modifiedPlay );
    }

    public void Delete( int id )
    {
        int index = _plays.FindIndex( p => p.Id == id );
        if ( index >= 0 )
        {
            _plays.RemoveAt( index );
        }
    }
}
