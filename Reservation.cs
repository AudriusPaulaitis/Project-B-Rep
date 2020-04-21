using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Case_Groep1
{
    class Reservation
    {   //Aantal reserveringen totaal en wanneer de reservering is gemaakt

        public static int Amount = 0;
        public DateTime CreationDate = DateTime.Now;

        //Variabelen dat veranderd kan worden

        public string name;
        public string email;
        public string phonenumber;
        public int capacity;
        public DateTime date;
        public DateTime edit;

        //Constructor

        public Reservation(string name, string email, string phonenumber, int capacity, DateTime date)
        {
            this.name = name;
            this.email = email;
            this.phonenumber = phonenumber;
            this.capacity = capacity;
            this.date = date;
            this.edit = DateTime.Now;
            Amount++;
        }

        //Methods

        //Print de attributes van reservering
        public void Print()
        {
            Console.WriteLine("Naam: " + name);
            Console.WriteLine("E-mail: " + email);
            Console.WriteLine("Telefoonnummer: " + phonenumber);
            Console.WriteLine("Aantal mensen: " + capacity);
            Console.WriteLine("Reservering is voor: " + date);
            Console.WriteLine("Deze reservering is gemaakt op: " + CreationDate);
            Console.WriteLine("Deze reservering is laatst bewerkt op: " + edit);

        }

    }
}
