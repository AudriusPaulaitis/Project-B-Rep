﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Restaurant_Case_Groep1
{
	public class Navigation
	{
        int index = 0;
		public void navigation()
		{
            start:
            Console.Clear();
            Console.WriteLine("         Navigatiescherm          ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Beweeg met behulp van de pijl toetsen");
            Console.WriteLine("Bij te veel tekst kan je scrollen");
            Console.WriteLine("----------------------------------");
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
                ReservationManager reservationManager = new ReservationManager();
                Menus menus = new Menus();
                Login login = new Login();
                AdminControle controle = new AdminControle(menus);
                Console.Clear();
                Console.WriteLine("         Navigatiescherm          ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Beweeg met behulp van de pijl keys");
                Console.WriteLine("Bij te veel tekst kan je scrollen");
                Console.WriteLine("----------------------------------");
                string SelectedOption = Selector(Options);

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
                        controle.tablePage();
                        Console.Read();
                    }
                    else 
                    {
                        Console.WriteLine("Verkeerde inloggegevens");
                        Thread.Sleep(1500);
                        goto start;
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
                if (index == Options.Count - 1)
                {

                }
                else
                {
                    index++;
                }
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


