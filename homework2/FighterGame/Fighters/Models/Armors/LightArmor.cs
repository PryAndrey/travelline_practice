namespace Fighters.Models.Armors
{
    public class LightArmor : IArmor
    {
        public string Name { get; } = "LightArmor";
        public int Armor { get; } = 5;
        public int Speed { get; } = -1;
    }
}