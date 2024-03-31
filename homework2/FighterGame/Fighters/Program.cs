using Fighters.Models.GameHadler;

namespace Fighters
{
    public class Program
    {
        public static void Main()
        {
            RegistrationBattle registrationRoom = new RegistrationBattle();
            registrationRoom.ShowManual();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "!")
                    break;
                registrationRoom.AddFighter(input);
            }
            var master = new GameMaster();
            try
            {
                var winner = master.PlayAndGetWinner(registrationRoom.Fighters);
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