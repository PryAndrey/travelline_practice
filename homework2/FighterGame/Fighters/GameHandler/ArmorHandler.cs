using Fighters.Models.Armors;

namespace Fighters.GameHandler
{
    public class ArmorHandler
    {
        public static IArmor GetArmor(string name)
        {
            switch (name.ToLower())
            {
                case "0":
                case "noarmor":
                    return new NoArmor();
                case "1":
                case "lightarmor":
                    return new LightArmor();
                case "2":
                case "roguearmor":
                    return new RogueArmor();
                case "3":
                case "heavyarmor":
                    return new HeavyArmor();
                default:
                    throw new WrongInputException("There is no such armor");
            }
        }
    }
}