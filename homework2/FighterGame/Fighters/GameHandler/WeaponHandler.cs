using Fighters.Models.Weapons;

namespace Fighters.GameHandler
{
    public class WeaponHandler
    {
        public static IWeapon GetWeapon(string name)
        {
            switch (name.ToLower())
            {
                case "0":
                case "noweapon":
                    return new NoWeapon();
                case "1":
                case "sword":
                    return new Sword();
                case "2":
                case "spear":
                    return new Spear();
                case "3":
                case "daggers":
                    return new Daggers();
                case "4":
                case "bow":
                    return new Bow();
                default:
                    throw new WrongInputException("There is no such weapon");
            }
        }
    }
}