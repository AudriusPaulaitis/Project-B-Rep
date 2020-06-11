using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Threading;

namespace Restaurant_Case_Groep1
{

    public class AdminControle
    {
        public Menus menu;
        public List<Table> tables = new List<Table>();
        
        
        public AdminControle(Menus menu)
        {
            this.menu = menu;
            for(int i = 1; i < 16 ; i++)
            {
                tables.Add(new Table(i));
            }
    
        }
        public void tablePage()
        //Hier is om keuzes te maken als medewerker een bestelling op te nemen.
        {
            Navigation nav = new Navigation();
            Console.Clear();
            bool onPage = true;
            returnback:
            while (onPage == true)
            {
                Console.WriteLine("Admin pagina");
                Console.WriteLine("Hier kunt u bestelling opnemen.");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Selecteer een tafel (tafel 1- 15)");
                Console.WriteLine("Kies 0 om terug te gaan");
                var Input = Console.ReadLine();
                int TableChoise;
                while (!int.TryParse(Input, out TableChoise))
                {
                    Console.WriteLine("Input klopt niet");
                    Input = Console.ReadLine();
                }

                
                    
                    

                //je gaat weg van de adminpage
                if (TableChoise == 0)
                {
                    nav.navigation();
                }

                else if (TableChoise > 0 && TableChoise < 16)
                {
                    Table selectedtable = null ;
                    foreach (Table table in tables )
                    {
                        if ( table.id == TableChoise)
                        {
                            selectedtable = table;
                            break;
                        }
        
                    }
                    if (selectedtable == null)
                    {
                       Console.WriteLine("geen tafel met dat nummer");
                        continue;
                    }
                    start:
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Kies 0 om andere tafel te kiezen.");
                    Console.WriteLine("Kies 1 om bestellingen op te nemen");
                    Console.WriteLine("Kies 2 om een bestelde gerechten te bekijken");
                    Console.WriteLine("Kies 3 om de tafel vrij te maken ");
                

                    int ChoiseOrder = Convert.ToInt32(Console.ReadLine());
                    if (ChoiseOrder == 0)
                    {
                        Console.WriteLine("");
                    }

                    else if (ChoiseOrder == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            // menu laten draaien (id, naam en prijs) van alle gerechten
                            menu.DishPrijzen();
                            Console.WriteLine("Toets de bestelling ID om een bestelling toe te voegen");
                            Console.WriteLine("Toets 0 in om terug te gaan");
                            int OrderMenu = Convert.ToInt32(Console.ReadLine());
                            if (OrderMenu == 0)
                            {
                                Console.WriteLine("");
                                break;
                            }
                            else if (OrderMenu > 0 && OrderMenu < 68)
                            {
                                //met de gekozen id de gerecht naam en prijs invullen 

                                Console.Clear();
                                Dish dish = menu.GetDishByID(OrderMenu);

                                selectedtable.dishes.Add(dish);


                                Console.WriteLine($"Gerecht {dish.Naam} toegevoegd.");
                            }
                            else
                            {
                                Console.WriteLine("Onbekend gerecht");
                            }
                            Console.WriteLine("Druk op enter om nog een gerecht toe te voegen");
                            Console.ReadLine();
                            goto start;
                        }
                    }

                    else if (ChoiseOrder == 2)
                    {
                        Console.Clear();
                        foreach (var i in selectedtable.dishes){
                            Console.WriteLine(i);
                        }
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        goto returnback;
                    }
    

                    else if (ChoiseOrder == 3)
                    {
                        selectedtable.dishes.Clear();
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