﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Restaurant_Case_Groep1
{
    public class Menus
    {
        public List<Dish> dishes;
        public List<Dish> dishes2;
        public List<Dish> dishes3;
        public List<Dish> dishes4;
        public List<Dish> dishes5;
        public List<Dish> dishes6;

        public List<Dishbestel> dishesB1;
        public List<Dishbestel> dishesB2;
        public List<Dishbestel> dishesB3;
        public List<Dishbestel> dishesB4;
        public List<Dishbestel> dishesB5;
        public List<Dishbestel> dishesB6;

        static int index = 0;

        public Menus()
        {
            string jsconfigPath = "jsconfig1.json";
            Console.WriteLine(File.Exists(jsconfigPath));
            string jsonDishes = File.ReadAllText(jsconfigPath);
            dishes = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes);

            string jsconfigPath2 = "jsconfig2.json";
            string jsonDishes2 = File.ReadAllText(jsconfigPath2);
            dishes2 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes2);

            string jsconfigPath3 = "jsconfig3.json";
            string jsonDishes3 = File.ReadAllText(jsconfigPath3);
            dishes3 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes3);

            string jsconfigPath4 = "jsconfig4.json";
            string jsonDishes4 = File.ReadAllText(jsconfigPath4);
            dishes4 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes4);

            string jsconfigPath5 = "jsconfig5.json";
            string jsonDishes5 = File.ReadAllText(jsconfigPath5);
            dishes5 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes5);

            string jsconfigPath6 = "jsconfig6.json";
            string jsonDishes6 = File.ReadAllText(jsconfigPath6);
            dishes6 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes6);

            // hier maak ik iets aan zodat ik bij admincontrole alleen de prijs naam en id print.

            dishesB1 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes);
            dishesB2 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes2);
            dishesB3 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes3);
            dishesB4 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes4);
            dishesB5 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes5);
            dishesB6 = JsonConvert.DeserializeObject<List<Dishbestel>>(jsonDishes6);
        }
        public void DishPrijzen()
        {
            foreach (var dish in dishesB1)
            {
                Console.WriteLine(dish);
            }
            Console.WriteLine("----------");
            foreach (var dish in dishesB5)
            {
                Console.WriteLine(dish);
            }
            Console.WriteLine("----------");
            foreach (var dish in dishesB6)
            {
                Console.WriteLine(dish);
            }
            Console.WriteLine("----------");
            foreach (var dish in dishesB2)
            {
                Console.WriteLine(dish);
            }
            Console.WriteLine("----------");
            foreach (var dish in dishesB3)
            {
                Console.WriteLine(dish);
            }
            Console.WriteLine("----------");
            foreach (var dish in dishesB4)
            {
                Console.WriteLine(dish);
            }
        }
        public Dish GetDishByID(int id)
        {
            List<Dish> allDishes = new List<Dish>();
            allDishes.AddRange(dishes);
            allDishes.AddRange(dishes2);
            allDishes.AddRange(dishes3);
            allDishes.AddRange(dishes4);
            allDishes.AddRange(dishes5);
            allDishes.AddRange(dishes6);


            foreach ( Dish dish in allDishes)
            {
                
                if ( dish.GerechtID  == id)
                    return dish;
            }
            return null;

        }
        public void menuStart()
        {
            Console.WriteLine("Menuscherm");
            Console.WriteLine("----------");
            // ik begin met de output van mijn code neer te zetten in UTF8 anders kan ik het euro teken niet printen, daarna deserialize ik mijn json om zo vervolgens het in een object te kunnen zetten.
            // daarna zet ik mijn object in een for loop om zo alles in het object te printen.
            
            string jsconfigPath = "jsconfig1.json";
            string jsonDishes = File.ReadAllText(jsconfigPath);
            List<Dish> dishes = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes);

            string jsconfigPath2 = "jsconfig2.json";
            string jsonDishes2 = File.ReadAllText(jsconfigPath2);
            List<Dish> dishes2 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes2);

            string jsconfigPath3 = "jsconfig3.json";
            string jsonDishes3 = File.ReadAllText(jsconfigPath3);
            List<Dish> dishes3 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes3);

            string jsconfigPath4 = "jsconfig4.json";
            string jsonDishes4 = File.ReadAllText(jsconfigPath4);
            List<Dish> dishes4 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes4);

            string jsconfigPath5 = "jsconfig5.json";
            string jsonDishes5 = File.ReadAllText(jsconfigPath5);
            List<Dish> dishes5 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes5);

            string jsconfigPath6 = "jsconfig6.json";
            string jsonDishes6 = File.ReadAllText(jsconfigPath6);
            List<Dish> dishes6 = JsonConvert.DeserializeObject<List<Dish>>(jsonDishes6);


            // ik verberg hier de muis en zorg ervoor dat als je de console opstart je gelijk de optie heb uit 3 menu's en de terug knop
            Console.CursorVisible = false;
            List<string> KindOfMenu = new List<string>()
            {
                "Ochtend",
                "Middag",
                "Avond",
                "Koude dranken",
                "Warme dranken",
                "Alcoholische dranken",
                "Terug"
            };

            while (true)
            {   // ik switch hier tussen de menu's, het werkt door selectedmenu te vergelijken met de huidige keuze
                // Ik print elke item in de Json door de gedeserializde json heen te gaan en elke item 1 voor 1 uit te printen.
                Console.Clear();
                Console.WriteLine("Menuscherm");
                Console.WriteLine("----------");
                string SelectedMenu = Menu(KindOfMenu);
                Navigation navigationM = new Navigation();
                if (SelectedMenu == "Ochtend")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
                else if (SelectedMenu == "Terug")
                {
                    navigationM.navigation();
                    Console.Read();
                }
                else if (SelectedMenu == "Middag")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes5)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
                else if (SelectedMenu == "Avond")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes6)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
                else if (SelectedMenu == "Koude dranken")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes2)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
                else if (SelectedMenu == "Warme dranken")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes3)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
                else if (SelectedMenu == "Alcoholische dranken")
                {
                    Console.Clear();
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    foreach (var dish in dishes4)
                    {
                        Console.WriteLine(dish);
                    }
                    Console.WriteLine("Druk op Enter om terug te gaan");
                    Console.Read();
                }
            }   

        }
        private static string Menu(List<string> KindOfMenu) 
        {
            for (int i = 0; i < KindOfMenu.Count; i++)
            {   // hier geef ik een aparte kleur aan de gekozen menu om het zo overzichtelijker te maken
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
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
                if (index == 0)
                {

                }
                else
                {
                    index--;
                }
            }
            else if (PressedKey.Key == ConsoleKey.DownArrow)
            {
                if (index == KindOfMenu.Count - 1)
                {

                }
                else
                {
                    index++;
                }
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

