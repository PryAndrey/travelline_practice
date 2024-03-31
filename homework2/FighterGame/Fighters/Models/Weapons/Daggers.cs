namespace Fighters.Models.Weapons
{
    public class Daggers : IWeapon
    {
        public string Name { get; } = "Daggers";
        public int Damage { get; } = 20;
        public int Range { get; } = 4;
    }
}