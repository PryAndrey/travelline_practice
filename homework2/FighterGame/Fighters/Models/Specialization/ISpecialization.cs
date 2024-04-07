namespace Fighters.Models.Armors
{
    public interface ISpecialization
    {
        string Name { get; }
        int Health { get; }
        int Damage { get; }
        int Armor { get; }
    }
}