namespace Fighters.Models.Weapons
{
    public class NoWeapon : IWeapon
    {
        public string Name { get; } = "Arms";
        public int Damage { get; } = 1;
        public int Range { get; } = 3;
    }
}