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
            DateTime datumNu = DateTime.Today;

            Console.WriteLine("Reserveringen");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Datum = " + datumNu);
            Console.WriteLine("---------------------------------");
            

            List<JsonObject> Reserveringen;
            using (var stream = File.OpenText("DataReservation.json"))
            {
                var json = stream.ReadToEnd();
                Reserveringen = JsonConvert.DeserializeObject<List<JsonObject>>(json);
            }

            var dagreservering = Reserveringen.FirstOrDefault( res => res.Datum == datumNu);
            
            if (dagreservering == null)
            {
                Console.WriteLine("Geen reservaties vandaag!");
                return true;
            }

            return true;
        }
    }
}
