namespace Fighters.Models.Armors
{
    public class HeavyArmor : IArmor
    {
        public string Name { get; } = "HeavyArmor";
        public int Armor { get; } = 10;
        public int Speed { get; } = -5;
    }
}