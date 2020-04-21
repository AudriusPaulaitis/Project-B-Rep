using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Case_Groep1
{
    class Menus
    {
        static int index = 0;
        //selectMenu laat een user een menu selecteren
        public void selectMenu()
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
        // Menu class zorgt voor de opmaak van het selecteren van een menu
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
    

