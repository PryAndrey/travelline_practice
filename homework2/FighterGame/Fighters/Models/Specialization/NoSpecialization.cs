namespace Fighters.Models.Armors
{
    public class NoSpecialization : ISpecialization
    {
        public string Name { get; } = "NoSpecialization";
        public int Health { get; } = 0;
        public int Damage { get; } = 0;
        public int Armor { get; } = 0;
    }
}