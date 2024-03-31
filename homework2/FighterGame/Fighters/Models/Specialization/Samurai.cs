namespace Fighters.Models.Armors
{
    public class Samurai : ISpecialization
    {
        public string Name { get; } = "Samurai";
        public int Health { get; } = 30;
        public int Damage { get; } = 20;
        public int Armor { get; } = 5;
    }
}