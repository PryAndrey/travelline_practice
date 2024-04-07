namespace Fighters.Models.Armors
{
    public class RogueArmor : IArmor
    {
        public string Name { get; } = "RogueArmor";
        public int Armor { get; } = 8;
        public int Speed { get; } = -3;
    }
}