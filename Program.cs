using System;
using System.Collections.Generic;

namespace ProjectB_Console
{
    class Program
    {
        static int index = 0;
        private static void Main(string[] args)
        {

            Console.CursorVisible = false;
            List<string> KindOfMenu = new List<string>()
            {
                "Ochtend",
                "Middag",
                "Avond",
                "Terug"
            };

            while (true)
            {
                string SelectedMenu = Menu(KindOfMenu);
                if (SelectedMenu == "Ochtend")
                {
                    Console.Clear();
                    Console.WriteLine("Spaghetti"); Console.Read();
                }
                else if (SelectedMenu == "Terug")
                {
                    Environment.Exit(0);
                }
            }
        }
        private static string Menu(List<string> KindOfMenu) 
        {
            for (int i = 0; i < KindOfMenu.Count; i = i + 1)
            {
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

