using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarFormType
{
    public class FormDictionary
    {
        public static Dictionary<string, ICarFormType> CarForm = new Dictionary<string, ICarFormType>
        {
            {"HatchBack", new HatchBack()},
            {"Sedan", new Sedan()},
            {"Universal", new Universal()}
        };

        public static string[] GetFormsName()
        {
            return CarForm.Keys.ToArray();
        }
    }
}