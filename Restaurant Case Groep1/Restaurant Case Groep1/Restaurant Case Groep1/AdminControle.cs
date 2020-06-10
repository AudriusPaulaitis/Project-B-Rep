using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Case_Groep1
{
   
        public class AdminControle
        {
            public Menus menu;

            public AdminControle(Menus menu)
        {
            this.menu = menu;
        
            
        }
     

            public List<string> Table_1 = new List<string>();
            public List<string> Table_2 = new List<string>();
            public List<string> Table_3 = new List<string>();
            public List<string> Table_4 = new List<string>();
            public List<string> Table_5 = new List<string>();
            public List<string> Table_6 = new List<string>();
            public List<string> Table_7 = new List<string>();
            public List<string> Table_8 = new List<string>();
            public List<string> Table_9 = new List<string>();
            public List<string> Table_10 = new List<string>();
            public List<string> Table_11 = new List<string>();
            public List<string> Table_12 = new List<string>();
            public List<string> Table_13 = new List<string>();
            public List<string> Table_14 = new List<string>();
            public List<string> Table_15 = new List<string>();


            public void tablePage()
            //Hier is om keuzes te maken als medewerker een bestelling op te nemen.
            {
                bool onPage = true;
                while (onPage == true)
                {
                   Console.Clear();
                   Console.WriteLine("Admin pagina");
                   Console.WriteLine("--------------------------------------");
                   Console.WriteLine("Selecteer een tafel (tafel 1- 15");
                   Console.WriteLine("Kies 0 om terug te gaan");
                   int TableChoise = Console.Read();
                   if (TableChoise == 0)
                   {
                      break;
                   }
                   else
                   {
                      while (true)
                      {
                         
                         Console.WriteLine("--------------------------------------");
                         Console.WriteLine("Kies 1 om bestellingen op te nemen");
                         Console.WriteLine("Kies 2 om bestelling te verwijderen");
                         Console.WriteLine("Kies 3 om de tafel vrij te maken of kies 0 om terug te gaan.");
                         int ChoiseOrder = Console.Read();
                         if (ChoiseOrder == 0)
                         {
                            break;
                         }
                         if (ChoiseOrder == 1)
                         {
                            Console.Clear();
                            Console.WriteLine("Selecteer een nummer om een bestelling te nemen");
                            Console.WriteLine("Kies 0 om terug te gaan");
                            int OrderMenu = Console.Read();
                            if (OrderMenu == 0 )
                            {
                                Console.Clear();
                            }
                         }
                      }
                   }
                }
            }

        }
    }

 
