namespace Domain.Entities;

public class Theater
{

    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Adress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Director { get; private set; }
    public DateTime OpeningDate { get; private init; }
    public List<Play> Plays { get; set; } = new List<Play>();

    public Theater(string name, string adress, string phoneNumber, string director, DateTime openingDate)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(adress))
        {
            throw new ArgumentException($"\"{nameof(adress)}\" не может быть неопределенным или пустым.", nameof(adress));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException($"\"{nameof(phoneNumber)}\" не может быть неопределенным или пустым.", nameof(phoneNumber));
        }

        if (string.IsNullOrEmpty(director))
        {
            throw new ArgumentException($"\"{nameof(director)}\" не может быть неопределенным или пустым.", nameof(director));
        }

        Name = name;
        Adress = adress;
        PhoneNumber = phoneNumber;
        Director = director;
        OpeningDate = openingDate;
    }

    public Theater(int id, string name, string phoneNumber, string director)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException($"\"{nameof(phoneNumber)}\" не может быть неопределенным или пустым.", nameof(phoneNumber));
        }

        if (string.IsNullOrEmpty(director))
        {
            throw new ArgumentException($"\"{nameof(director)}\" не может быть неопределенным или пустым.", nameof(director));
        }

        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Director = director;
    }

    private Theater()
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

    public void SetPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or whitespace.", nameof(phoneNumber));
        }

        PhoneNumber = phoneNumber;
    }

    public void SetDirector(string director)
    {
        if (string.IsNullOrWhiteSpace(director))
        {
            throw new ArgumentException($"'{nameof(director)}' cannot be null or whitespace.", nameof(director));
        }

        Director = director;
    }

    public void CopyFrom(Theater other)
    {
        SetName(other.Name);
        SetPhoneNumber(other.PhoneNumber);
        SetDirector(other.Director);
    }
}

