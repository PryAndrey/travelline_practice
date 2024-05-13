namespace TheatreManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreatePlayRequest
{
    public string Name { get; set; }
    public string StageDirector { get; set; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}
