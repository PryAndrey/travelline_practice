namespace Fighters.Models.Weapons
{
    public class Spear : IWeapon
    {
        public string Name { get; } = "Spear";
        public int Damage { get; } = 18;
        public int Range { get; } = 10;
    }
}