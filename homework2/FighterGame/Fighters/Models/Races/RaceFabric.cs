using Fighters.GameHandler;

namespace Fighters.Models.Races
{
    public class RaceFabric
    {
        public static IRace GetRace(string name)
        {
            switch (name.ToLower())
            {
                case "1":
                case "human":
                    return new Human();
                case "2":
                case "dwarf":
                    return new Dwarf();
                case "3":
                case "elf":
                    return new Elf();
                case "4":
                case "giant":
                    return new Giant();
                case "5":
                case "orc":
                    return new Orc();
                default:
                    throw new WrongInputException("There is no such race");
            }
        }
    }
}