using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using static System.Net.Mime.MediaTypeNames;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxHealth => Race.Health + Specialization.Health;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MaxArmor => Race.Armor + Specialization.Armor;
        public int Speed => Race.Speed + Armor.Speed;
        public int CurrentHealth { get; private set; }
        public int CurrentAim { get; private set; }
        public int CurrentInitiative { get; private set; }
        public string Name { get; }
        public IRace Race { get; }
        public IWeapon Weapon { get; private set; } = new NoWeapon();
        public IArmor Armor { get; private set; } = new NoArmor();
        public ISpecialization Specialization { get; private set; } = new NoSpecialization();

        public Fighter(string name, IRace race, IWeapon weapon, IArmor armor, ISpecialization specialization)
        {
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            Specialization = specialization;
            CurrentHealth = MaxHealth;
            X = new Random().Next(0, 100);
            Y = new Random().Next(0, 100);
        }

        public int CalculateDamage(double critCoef)
        {
            if (critCoef < 1)
            {
                critCoef = 1;
            }
            Random random = new Random();
            double randomCoef = (random.Next(1, 50) / 10 - 2.5) / 100 + 1;
            return (int)((Race.Damage + Specialization.Damage + Weapon.Damage) * randomCoef * critCoef);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= Math.Max(damage - MaxArmor, 1);
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }

        public void AimSelection(int countFighters, int myPos)
        {
            if (myPos == 0)
            {
                CurrentAim = new Random().Next(1, countFighters);
                return;
            }
            if (myPos == countFighters - 1)
            {
                CurrentAim = new Random().Next(0, countFighters - 1);
                return;
            }
            int tempRndAim = new Random().Next(0, countFighters);
            if (tempRndAim == myPos)
            {
                tempRndAim--;
            }
            CurrentAim = tempRndAim;
        }

        public void CalculateInitiative(double distance)
        {
            CurrentInitiative = (int)((-Speed - Math.Abs(distance - Weapon.Range)) * CurrentHealth / MaxHealth);
        }

        public void CalculateCoords(int xEnemy, int yEnemy)
        {
            if (X != xEnemy)
            {
                X = (X > xEnemy ? Math.Max(X - Speed, xEnemy) : Math.Min(X + Speed, xEnemy));
            }
            if (Y != yEnemy)
            {
                Y = (Y > xEnemy ? Math.Max(Y - Speed, yEnemy) : Math.Min(Y + Speed, yEnemy));
            }
        }
    }
}