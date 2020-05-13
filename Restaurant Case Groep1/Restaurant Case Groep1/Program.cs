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
            Navigation nav = new Navigation();
            nav.navigation();
        }
    }
}
