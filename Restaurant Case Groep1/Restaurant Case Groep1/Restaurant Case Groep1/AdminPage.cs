using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant_Case_Groep1 
{
	class AdminPage
	{
        public void PrintToday()
        {
            ReservationManager reser = new ReservationManager();
            //Aangeven de detum van vandaag
            DateTime today = DateTime.Today;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Reserveringen");
            Console.WriteLine("Datum = " + today);
            Console.WriteLine("--------------------------------------------------");

            bool anyReservation = false;

            //checkt alle reserveringen of ze vandaag plaatvinden
            foreach (Reservation reservation in reser.Reservations)
            {
                if (reservation.date.Day == today.Day)
                {
                    reservation.Print();
                    Console.WriteLine();
                    anyReservation = true;
                }
                //als vandaag geen reserveringen zijn
                if (anyReservation == false)
                {
                    Console.WriteLine("Geen reserveringen vandaag!");
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}

