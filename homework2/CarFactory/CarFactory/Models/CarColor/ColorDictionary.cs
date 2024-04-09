using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarColor
{
    public class ColorDictionary
    {
        public static Dictionary<string, ICarColor> CarColor = new Dictionary<string, ICarColor>
        {
            {"White", new White()},
            {"Black", new Black()},
            {"Blue", new Blue()},
            {"Red", new Red()},
            {"Green", new Green()}
        };

        public static string[] GetColorsName()
        {
            return CarColor.Keys.ToArray();
        }
    }
}