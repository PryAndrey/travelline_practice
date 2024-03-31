namespace Fighters.Models.Races
{
    public class Giant : IRace
    {
        public string Name { get; } = "Giant";
        public int Damage { get; } = 20;
        public int Health { get; } = 200;
        public int Armor { get; } = 20;
        public int Speed { get; } = 8;
    }
}