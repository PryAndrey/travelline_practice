namespace Fighters.Models.Races
{
    public class Orc : IRace
    {
        public string Name { get; } = "Orc";
        public int Damage { get; } = 15;
        public int Health { get; } = 120;
        public int Armor { get; } = 10;
        public int Speed { get; } = 8;
    }
}