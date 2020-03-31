using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Klanten_gegevens
{
    class DateReserData
    {
        public string ReservationScreenDate()
        {
            Console.Write("Vul de datum in (dag-maand-jaar)= ");
            string dateChoice = Console.ReadLine();
            DateTime Tijd = DateTime.Parse(dateChoice);
            string choice1 = "";

            Console.WriteLine("Reserveringen");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Datum = " + Tijd);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            

            List<JsonObject> Reserveringen;
            using (var stream = File.OpenText("DataReservation.json"))
            {
                var json = stream.ReadToEnd();
                Reserveringen = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            }

            var dagreservering = Reserveringen.FirstOrDefault( res => res.DateAndTime == Tijd);
            
            if (dagreservering == null)
            {
                Console.WriteLine("Geen reserveringen vandaag!");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.Write("Kies '0' terug te gaan naar vandaag.");
                choice1 = Console.ReadLine();
                return choice1;
            }

            int aantalRes = 0;
            while (aantalRes < Reserveringen.Count)
            {
                Console.WriteLine(Reserveringen[aantalRes].Name + "| Aantal= " + Reserveringen[aantalRes].Persons);
                Console.WriteLine("| Meldingen= " + Reserveringen[aantalRes].Notice);
                aantalRes++;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Kies '0' terug te gaan naar vandaag.");
            choice1 = Console.ReadLine();
            return choice1;
        }
    }
}
    

