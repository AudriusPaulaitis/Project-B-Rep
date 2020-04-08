using System;

namespace Klanten_gegevens
{
    class Program
    {
        static void Main(string[] args)
        {
            //call todays reservation screen 
            ReserData gegevens = new ReserData();
            bool vandaag = gegevens.ReservationScreen();

            //call reservation screen on chosen date
            DateReserData datedata = new DateReserData();
            string check = datedata.ReservationScreenDate();

            //return to todays reservation
            if (check == "0")
            {
                gegevens.ReservationScreen();
            }
        }
    }
}
