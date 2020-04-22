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
                //Gaat naar reserveringsscherm
                case "1":
                    ReservationManager reservationmanager = new ReservationManager();
                    reservationmanager.reservationMenu();
                    break;
                //Gaat naar Menu's
                case "2":
                    Menus menus = new Menus();
                    menus.selectMenu();
                    break;
                //Gaat naar Loginscherm en dan naar adminpage als login lukt
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
                //Sluit de console
                case "4":
                    Environment.Exit(0);
                    break;
                //Als de gekozen optie niet bekend is
                default:
                    Console.WriteLine("Optie niet bekend");
                    break;
            }
        }
    }
}
