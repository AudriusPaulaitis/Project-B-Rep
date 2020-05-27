using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB
{
    class AdminControle
    {
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
            Console.Clear();
            Console.WriteLine("Admin pagina");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Selecteer een tafel (tafel 1- 15");
            int TableChoise = Console.Read();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Wat wil u doen?");
            Console.WriteLine("Kies 1 om bestellingen op te nemen, kies 2 om bestelling te verwijderen,");
            Console.WriteLine("kies 3 om de tafel vrij te maken of kies 0 om terug te gaan.");
            int ChoiseOrder = Console.Read();

        }

    }
}
