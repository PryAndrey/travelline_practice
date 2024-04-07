namespace CarFactory.Models.CarEngine
{
    public class V6Engine : ICarEngine
    {
        public string Name { get; } = "V6Engine";
        public int MaxSpeed { get; } = 140;
        public int MaxGears { get; } = 6;
    }
}