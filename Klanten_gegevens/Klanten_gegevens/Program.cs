using System;

namespace Klanten_gegevens
{
    class Program
    {
        static void Main(string[] args)
        {
            //call todays reservation screen 
            ReserData start = new ReserData();
            bool today = start.ReservationScreen();

            //call reservation screen on chosen date
            string check = start.ReservationScreenDate();

            //going to a table
            if (check == "1")
            {
                check = start.TableOrder();
                
            }
            //return to todays reservation
            if (check == "0")
            {
                start.ReservationScreen();
            }
        }
    }
}
