using System;

namespace Klanten_gegevens
{
    class Program
    {
        static void Main(string[] args)
        {
            ReserData gegevens = new ReserData();
            bool vandaag = gegevens.ReservationScreen();

            string keuze = Console.ReadLine();
            if (vandaag == false && (keuze == "0"))
            {
                gegevens.ReservationScreen();
            }
        }
    }
}
