namespace CarFactory.Models.CarEngine
{
    public class V8Engine : ICarEngine
    {
        public string Name { get; } = "V8Engine";
        public int MaxSpeed { get; } = 180;
        public int MaxGears { get; } = 7;
    }
}