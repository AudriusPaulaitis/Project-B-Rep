using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Restaurant_Case_Groep1
{
    class Dayincome
    {

    }


    public partial class AdminControle
    {
        public Menus menu;
        public List<Table> tables;
        
        
        public AdminControle(Menus menu)
        {
            this.menu = menu;
            for(int i = 0; i < 15 ; i++)
            {
                tables.Add(new Table());
            }
            

        }
        
        //lijst met tabels





         public void tablePage()
        //Hier is om keuzes te maken als medewerker een bestelling op te nemen.
        {
            Navigation nav = new Navigation();
            Console.Clear();
            bool onPage = true;
            while (onPage == true)
            {
                Console.WriteLine("Admin pagina");
                Console.WriteLine("Hier kunt u bestelling opnemen.");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Selecteer een tafel (tafel 1- 15)");
                Console.WriteLine("Kies 0 om terug te gaan");
                int TableChoise = Convert.ToInt32(Console.ReadLine());

                //je gaat weg van de adminpage
                if (TableChoise == 0)
                {
                    nav.navigation();
                }

                else if (TableChoise > 0 && TableChoise < 16)
                {
                    

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Kies 0 om andere tafel te kiezen.");
                    Console.WriteLine("Kies 1 om bestellingen op te nemen");
                    Console.WriteLine("Kies 2 om de bestelde gerechten te bekijken");
                    Console.WriteLine("Kies 3 om de tafel vrij te maken ");

                    int ChoiseOrder = Convert.ToInt32(Console.ReadLine());
                    if (ChoiseOrder == 0)
                    {
                        Console.WriteLine("");
                    }

                    else if (ChoiseOrder == 1)
                    {
                        Console.Clear();
                        // menu laten draaien (id, naam en prijs) van alle gerechten
                        menu.DishPrijzen();
                        Console.WriteLine("Toets de bestelling ID om een bestelling toe te voegen");
                        Console.WriteLine("Toets 0 in om terug te gaan");
                        int OrderMenu = Convert.ToInt32(Console.ReadLine());
                        if (OrderMenu == 0)
                        {
                        }
                        else if (OrderMenu > 0 && OrderMenu < 68)
                        {
                            //gekozen id de gerecht en prijs invullen 

                        }
                    }

                    else if (ChoiseOrder == 2)
                    {
                        //orders van de tafel laten zien
                        Console.Clear();
                        Console.WriteLine();
                    }
                    

                    else if (ChoiseOrder == 3)
                    {
                        //tafel leegmaken
                        Console.WriteLine("Deze tafel is nu vrijgemaakt.");
                    }

                    else
                    {
                        Console.WriteLine("Graag valide nummer invoeren!");
                    }

                }

                else
                {
                    Console.WriteLine("Onjuiste input, kies een nummer tussen 0 en 15");
                }
                
            }

        }
    }
}

  
 
