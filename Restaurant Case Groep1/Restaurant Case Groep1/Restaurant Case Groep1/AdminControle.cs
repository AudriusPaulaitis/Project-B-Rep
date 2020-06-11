using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Case_Groep1
{
    class Dayincome
    {

    }

    public partial class AdminControle
    {
        public Menus menu;

        public AdminControle(Menus menu)
        {
            this.menu = menu;

        }

        public List<string> Table_1 = new List<string>();
        public List<int> Table_01 = new List<int>();
        public List<string> Table_2 = new List<string>();
        public List<int> Table_02 = new List<int>();
        public List<string> Table_3 = new List<string>();
        public List<int> Table_03 = new List<int>();
        public List<string> Table_4 = new List<string>();
        public List<int> Table_04 = new List<int>();
        public List<string> Table_5 = new List<string>();
        public List<int> Table_05 = new List<int>();
        public List<string> Table_6 = new List<string>();
        public List<int> Table_06 = new List<int>();
        public List<string> Table_7 = new List<string>();
        public List<int> Table_07= new List<int>();
        public List<string> Table_8 = new List<string>();
        public List<int> Table_08 = new List<int>();
        public List<string> Table_9 = new List<string>();
        public List<int> Table_09 = new List<int>();
        public List<string> Table_10 = new List<string>();
        public List<int> Table_010 = new List<int>();
        public List<string> Table_11 = new List<string>();
        public List<int> Table_011 = new List<int>();
        public List<string> Table_12 = new List<string>();
        public List<int> Table_012 = new List<int>();
        public List<string> Table_13 = new List<string>();
        public List<int> Table_013 = new List<int>();
        public List<string> Table_14 = new List<string>();
        public List<int> Table_014 = new List<int>();
        public List<string> Table_15 = new List<string>();
        public List<int> Table_015 = new List<int>();

        public void tablePage()
        //Hier is om keuzes te maken als medewerker een bestelling op te nemen.
        {
        
            Console.Clear();
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
                    Console.WriteLine("########################");
                    anyReservation = true;
                }
                //als vandaag geen reserveringen zijn
                if (anyReservation == false)
                {
                    Console.WriteLine("Geen reserveringen vandaag!");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            bool onPage = true;
            while (onPage == true)
            {
                Console.WriteLine("Admin pagina");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Selecteer een tafel (tafel 1- 15)");
                Console.WriteLine("Kies 0 om terug te gaan");
                int TableChoise = Console.Read();
                if (TableChoise == 0)
                {
                    break;
                }
                else if (TableChoise > 0 && TableChoise < 16)
                {
                    //if (true)
                    

                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Kies 1 om bestellingen op te nemen");
                        Console.WriteLine("Kies 2 om bestelling te verwijderen");
                        Console.WriteLine("Kies 3 om de tafel vrij te maken of kies 0 om terug te gaan.");
                        int ChoiseOrder = Console.Read();
                        if (ChoiseOrder == 0)
                        {
                            break;
                        }

                        else if (ChoiseOrder == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Selecteer een nummer om een bestelling te nemen");
                            Console.WriteLine("Kies 0 om terug te gaan");
                            int OrderMenu = Console.Read();
                            if (OrderMenu == 0)
                            {
                                Console.Clear();
                            }
                        }

                        else if (ChoiseOrder == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Kies welke gerecht u wilt verwijderen.");
                            int removeDish = Console.Read();

                        }

                        else if (ChoiseOrder == 3)
                        {

                            Console.WriteLine("Deze tafel is nu geleegd en de prijs in het logboek bijgevuld");
                        }

                        else
                        {
                            Console.WriteLine("Graag valide nummer invoeren!");
                        }
                    
            
                }
                else {
                    console.WriteLine("Onjuiste input, kies een nummer tussen 0 en 15");
                }
            }

        }
    }
}

            


 
