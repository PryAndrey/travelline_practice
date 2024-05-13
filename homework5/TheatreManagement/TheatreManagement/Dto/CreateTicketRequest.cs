namespace TheatreManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreateTicketRequest
{
    public int Price { get; set; }
    public string RoomType { get; set; }
    public int PlaysNumber { get; set; }
    public DateTime StartingDate { get; init; }
}
