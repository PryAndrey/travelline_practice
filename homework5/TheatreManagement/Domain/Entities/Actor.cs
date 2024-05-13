namespace Domain.Entities;

public class Actor
{
    public int Id { get; private init; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime DateOfBirth { get; private init; }
    public List<Play> Plays { get; set; } = new List<Play>() {};

    public string FullName => $"{Surname} {Name}";

    public Actor(string name, string surname, string phoneNumber, DateTime dateOfBirth)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException($"\"{nameof(surname)}\" не может быть неопределенным или пустым.", nameof(surname));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException($"\"{nameof(phoneNumber)}\" не может быть неопределенным или пустым.", nameof(phoneNumber));
        }

        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public Actor(int id, string name, string surname, string phoneNumber)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
        }

        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException($"\"{nameof(surname)}\" не может быть неопределенным или пустым.", nameof(surname));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException($"\"{nameof(phoneNumber)}\" не может быть неопределенным или пустым.", nameof(phoneNumber));
        }

        Id = id;
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
    }

    private Actor()
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

    public void SetSurname(string surname)
    {
        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException($"'{nameof(surname)}' cannot be null or whitespace.", nameof(surname));
        }

        Surname = surname;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or whitespace.", nameof(phoneNumber));
        }

        PhoneNumber = phoneNumber;
    }

    public void CopyFrom(Actor other)
    {
        SetName(other.Name);
        SetSurname(other.Surname);
        SetPhoneNumber(other.PhoneNumber);
    }
}

