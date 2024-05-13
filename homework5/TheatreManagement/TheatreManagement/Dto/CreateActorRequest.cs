namespace TheatreManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreateActorRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; init; }
}
