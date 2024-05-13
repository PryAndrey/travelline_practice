namespace Domain.Entities;

public class Ticket
{
    public int Id { get; private init; }
    public int Price { get; private set; }
    public string RoomType { get; private set; }
    public int PlayId { get; private set; }
    public int PlaysNumber { get; private set; }
    public DateTime StartingDate { get; private init; }

    public Ticket(int price, string roomType, int playsNumber, DateTime startingDate)
    {
        if (string.IsNullOrEmpty(roomType))
        {
            throw new ArgumentException($"\"{nameof(roomType)}\" не может быть неопределенным или пустым.", nameof(roomType));
        }

        Price = price;
        RoomType = roomType;
        PlaysNumber = playsNumber;
        StartingDate = startingDate;
    }

    private Ticket()
    {
    }
}

