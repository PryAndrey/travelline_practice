namespace Fighters.Models.Armors
{
    public class Mercenary : ISpecialization
    {
        public string Name { get; } = "Mercenary";
        public int Health { get; } = 10;
        public int Damage { get; } = 15;
        public int Armor { get; } = 3;
    }
}