namespace CarFactory.Models.CarEngine
{
    public class V12Engine : ICarEngine
    {
        public string Name { get; } = "V12Engine";
        public int MaxSpeed { get; } = 250;
        public int MaxGears { get; } = 9;
    }
}