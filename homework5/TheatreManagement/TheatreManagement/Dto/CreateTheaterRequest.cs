namespace TheatreManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreateTheaterRequest
{
    public string Name { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string Director { get; set; }
    public DateTime OpeningDate { get; init; }
}
