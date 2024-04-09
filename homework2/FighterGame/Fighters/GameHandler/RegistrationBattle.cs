using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Specialization;
using Fighters.Models.Specializations;
using Fighters.Models.Weapons;
using System.Text.RegularExpressions;

namespace Fighters.GameHandler
{
    public class RegistrationBattle
    {
        public List<Fighter> Fighters { get; private set; } = new List<Fighter>();

        public Fighter? AddFighter(string name, IRace race, ISpecialization specialization, IWeapon weapon, IArmor armor)
        {
            try
            {
                Fighters.Add(new Fighter(name, race, weapon, armor, specialization));
                return Fighters.Last();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public void ProcessRegistrationBlanc(string input)
        {
            string name = input;

            if (!Regex.Match(name, @"^([A-Za-z][A-Za-z0-9]*)$").Success)
            {
                throw new WrongInputException("Wrong Name input");
            }

            Console.WriteLine($"Input Race: 1 - Human, 2 - Dwarf, 3 - Elf, 4 - Giant, 5 - Orc");
            IRace race = RaceFabric.GetRace(Console.ReadLine());

            Console.WriteLine($"Input Class: 0 - NoClass, 1 - Knight, 2 - Mercenary, 3 - Samurai");
            ISpecialization specialization = SpecializationFabric.GetSpecialization(Console.ReadLine());

            Console.WriteLine($"Input Weapon: 0 - NoWeapon, 1 - Sword, 2 - Spear, 3 - Daggers, 4 - Bow");
            IWeapon weapon = WeaponFabric.GetWeapon(Console.ReadLine());

            Console.WriteLine($"Input Armor: 0 - NoArmor, 1 - LightArmor, 2 - RogueArmor, 3 - HeavyArmor");
            IArmor armor = ArmorFabric.GetArmor(Console.ReadLine());

            Fighter newFighter = AddFighter(name, race, specialization, weapon, armor);

            if (newFighter != null)
            {
                Console.WriteLine($"{newFighter.Name}: {newFighter.Race.Name}-{newFighter.Specialization.Name} " +
                    $"with {newFighter.Weapon.Name} in {newFighter.Armor.Name} added");
            }
        }
    }
}