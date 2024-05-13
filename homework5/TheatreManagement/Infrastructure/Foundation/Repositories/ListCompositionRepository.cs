using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Foundation.Repositories;

public class ListCompositionRepository : ICompositionRepository
{
    // создается один раз за время жизни программы(до перезапуска)
    private readonly static List<Composition> _compositions = new();

    public IReadOnlyList<Composition> GetAllCompositions()
    {
        return _compositions;
    }

    public void Save( Composition composition )
    {
        _compositions.Add( composition );
    }

    public void Update( Composition modifiedComposition )
    {
        Composition composition = _compositions.FirstOrDefault( c => c.Id == modifiedComposition.Id );
        if ( composition is null )
        {
            Save( modifiedComposition );
            return;
        }

        composition.CopyFrom( modifiedComposition );
    }

    public void Delete( int id )
    {
        int index = _compositions.FindIndex( c => c.Id == id );
        if ( index >= 0 )
        {
            _compositions.RemoveAt( index );
        }
    }
}
