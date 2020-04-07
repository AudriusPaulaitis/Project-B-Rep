using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Case_Groep1
{
    //class Program runt het hele programma
    class Program
    {
        // In de main kan de user door verschillende keuzes navigeren
        static void Main(string[] args)
        {
            Console.Write("\r\nKies een optie en druk enter: \n");
            Console.WriteLine("1) Reserveringscherm");
            Console.WriteLine("2) Menu");
            Console.WriteLine("3) Autorisatiescherm");
            Console.WriteLine("4) Afsluiten");
            Console.Write("\r\nKies een optie: ");

            switch (Console.ReadLine())
            {
                case "1":
                    //reservation();
                case "2":
                    Menus menus = new Menus();
                    menus.selectMenu();
                    break;
                case "3":
                    Login login = new Login();
                    bool result = login.loginScreen();
                    if (result == true)
                    {
                        //adminpage();
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
