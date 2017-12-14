using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortirovkiSHARP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<KeyValuePair<int, string>> mass = new List<KeyValuePair<int, string>>();
            List<string> words = new List<string>()
            {
                "Smile", "Sweet", "Sister", "Sadistic", "Surprise", "Service", "We", "Are", "STYLE", "!"
            };
            Random rng = new Random();
            foreach(var w in words)
            {
                mass.Add(new KeyValuePair<int, string>(rng.Next(1, 10), w));
            }

        }
    }
}
