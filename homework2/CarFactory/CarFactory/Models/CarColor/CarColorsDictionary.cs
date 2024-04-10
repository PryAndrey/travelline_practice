using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarColor
{
    public class CarColorsDictionary 
    {
        public static Dictionary<string, ICarColor> CarColorByNameColor = new Dictionary<string, ICarColor>
        {
            {"White", new White()},
            {"Black", new Black()},
            {"Blue", new Blue()},
            {"Red", new Red()},
            {"Green", new Green()}
        };

        public static string[] GetColorsNames()
        {
            return CarColorByNameColor.Keys.ToArray();
        }
    }
}