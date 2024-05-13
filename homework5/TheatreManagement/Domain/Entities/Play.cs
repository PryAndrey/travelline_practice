namespace Domain.Entities;

public class Play
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string StageDirector { get; private set; }
    public int TheaterId { get; private set; }
    public DateTime StartDate { get; private init; }
    public DateTime EndDate { get; private init; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    public List<Actor> Actors { get; set; } = new List<Actor>();
    public List<Composition> Compositions { get; private init; } = new List<Composition>();

    public Play(string name, string stageDirector, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(stageDirector))
        {
            throw new ArgumentException($"\"{nameof(stageDirector)}\" не может быть неопределенным или пустым.", nameof(stageDirector));
        }

        Name = name;
        StageDirector = stageDirector;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Play(int id, string name, string stageDirector)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(stageDirector))
        {
            throw new ArgumentException($"\"{nameof(stageDirector)}\" не может быть неопределенным или пустым.", nameof(stageDirector));
        }

        Id = id;
        Name = name;
        StageDirector = stageDirector;
    }

    private Play()
    {
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    public void SetStageDirector(string stageDirector)
    {
        if (string.IsNullOrWhiteSpace(stageDirector))
        {
            throw new ArgumentException($"'{nameof(stageDirector)}' cannot be null or whitespace.", nameof(stageDirector));
        }

        StageDirector = stageDirector;
    }

    public void CopyFrom(Play other)
    {
        SetName(other.Name);
        SetStageDirector(other.StageDirector);
    }

}
