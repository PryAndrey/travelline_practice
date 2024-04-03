using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Fighters.GameHandler
{
    public class RegistrationBattle
    {
        public class WrongInputException : Exception
        {
            public WrongInputException() : base() { }

            public WrongInputException(string message) : base(message) { }

            public WrongInputException(string message, Exception innerException) : base(message, innerException) { }
        }

        public List<Fighter> Fighters { get; private set; } = new List<Fighter>();
        private static IRace GetRace(string name)
        {
            switch (name)
            {
                case "1":
                    return new Human();
                case "2":
                    return new Dwarf();
                case "3":
                    return new Elf();
                case "4":
                    return new Giant();
                case "5":
                    return new Orc();
                default:
                    throw new WrongInputException("There is no such race");
            }
        }

        private static ISpecialization GetSpecialization(string name)
        {
            switch (name)
            {
                case "0":
                    return new NoSpecialization();
                case "1":
                    return new Knight();
                case "2":
                    return new Mercenary();
                case "3":
                    return new Samurai();
                default:
                    throw new WrongInputException("There is no such class");
            }
        }

        private static IWeapon GetWeapon(string name)
        {
            switch (name)
            {
                case "0":
                    return new NoWeapon();
                case "1":
                    return new Sword();
                case "2":
                    return new Spear();
                case "3":
                    return new Daggers();
                case "4":
                    return new Bow();
                default:
                    throw new WrongInputException("There is no such weapon");
            }
        }

        private static IArmor GetArmor(string name)
        {
            switch (name)
            {
                case "0":
                    return new NoArmor();
                case "1":
                    return new LightArmor();
                case "2":
                    return new RogueArmor();
                case "3":
                    return new HeavyArmor();
                default:
                    throw new WrongInputException("There is no such armor");
            }
        }

        public Fighter? AddFighter(string name, string raceName, string specializationName, string weaponName, string armorName)
        {
            try
            {
                IRace race = GetRace(raceName);
                ISpecialization specialization = GetSpecialization(specializationName);
                IWeapon weapon = GetWeapon(weaponName);
                IArmor armor = GetArmor(armorName);
                Fighters.Add(new Fighter(name, race, weapon, armor, specialization));
                return Fighters.Last();
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong input:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}