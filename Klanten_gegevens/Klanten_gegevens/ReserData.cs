﻿using System;
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
            DateTime dateNow = DateTime.Today;

            Console.WriteLine("Reserveringen");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Datum = " + dateNow);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            

            List<JsonObject> Reserveringen;
            using (var stream = File.OpenText("DataReservation.json"))
            {
                var json = stream.ReadToEnd();
                Reserveringen = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            }

            var dagreservering = Reserveringen.FirstOrDefault( res => res.DateAndTime == dateNow);
            
            if (dagreservering == null)
            {
                Console.WriteLine("Geen reserveringen vandaag!");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                return true;
            }

            int aantalRes = 0;
            while (aantalRes < Reserveringen.Count)
            {
                Console.WriteLine(Reserveringen[aantalRes].Name + "| Aantal= " + Reserveringen[aantalRes].Persons);
                Console.WriteLine("| Meldingen= " + Reserveringen[aantalRes].Notice);
                aantalRes++;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
            return true;
        }
    }
}
