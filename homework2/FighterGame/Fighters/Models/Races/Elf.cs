namespace Fighters.Models.Races
{
    public class Elf : IRace
    {
        public string Name { get; } = "Elf";
        public int Damage { get; } = 12;
        public int Health { get; } = 80;
        public int Armor { get; } = 8;
        public int Speed { get; } = 20;
    }
}