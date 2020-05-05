using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectB_Console
{
    class Program
    {
        static int index = 0;
        private static void Main(string[] args)
        {
            // ik begin met de output van mijn code neer te zetten in UTF8 anders kan ik het euro teken niet printen, daarna deserialize ik mijn json om zo vervolgens het in een object te kunnen zetten.
            // daarna zet ik mijn object in een for loop om zo alles in het object te printen.
            Console.OutputEncoding = Encoding.UTF8;
            string jsconfigPath = "jsconfig1.json";
            string jsonDishes = File.ReadAllText(jsconfigPath);
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes);

            string jsconfigPath2 = "jsconfig2.json";
            string jsonDishes2 = File.ReadAllText(jsconfigPath2);
            List<Dish> dishes2 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes2);


            // ik verberg hier de muis en zorg ervoor dat als je de console opstart je gelijk de optie heb uit 3 menu's en de terug knop
            Console.CursorVisible = false;
            List<string> KindOfMenu = new List<string>()
            {
                "Ochtend",
                "Middag",
                "Avond",
                "Koude dranken",
                "Warme dranken",
                "Terug"
            };

            while (true)
            {   // ik switch hier tussen de menu's, het werkt door selectedmenu te vergelijken met de huidige keuze
                string SelectedMenu = Menu(KindOfMenu);
                if (SelectedMenu == "Ochtend")
                {
                    Console.Clear();
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.Read();
                }
                if (SelectedMenu == "Terug")
                {
                    Environment.Exit(0);
                }
                else if (SelectedMenu == "Middag")
                {
                    Console.Clear();
                    Console.WriteLine("Caeser salade                 8$"); Console.Read();
                }
                else if (SelectedMenu == "Avond")
                {
                    Console.Clear();
                    Console.WriteLine("Biefstuk                     14$"); Console.Read();
                }
                else if (SelectedMenu == "Koude dranken")
                {
                    Console.Clear();
                    foreach (var dish in dishes2)
                    {
                        Console.WriteLine(dish);
                    }
                }   Console.Read();
            }
        }
        private static string Menu(List<string> KindOfMenu) 
        {
            for (int i = 0; i < KindOfMenu.Count; i = i + 1)
            {   // hier geef ik een aparte kleur aan de gekozen menu om het zo overzichtelijker te maken
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(KindOfMenu[i]);
                }
                else
                {
                    Console.WriteLine(KindOfMenu[i]);
                }
                Console.ResetColor();
            }
            ConsoleKeyInfo PressedKey = Console.ReadKey();
            Console.Clear();
            // Met pressedkey navigeer je door het menu, als je klikt op de pijltoetsen verranderd de index en zo ook het gekozen menu
            if (PressedKey.Key == ConsoleKey.UpArrow)
            {
                index = index - 1;
            }
            else if (PressedKey.Key == ConsoleKey.DownArrow)
            {
                index = index + 1;
            }
            else if (PressedKey.Key == ConsoleKey.Enter)
            {
                return KindOfMenu[index];
            }
            else
            {
                return "";
            }
            return "";
        }
    }
}

