using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB_Console
{
    public class Dish
    {
        public string Naam { get; set; }
        public int Prijs { get; set; }
        public string Beschrijving { get; set; }
        public string Allergenen { get; set; }

        public override string ToString()
        {
            return $"{this.Naam}: €{this.Prijs}" ;
        }

    }

}