using Fighters.Models.Specializations;

namespace Fighters.GameHandler
{
    public class SpecializationHandler
    {
        public static ISpecialization GetSpecialization(string name)
        {
            switch (name.ToLower())
            {
                case "0":
                case "nospecialization":
                    return new NoSpecialization();
                case "1":
                case "knight":
                    return new Knight();
                case "2":
                case "mercenary":
                    return new Mercenary();
                case "3":
                case "samurai":
                    return new Samurai();
                default:
                    throw new WrongInputException("There is no such class");
            }
        }
    }
}