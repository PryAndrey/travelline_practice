using System;
using System.Linq;

namespace Casino
{
    internal class Program
    {
        const double EPS = 0.009;
        static void Main(string[] args)
        {
            const double MULTIPLICATOR = 0.2;
            Random random = new Random();
            double balance = 10000;
            while (balance > EPS)
            {
                Console.WriteLine("Your balanse " + Math.Round(balance, 2));
                Console.WriteLine($"Input your bet or '!' to exit from casino with {balance} money");
                string betStr = Console.ReadLine();

                int bet = 0;
                if (betStr.All(char.IsDigit)){
                    bet = int.Parse(betStr);
                }
                else if (betStr == "!"){
                    break;
                }
                else
                {
                    Console.WriteLine();
                    continue;
                }

                if (bet > balance){
                    Console.WriteLine($"You have not got so much money!");
                    continue;
                }

                int randomNumber = random.Next(1, 20);
                Console.WriteLine($"The number {randomNumber} fell out!");
                if (18 <= randomNumber && randomNumber <= 20)
                {
                    Console.WriteLine("You win!");
                    balance = balance * (1 + (MULTIPLICATOR * randomNumber % 17));
                }
                else
                {
                    Console.WriteLine("You lose!");
                    balance -= bet;
                }
                Console.WriteLine();
            }
        }
    }
}
