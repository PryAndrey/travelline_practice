namespace Domain.Entities;

public class Composition
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Author { get; private set; }
    public string Type { get; private set; }
    public List<Play> Plays { get; private init; } = new List<Play>();

    public Composition(string name, string author, string type)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException($"\"{nameof(author)}\" не может быть неопределенным или пустым.", nameof(author));
        }

        if (string.IsNullOrEmpty(type))
        {
            throw new ArgumentException($"\"{nameof(type)}\" не может быть неопределенным или пустым.", nameof(type));
        }

        Name = name;
        Author = author;
        Type = type;
    }

    public Composition(int id, string name, string author, string type)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(author))
        {
            throw new ArgumentException($"\"{nameof(author)}\" не может быть неопределенным или пустым.", nameof(author));
        }

        if (string.IsNullOrEmpty(type))
        {
            throw new ArgumentException($"\"{nameof(type)}\" не может быть неопределенным или пустым.", nameof(type));
        }

        Id = id;
        Name = name;
        Author = author;
        Type = type;
    }

    private Composition()
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

    public void SetAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException($"'{nameof(author)}' cannot be null or whitespace.", nameof(author));
        }

        Author = author;
    }

    public void SetType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException($"'{nameof(type)}' cannot be null or whitespace.", nameof(type));
        }

        Type = type;
    }

    public void CopyFrom(Composition other)
    {
        SetName(other.Name);
        SetAuthor(other.Author);
        SetType(other.Type);
    }
}

