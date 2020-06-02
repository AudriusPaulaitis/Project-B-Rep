using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Restaurant_Case_Groep1
{
	public class Navigation
	{
        int index = 0;
		public void navigation()
		{
            Console.Clear();
            Console.WriteLine("Navigatiescherm");
            Console.WriteLine("---------------");
            Console.CursorVisible = false;
            List<string> Options = new List<string>()
            {
                "Reserveringsscherm",
                "Menuscherm",
                "Loginscherm",
                "Exit"
            };

            while (true)
            {
                string SelectedOption = Selector(Options);
                ReservationManager reservationManager = new ReservationManager();
                Menus menus = new Menus();
                Login login = new Login();
                AdminPage page = new AdminPage(menus);

                if (SelectedOption == "Reserveringsscherm")
                {
                    reservationManager.reservationMenu();
                    Console.Read();
                }
                else if (SelectedOption == "Menuscherm")
                {
                    menus.menuStart();
                    Console.Read();
                }
                else if (SelectedOption == "Loginscherm")
                {
                    if (login.loginScreen())
                    {
                        page.PrintToday();
                    }
                    else 
                    {
                        Console.WriteLine("Verkeerde inloggevens");
                    }

                }
                else if (SelectedOption == "Exit")
                {
                    Environment.Exit(0);
                }

            }   
        }
        public string Selector(List<string> Options)
        {
            Console.Clear();
            Console.WriteLine("Navigatiescherm");
            Console.WriteLine("---------------");
            for (int i = 0; i < Options.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Options[i]);
                }
                else
                {
                    Console.WriteLine(Options[i]);
                }
                Console.ResetColor();
            }
            ConsoleKeyInfo PressedKey = Console.ReadKey();
            Console.Clear();
            if (PressedKey.Key == ConsoleKey.UpArrow && index >= 0)
            {
                index -= 1;
            }
            else if (PressedKey.Key == ConsoleKey.DownArrow && index < Options.Count)
            {
                index += 1;
            }
            else if (PressedKey.Key == ConsoleKey.Enter)
            {
                return Options[index];
            }
            else
            {
                return "";
            }
            return "";
        }

    }
}


