using System;

namespace Restaurant_Case_Groep1
{
	public class Navigation
	{
		public void navigation()
		{
            Console.Write("\r\nKies een optie en druk enter: \n");
            Console.WriteLine("1) Reserveringscherm");
            Console.WriteLine("2) Menu");
            Console.WriteLine("3) Autorisatiescherm");
            Console.WriteLine("4) Afsluiten");
            Console.Write("\r\nKies een optie: ");
            // Instances
            ReservationManager reservationmanager = new ReservationManager();
            Menus menus = new Menus();
            Login login = new Login();
            AdminPage page = new AdminPage();

            switch (Console.ReadLine())
            {
                case "1":
                    reservationmanager.reservationMenu();
                    break;
                case "2":
                    menus.menuStart();
                    break;
                case "3":
                    bool result = login.loginScreen();
                    if (result == true)
                    {
                        page.PrintToday();
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Verkeerde inloggevens!");
                        break;
                    }
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Optie niet bekend");
                    break;
            }
        }
	}
}

