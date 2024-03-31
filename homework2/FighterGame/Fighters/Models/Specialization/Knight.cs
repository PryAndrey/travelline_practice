namespace Fighters.Models.Armors
{
    public class Knight : ISpecialization
    {
        public string Name { get; } = "Knight";
        public int Health { get; } = 20;
        public int Damage { get; } = 20;
        public int Armor { get; } = 10;
    }
}