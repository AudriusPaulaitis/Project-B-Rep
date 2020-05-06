using System;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            ReservationManager reservationManager = new ReservationManager();
            reservationManager.makeReservation();
            reservationManager.PrintToday();
        }
    }
}
