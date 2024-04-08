using Fighters.GameHandler;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Specializations;
using Fighters.Models.Weapons;
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
                string input;
                Console.WriteLine($"Input Name or '!'");
                input = Console.ReadLine();
                if (input == "!")
                {
                    break;
                }
                try
                {
                    registrationRoom.ProcessRegistrationBlanc(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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