using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using System.Text.RegularExpressions;

namespace Fighters.Models.GameHadler
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
        public void AddFighter(string input)
        {
            string pattern = @"^([A-Za-z][A-Za-z0-9]*)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)$";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string name = match.Groups[1].Value;
                string raceName = match.Groups[2].Value;
                string specializationName = match.Groups[3].Value;
                string weaponName = match.Groups[4].Value;
                string armorName = match.Groups[5].Value;
                try
                {
                    IRace race = GetRace(raceName);
                    ISpecialization specialization = GetSpecialization(specializationName);
                    IWeapon weapon = GetWeapon(weaponName);
                    IArmor armor = GetArmor(armorName);
                    Fighters.Add(new Fighter(name, race, weapon, armor, specialization));
                    Console.WriteLine($"{name} added");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input:");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Wrong input. Try again");
            }
        }
        public void ShowManual()
        {
            Console.WriteLine($"If you want to create fighter then input here information in that format");
            Console.WriteLine($"'Name Race Class Weapon Armor'");
            Console.WriteLine($"Race: 1 - Human, 2 - Dwarf, 3 - Elf, 4 - Giant, 5 - Orc");
            Console.WriteLine($"Class: 0 - NoClass, 1 - Knight, 2 - Mercenary, 3 - Samurai");
            Console.WriteLine($"Weapon: 0 - NoWeapon, 1 - Sword, 2 - Spear, 3 - Daggers, 4 - Bow");
            Console.WriteLine($"Armor: 0 - NoArmor, 1 - LightArmor, 2 - RogueArmor, 3 - HeavyArmor");
            Console.WriteLine($"For example: 'Eric 1 2 3 3'");
            Console.WriteLine($"Enter '!' to stop registration");
        }
    }
}