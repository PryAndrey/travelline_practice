using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Specializations;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public interface IFighter
    {
        public int MaxHealth { get; }
        public int MaxArmor { get; }
        public int X { get; }
        public int Y { get; }
        public int Speed { get; }
        public int CurrentHealth { get; }
        public int CurrentInitiative { get; }
        public int CurrentAim { get; }
        public string Name { get; }

        public IWeapon Weapon { get; }
        public IRace Race { get; }
        public IArmor Armor { get; }
        public ISpecialization Specialization { get; }

        public void TakeDamage(int damage);
        public int CalculateDamage(double critCoef);
        public void SelectionAim(int countFighters, int myPos);
        public void CalculateInitiative(double distance);
        public void CalculateCoords(int x, int y);
    }
}