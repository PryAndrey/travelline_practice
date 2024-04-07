using Fighters.GameHandler;
using Fighters.Models.Fighters;
using System.Text.RegularExpressions;

namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            RegistrationBattle registrationRoom = new RegistrationBattle();

            Console.WriteLine($"If you want to create fighter then input here information");
            Console.WriteLine($"Enter '!' to stop registration");

            while (true)
            {
                string name, RaceStr, SpecializationStr, WeaponStr, ArmorStr;
                Console.WriteLine($"Input Name or '!'");
                name = Console.ReadLine();
                if (name == "!")
                {
                    break;
                }
                if (!Regex.Match(name, @"^([A-Za-z][A-Za-z0-9]*)$").Success)
                {
                    Console.WriteLine($"Wrong Name input");
                    continue;
                }

                Console.WriteLine($"Input Race: 1 - Human, 2 - Dwarf, 3 - Elf, 4 - Giant, 5 - Orc");
                RaceStr = Console.ReadLine();
                if (!Regex.Match(RaceStr, @"^(\d+)$").Success)
                {
                    Console.WriteLine($"Wrong Race input");
                    continue;
                }

                Console.WriteLine($"Input Class: 0 - NoClass, 1 - Knight, 2 - Mercenary, 3 - Samurai");
                SpecializationStr = Console.ReadLine();
                if (!Regex.Match(SpecializationStr, @"^(\d+)$").Success)
                {
                    Console.WriteLine($"Wrong Class input");
                    continue;
                }

                Console.WriteLine($"Input Weapon: 0 - NoWeapon, 1 - Sword, 2 - Spear, 3 - Daggers, 4 - Bow");
                WeaponStr = Console.ReadLine();
                if (!Regex.Match(WeaponStr, @"^(\d+)$").Success)
                {
                    Console.WriteLine($"Wrong Weapon input");
                    continue;
                }

                Console.WriteLine($"Input Armor: 0 - NoArmor, 1 - LightArmor, 2 - RogueArmor, 3 - HeavyArmor");
                ArmorStr = Console.ReadLine();
                if (!Regex.Match(ArmorStr, @"^(\d+)$").Success)
                {
                    Console.WriteLine($"Wrong Armor input");
                    continue;
                }

                Fighter newFighter = registrationRoom.AddFighter(name, RaceStr, SpecializationStr, WeaponStr, ArmorStr);

                if (newFighter != null)
                {
                    Console.WriteLine($"{newFighter.Name}: {newFighter.Race.Name}-{newFighter.Specialization.Name} " +
                        $"with {newFighter.Weapon.Name} in {newFighter.Armor.Name} added");
                }
            }
            GameMaster master = new GameMaster();
            try
            {
                IFighter winner = master.PlayAndGetWinner(registrationRoom.Fighters);
                Console.WriteLine($"Winner: {winner.Name}!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
/*
example:

Andy0 2 3 1 3
Andy1 1 1 2 3
Andy2 2 0 4 2
Andy3 3 3 2 0
Andy4 4 2 0 1
!

*/