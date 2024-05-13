using Domain;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListTheaterRepository : ITheaterRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Theater> _theaters = new();

    public IReadOnlyList<Theater> GetAllTheaters()
    {
        return _theaters;
    }

    public void Save( Theater theater)
    {
        _theaters.Add(theater);
    }

    public void Update( Theater modifiedTheater )
    {
        Theater theater = _theaters.FirstOrDefault( t => t.Id == modifiedTheater.Id );
        if (theater is null )
        {
            Save( modifiedTheater );
            return;
        }

        theater.CopyFrom( modifiedTheater );
    }

    public void Delete( int id )
    {
        int index = _theaters.FindIndex( t => t.Id == id );
        if ( index >= 0 )
        {
            _theaters.RemoveAt( index );
        }
    }
}
