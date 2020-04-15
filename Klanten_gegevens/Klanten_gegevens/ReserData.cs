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
    class ReserData
    {
        public bool ReservationScreen()
        {
            //informations for todays reservation
            DateTime dateNow = DateTime.Today;

            Console.WriteLine("Reserveringen");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Datum = " + dateNow);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            
            //reading the reservations
            List<JsonObject> Reservations;
            using (var stream = File.OpenText("DataReservation.json"))
            {
                var json = stream.ReadToEnd();
                Reservations = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            }

            var dayreser = Reservations.FirstOrDefault( res => res.DateAndTime == dateNow);
            
            //notifications if there is no reservation
            if (dayreser == null)
            {
                Console.WriteLine("Geen reserveringen vandaag!");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                return true;
            }


            //counting how many reservations
            //making list to represent the todays reservations
            int countRes = 0;
            while (countRes < Reservations.Count)
            {
                Console.WriteLine(Reservations[countRes].Name + "| Aantal= " + Reservations[countRes].Persons);
                Console.WriteLine("| Meldingen= " + Reservations[countRes].Notice);
                countRes++;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            return true;
        }

        //The same method, but for other dates
        public string ReservationScreenDate()
        {
            Console.Write("Vul de datum in (dag-maand-jaar)= ");
            string dateChoice = Console.ReadLine();
            DateTime time = DateTime.Parse(dateChoice);
            string choice1 = "";

            Console.WriteLine("Reserveringen");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Datum = " + time);
            Console.WriteLine("--------------------------------------------------------------------------------------");


            List<JsonObject> Reservations;
            using (var stream = File.OpenText("DataReservation.json"))
            {
                var json = stream.ReadToEnd();
                Reservations = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            }

            var dagreservering = Reservations.FirstOrDefault(res => res.DateAndTime == time);

            if (dagreservering == null)
            {
                Console.WriteLine("Geen reserveringen vandaag!");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.Write("Kies '0' terug te gaan naar vandaag.");
                choice1 = Console.ReadLine();
                return choice1;
            }

            int aantalRes = 0;
            while (aantalRes < Reservations.Count)
            {
                Console.WriteLine(Reservations[aantalRes].Name + "| Aantal= " + Reservations[aantalRes].Persons);
                Console.WriteLine("| Meldingen= " + Reservations[aantalRes].Notice);
                aantalRes++;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Kies '0' terug te gaan naar vandaag.");
            choice1 = Console.ReadLine();
            return choice1;
        }
    }
}
