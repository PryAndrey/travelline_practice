namespace Fighters.Models.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; } = "Sword";
        public int Damage { get; } = 25;
        public int Range { get; } = 6;
    }
}