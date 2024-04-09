using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarTransmission
{
    public class TransmissionDictionary
    {
        public static Dictionary<string, ICarTransmission> CarTransmission = new Dictionary<string, ICarTransmission>
        {
            {"Automatic", new Automatic()},
            {"Mechanical", new Mechanical()}
        };

        public static string[] GetTransmissionsName()
        {
            return CarTransmission.Keys.ToArray();
        }
    }
}