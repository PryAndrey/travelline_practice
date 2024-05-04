using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarTransmission
{
    public class CarTransmissionsDictionary
    {
        public static Dictionary<string, ICarTransmission> CarTransmissionByNameTransmission = new Dictionary<string, ICarTransmission>
        {
            {"Automatic", new Automatic()},
            {"Mechanical", new Mechanical()}
        };

        public static string[] GetTransmissionsNames()
        {
            return CarTransmissionByNameTransmission.Keys.ToArray();
        }
    }
}