using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authorisatie
{ 




    class Login
    {
    //Mini Mini database
        string[] werknemers = new string[] { "#3342", "#4423", "#4552" };
        string[] wachtwoorden = new string[] { "vasd3", "elle$2", "bolpw4$" };
    //Method voor inlogverificatie
        public bool loginScreen()
        {
            Console.WriteLine("Voer uw werknemers ID en wachtwoord in");
            Console.WriteLine("--------------------------------------");
            Console.Write("Werknemers ID: ");
            string werknemersId = Console.ReadLine();
            Console.Write("Wachtwoord: ");
            string wachtwoord = Console.ReadLine();

            if (werknemers.Contains(werknemersId) && wachtwoorden.Contains(wachtwoord))
            {
                int we = Array.IndexOf(werknemers, werknemersId);
                int wa = Array.IndexOf(wachtwoorden, wachtwoord);
                if (we == wa)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }


        }

    }
}
