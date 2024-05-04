using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarFormType
{
    public class CarFormsDictionary 
    {
        public static Dictionary<string, ICarFormType> CarFormByNameForm = new Dictionary<string, ICarFormType>
        {
            {"HatchBack", new HatchBack()},
            {"Sedan", new Sedan()},
            {"Universal", new Universal()}
        };

        public static string[] GetFormsNames()
        {
            return CarFormByNameForm.Keys.ToArray();
        }
    }
}