namespace TheatreManagement.Dto;

// класс-dto
// data transfer object
// идея в том, что мы изолируем предметную область от внешнего мира
public class CreateCompositionRequest
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Type { get; set; }
}
