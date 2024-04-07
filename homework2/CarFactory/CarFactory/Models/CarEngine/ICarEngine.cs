namespace CarFactory.Models.CarEngine
{
    public interface ICarEngine
    {
        public string Name { get; }
        public int MaxSpeed { get; }
        public int MaxGears { get; }
    }
}