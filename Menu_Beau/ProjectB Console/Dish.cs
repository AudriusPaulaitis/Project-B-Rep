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

       // samen met de peercoach ben ik op dit gekomen. Als ik de json printen kwam er alleen een locatie uit en niet wat er in de json stond.
        public override string ToString()
        {
            return $"{this.Naam}: €{this.Prijs} \n {this. Beschrijving} \n {this.Allergenen} ";
        }
        // je kan lvie share rechts boven weer uit zetten :)

    }

}