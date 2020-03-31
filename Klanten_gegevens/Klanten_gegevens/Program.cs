using System;

namespace Klanten_gegevens
{
    class Program
    {
        static void Main(string[] args)
        {
            ReserData gegevens = new ReserData();
            bool vandaag = gegevens.ReservationScreen();


            DateReserData datedata = new DateReserData();
            string check = datedata.ReservationScreenDate();


            if (check == "0")
            {
                gegevens.ReservationScreen();
            }
        }
    }
}
