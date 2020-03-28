using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorisatie
{
    class Program
    {
        static void Main(string[] args)
        {
    
            Login login = new Login();
            bool loginResult = login.loginScreen();
            if (loginResult == false)
            {
                Console.WriteLine("Verkeerde inloggegevens");
                login.loginScreen();
            }
            else
            {
                return; //Hier komt de verwijzing naar Admin Page
            }
        }
    }
}
