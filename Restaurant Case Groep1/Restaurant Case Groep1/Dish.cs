using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Case_Groep1
{
    public class Dish
    {
        public string Naam { get; set; }
        public int Prijs { get; set; }
        public string Beschrijving { get; set; }
        public string Allergenen { get; set; }

       // samen met de peercoach ben ik op dit gekomen. Als ik de json printen kwam er alleen een locatie uit en niet wat er in de json stond.
       // Door de functies binnen de string te returnen kan ik het euro teken voor de int prijs te zetten.
        public override string ToString()
        {
            return $"{this.Naam}: €{this.Prijs} \n {this. Beschrijving} \n {this.Allergenen} ";
        }
        

    }

}