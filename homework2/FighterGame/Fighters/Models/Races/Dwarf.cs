namespace Fighters.Models.Races
{
    public class Dwarf : IRace
    {
        public string Name { get; } = "Dwarf";
        public int Damage { get; } = 15;
        public int Health { get; } = 120;
        public int Armor { get; } = 15;
        public int Speed { get; } = 6;
    }
}