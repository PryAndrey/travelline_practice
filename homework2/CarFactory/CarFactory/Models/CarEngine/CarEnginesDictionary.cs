using System.Collections.Generic;
using System.Linq;

namespace CarFactory.Models.CarEngine
{
    public class CarEnginesDictionary 
    {
        public static Dictionary<string, ICarEngine> CarEngineByNameEngine = new Dictionary<string, ICarEngine>
        {
            {"V6", new V6Engine()},
            {"V8", new V8Engine()},
            {"V12", new V12Engine()}
        };

        public static string[] GetEnginesNames()
        {
            return CarEngineByNameEngine.Keys.ToArray();
        }
    }
}