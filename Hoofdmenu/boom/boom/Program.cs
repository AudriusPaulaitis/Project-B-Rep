using System;
 
namespace boom
    {
        class Program
        {
            static void Main(string[] args)

        {
            /// een while loop maken om in het hoofdmenu te blijven zolang de gebruiker niet op exit drukt

            bool Menu = true;

            while (Menu)
                {
                    Menu = MainMenu();
                }
            }
            private static bool MainMenu()
            {
           /// simpele print statements om de gebruiker op de hoogte te stellen van wat hij of zij ziet.

            Console.Write("\r\nKies een optie en druk enter: \n");

            Console.WriteLine("1) Reserveringscherm");

            Console.WriteLine("2) Menu");

            Console.WriteLine("3) Autorisatiescherm");

            Console.WriteLine("4) Afsluiten");

            Console.Write("\r\nKies een optie: ");


            switch (Console.ReadLine())
                {

                /// switch methode gebruikt met readline om te lezen wat de gebruiker typt om zo bepaalde cases te triggeren. als iets in true returned dan gaat die naar
                /// naar het volgende pagina switchen  en alle andere blijven vals. zolang de gebruiker geen 4 returned blijft de while loop actief te laten.
             


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

                /// default zorgt ervoor dat zolang er geen geldige optie gekozen blijft de while loop actief.

            }
            }
            private static void Reserveringscherm()
            {

            /// hier komt dan het reserveringsscherm

            Console.Clear();

            Console.WriteLine("Binnenkort: reserveringscherm");

            }
        private static void Menus()
        {
            /// hier komt dan menu

            Console.Clear();

            Console.WriteLine("binnenkort: Menukaart");

        }
        private static void Author()
        {
            /// hier komt dan authorisatiescherm

            Console.Clear();

            Console.WriteLine("binnenkort: inlogpagina");

        }
        }
    }