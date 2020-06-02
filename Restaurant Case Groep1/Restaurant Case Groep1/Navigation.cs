using System;

namespace Restaurant_Case_Groep1
{
	public class Navigation
	{
		public void navigation()
		{
            Console.CursorVisible = false;
            List<string> Options = new List<string>()
            {
                "Reserveringsscherm",
                "Menuscherm",
                "Inlogscherm",
                "Exit"
            };

            while (true)
            {
                string SelectedOption = Selector(Options);
                ReservationManager reservationmanager = new ReservationManager();
                Menus menus = new Menus();
                Login login = new Login();
                AdminPage page = new AdminPage();
                if (SelectedMenu == "Reserveringsscherm")
                {
                    Console.Clear();
                    reservationmanager.ReservationMenu();
                    Console.Read();
                }
                else if (SelectedMenu == "Menuscherm")
                {
                    Console.Clear();
                    menus.menuStart();
                    Console.Read();
                }
                else if (SelectedMenu == "Inlogscherm") 
                {
                    Console.Clear();
                    bool result = login.loginScreen();
                    if (result == true) 
                    {
                        page.PrintToday();
                        Console.ReadLine();
                    }
                    else 
                    {
                        Console.WriteLine("Verkeerde inloggegevens");
                    }

                }
                else if (SelectedMenu == "Exit")
                {
                    Environment.Exit(0);
                }
            }

        }
        public string Selector(List<string> Options)
        {
            for (int i = 0; i < Options.Count; i = i + 1)
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
                index -= 1;
            }
            else if (PressedKey.Key == ConsoleKey.DownArrow)
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

