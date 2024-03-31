namespace Fighters.Models.Armors
{
    public class NoArmor : IArmor
    {
        public string Name { get; } = "NoArmor";
        public int Armor { get; } = 0;
        public int Speed { get; } = 0;
    }
}