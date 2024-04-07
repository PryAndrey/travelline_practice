namespace Fighters.Models.Weapons
{
    public class Bow : IWeapon
    {
        public string Name { get; } = "Bow";
        public int Damage { get; } = 10;
        public int Range { get; } = 50;
    }
}