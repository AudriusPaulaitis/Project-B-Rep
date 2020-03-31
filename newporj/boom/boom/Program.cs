using System;
 
namespace boom
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool Menu = true;
                while (Menu)
                {
                    Menu = MainMenu();
                }
            }
            private static bool MainMenu()
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
                        Reserveringscherm();
                        return true;
                    case "2":
                        Menus();
                        return true;
                    case "3":
                        Author();
                        return true;
                    case "4":
                        return false;
                    default:
                        return true;
                    
                }
            }
            private static void Reserveringscherm()
            {
                Console.Clear();
                Console.WriteLine("Binnenkort: reserveringscherm");

            }
        private static void Menus()
        {
            Console.Clear();
            Console.WriteLine("binnenkort: Menukaart");

        }
        private static void Author()
        {
            Console.Clear();
            Console.WriteLine("binnenkort: inlogpagina");

        }
        }
    }