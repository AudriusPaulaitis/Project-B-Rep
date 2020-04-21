using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Case_Groep1
{
    class ReservationManager
    {
        //Reservering lijst
        public List<Reservation> Reservations = new List<Reservation>();

        //Reservering navigatie
        public void reservationMenu()
        {
            Console.WriteLine("Welkom bij het reserveringsscherm. Kies uit de volgende opties:");
            Console.WriteLine("1. Reservering maken ");
            Console.WriteLine("2. Reservering vinden ");
            Console.Write("Optie: ");
            switch (Console.ReadLine())
            {
                case "1":
                    makeReservation();
                    break;
                case "2":
                    findReservation();
                    break;

            }
        }

        //Functie dat reservering aanmaakt / Het vraagt voor details etc. en maakt uiteindelijk een reservering object aan van de RESERVATION class
        public void makeReservation()
        {   //Naam invoerC:\Users\APaul\Desktop\Restaurant Case\Restaurant Case Groep1\Restaurant Case Groep1\ReservationManager.cs
            Console.WriteLine("Type uw naam in.\n");
            string name = Console.ReadLine();
            while (name.Length < 3 || name.Length > 20)
            {
                if (name.Length < 3)
                {
                    Console.WriteLine("Type uw naam in.\n");
                    name = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Type een kortere naam in alstublieft.\n");
                    name = Console.ReadLine();
                }
            }

            //E-mail invoer
            Console.WriteLine();
            Console.WriteLine("Type uw e-mail in.\n");
            string email = Console.ReadLine();

            //Telefoonnummer invoer
            int num;
            Console.WriteLine();
            Console.WriteLine("Type uw telefoonnummer in.\n");
            string phonenumber = Console.ReadLine();
            while (phonenumber.Length != 10 || (!int.TryParse(phonenumber, out num)))
            {
                Console.WriteLine("Type een correct telefoonnummer in.\n");
                phonenumber = Console.ReadLine();
            }

            //Aantal personen reservering
            Console.WriteLine();
            Console.WriteLine("Voor hoeveel personen is de reservering? U kunt kiezen uit: 2 / 3 / 4 / 5\n");
            string capacitynum = Console.ReadLine();
            while (!int.TryParse(capacitynum, out num) || (capacitynum != "2" && capacitynum != "3" && capacitynum != "4" && capacitynum != "5"))
            {
                Console.WriteLine("Type een correct nummer in.\n");
                capacitynum = Console.ReadLine();
            }
            int capacity = Int32.Parse(capacitynum);

            //Tijd maand / dag / uur
            //Dictionary voor maand kiezen 
            Console.WriteLine();
            Dictionary<string, int> monthdic = new Dictionary<string, int>
            {
                {"januari", 1},
                {"februari", 2},
                {"maart", 3},
                {"april", 4 },
                {"mei", 5},
                {"juni",6 },
                {"juli", 7 },
                {"augustus",8 },
                {"september", 9 },
                {"oktober", 10 },
                {"november", 11 },
                {"december", 12 }
            };

            Console.WriteLine("Voor welk maand reserveert u?\n");
            string monthnum = Console.ReadLine();
            int month = 13;
            while (month > 12 || month <= 0)
            {
                if (monthdic.ContainsKey(monthnum))
                {
                    month = monthdic[monthnum];
                }
                else
                {
                    Console.WriteLine("Voer een correct maand in.\n");
                    monthnum = Console.ReadLine();
                }
            }

            //Dag
            Console.WriteLine();
            Console.WriteLine($"Voor welke dag van {monthnum} wilt u reserveren?\n");
            string daynum = Console.ReadLine();
            while ((!int.TryParse(daynum, out num)))
            {
                Console.WriteLine($"{daynum} {monthnum} bestaat niet. Voer alstublieft een valide dag in voor {monthnum}.\n");
                daynum = Console.ReadLine();
            }

            int days = 0;

            //Checkt hoeveel dagen er in de maand zijn
            if (monthnum == "februari")
            {
                days = 29;
            }
            else if (monthdic[monthnum] % 2 == 0)
            {
                days = 30;
            }
            else
            {
                days = 31;
            }

            //Checkt of die dag wel bestaat in de maand
            while (Int32.Parse(daynum) <= 0 || Int32.Parse(daynum) > days)
            {
                Console.WriteLine($"{daynum} {monthnum} bestaat niet. Voer alstublieft een valide dag in voor {monthnum}.\n");
                daynum = Console.ReadLine();
            }

            int day = Int32.Parse(daynum);

            //Tijd

            Console.WriteLine();
            Console.WriteLine("We zijn open van 8:00 tot 22:30. Voer in de tijd van de reservering.\n");
            DateTime time;
            while (true)
            {
                string timestr = Console.ReadLine();
                if (!DateTime.TryParse(timestr, out time))
                {
                    Console.WriteLine("Tijd moet in formaat HH:MM, HH moet onder 25 zijn en MM moet onder 60 zijn.\n");
                }
                else if ((time.Hour < 8 || time.Hour >= 23 || (time.Hour >= 22 && time.Minute >= 30)))
                {
                    Console.WriteLine("Reserveringen zijn alleen beschikbaar tussen 08:00 en 22:30.\n");
                }
                else if (time.Minute % 5 != 0)
                {
                    Console.WriteLine($"{time.ToString("HH:mm")} is niet beschikbaar.");
                    Console.WriteLine($"Keuze uit {time.Hour}:00 , {time.Hour}:05, {time.Hour}:10, {time.Hour}:15 enzovoort.\n");
                }
                else
                {
                    break; // Hier stopt de while loop, als we hier zijn dan is de tijd correct
                }
            }

            //Bevestiging
            Console.WriteLine();
            Console.WriteLine("Zijn deze gegevens correct?");
            Console.WriteLine($"Naam: {name}");
            Console.WriteLine($"E-mail: {email}");
            Console.WriteLine($"Telefoonnummer: {phonenumber}");
            Console.WriteLine($"Aantal personen: {capacitynum}");
            Console.WriteLine($"Gereserveerd voor: {daynum} {monthnum} {time.ToString("HH:mm")}\n");
            Console.WriteLine("ja/nee?");
            Console.WriteLine();
            string confirmation = Console.ReadLine();

            //Filter zodat alleen ja / nee ingevoerd kan worden
            while (confirmation != "ja" && confirmation != "nee")
            {
                Console.WriteLine("Voer alstublieft alleen ja of nee in.\n");
                confirmation = Console.ReadLine();
            }

            if (confirmation == "ja")
            {
                Reservations.Add(new Reservation(name, email, phonenumber, capacity, new DateTime(2020, month, day, time.Hour, time.Minute, 0)));
                Console.WriteLine();
                Console.WriteLine("Reservering is aangemaakt.");
                Console.WriteLine();
            }
            else
            {
                makeReservation();
            }

        }

        //Functie dat hele lijst reserveringen print
        public void PrintReservations()
        {
            foreach (Reservation reservation in Reservations)
            {
                reservation.Print();
                Console.WriteLine();
            }
        }

        //Functie dat een reservering verwijdert
        public void deleteReservation(Reservation currentreservation, int listnumber)
        {
            Reservations.RemoveAt(listnumber);
            currentreservation = null;
            Console.WriteLine("De reservering is sucessvol verwijderd.\n");
        }

        //Functie dat een reservering bewerkt
        public void editReservation(Reservation currentreservation)
        {
            Console.WriteLine("Huidige gegevens.\n");
            currentreservation.Print();
            Console.WriteLine("\nAls u iets wil veranderen kies dan een van deze opties.\n1: Naam\n2: E-mail\n3: Telefoonnummer\n4: Aantal personen\n5: Tijd van reservering\nAls u niks wilt veranderen kies dan 0.\n");
            string decision = Console.ReadLine();

            //Filter voor keuzes

            while (decision != "0" && decision != "1" && decision != "2" && decision != "3" && decision != "4" && decision != "5")
            {
                Console.WriteLine("Voer alstublieft alleen 0 tot en met 5 in.\n");
            }

            //Naam veranderen

            if (decision == "1")
            {
                Console.WriteLine("Type de nieuwe naam in.\n");
                string name = Console.ReadLine();
                while (name.Length < 3 || name.Length > 20)
                {
                    if (name.Length < 3)
                    {
                        Console.WriteLine("Type uw naam in.\n");
                        name = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Type een kortere naam in alstublieft.\n");
                        name = Console.ReadLine();
                    }
                }
                currentreservation.name = name;
                currentreservation.edit = DateTime.Now;
                editReservation(currentreservation);
            }
            //E-mail veranderen

            else if (decision == "2")
            {
                Console.WriteLine();
                Console.WriteLine("Type het nieuwe e-mail in.\n");
                string email = Console.ReadLine();
                currentreservation.email = email;
                currentreservation.edit = DateTime.Now;
                editReservation(currentreservation);
            }
            //Telefoonnummer veranderen

            else if (decision == "3")
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Type het nieuwe telefoonnummer in.\n");
                string phonenumber = Console.ReadLine();
                while (phonenumber.Length != 10 || (!int.TryParse(phonenumber, out num)))
                {
                    Console.WriteLine("Type een correct telefoonnummer in.\n");
                    phonenumber = Console.ReadLine();
                }
                currentreservation.phonenumber = phonenumber;
                currentreservation.edit = DateTime.Now;
                editReservation(currentreservation);
            }
            //Aantal personen veranderen

            else if (decision == "4")
            {
                int num;
                Console.WriteLine();
                Console.WriteLine("Voor hoeveel personen is de reservering? U kunt kiezen uit: 2 / 3 / 4 / 5\n");
                string capacitynum = Console.ReadLine();
                while (!int.TryParse(capacitynum, out num) || (capacitynum != "2" && capacitynum != "3" && capacitynum != "4" && capacitynum != "5"))
                {
                    Console.WriteLine("Type een correct nummer in.\n");
                    capacitynum = Console.ReadLine();
                }
                int capacity = Int32.Parse(capacitynum);
                currentreservation.capacity = capacity;
                currentreservation.edit = DateTime.Now;
                editReservation(currentreservation);
            }
            //Tijd veranderen

            else if (decision == "5")
            {
                Console.WriteLine();
                Console.WriteLine("We zijn open van 8:00 tot 22:30. Voer de nieuwe tijd van de reservering in.\n");
                DateTime time;
                while (true)
                {
                    string timestr = Console.ReadLine();
                    if (!DateTime.TryParse(timestr, out time))
                    {
                        Console.WriteLine("Tijd moet in formaat HH:MM, HH moet onder 25 zijn en MM moet onder 60 zijn.\n");
                    }
                    else if ((time.Hour < 8 || time.Hour >= 23 || (time.Hour >= 22 && time.Minute >= 30)))
                    {
                        Console.WriteLine("Reserveringen zijn alleen beschikbaar tussen 08:00 en 22:30.\n");
                    }
                    else if (time.Minute % 5 != 0)
                    {
                        Console.WriteLine($"{time.ToString("HH:mm")} is niet beschikbaar.");
                        Console.WriteLine($"Keuze uit {time.Hour}:00 , {time.Hour}:05, {time.Hour}:10, {time.Hour}:15 enzovoort.\n");
                    }
                    else
                    {
                        break; // Hier stopt de while loop, als we hier zijn dan is de tijd correct
                    }
                }
                currentreservation.date = new DateTime(2020, currentreservation.date.Month, currentreservation.date.Day, time.Hour, time.Minute, 0);
                currentreservation.edit = DateTime.Now;
                editReservation(currentreservation);
            }
            else
            {
                Console.WriteLine();
            }

        }

        //Functie dat reserveringen vind op naam/telefoonnummer/datum --- dit leidt ook tot het kiezen van wat je met de reservering wilt doen na het vinden
        public void findReservation()
        {
            //3 manieren om reservering te vinden.

            Console.WriteLine("Op welke manier wilt u de reservering vinden?");
            Console.WriteLine("Wilt u de reservering vinden op naam, telefoonnummer of datum?");
            Console.WriteLine("Voor naam voer in 0, voor telefoonnummer voer in 1 en voor datum voer in 2.\n");
            string findmethod = Console.ReadLine();
            Console.WriteLine();

            while (findmethod != "0" && findmethod != "1" && findmethod != "2")
            {
                Console.WriteLine("Voer alstublieft 0, 1 of 2 in.");
                findmethod = Console.ReadLine();
            }

            if (findmethod == "0")
            {
                //Methode op naam

                Console.WriteLine("Wat is de naam van de persoon die de reservering heeft gereserveerd?");
                Console.WriteLine();
                string name = Console.ReadLine();
                Console.WriteLine();
                bool found = true;
                Reservation foundreservation;
                bool namecheck = false;
                for (int i = 0; i < Reservations.Count; i++)
                {
                    if (name == Reservations[i].name)
                    {
                        Console.WriteLine("Dit is wat er is gevonden.");
                        Console.WriteLine();
                        Reservations[i].Print();
                        namecheck = found;
                    }
                }

                Console.WriteLine();
                if (namecheck == true)
                {
                    Console.WriteLine("Was dit de reservering die je wou vinden?");
                    Console.WriteLine();
                    Console.WriteLine("ja/nee?\n");
                    string confirmation = Console.ReadLine();
                    Console.WriteLine();

                    //Filter zodat alleen ja / nee ingevoerd kan worden
                    while (confirmation != "ja" && confirmation != "nee")
                    {
                        Console.WriteLine("Voer alstublieft alleen ja of nee in.");
                        confirmation = Console.ReadLine();
                    }

                    if (confirmation == "ja")
                    {
                        for (int i = 0; i < Reservations.Count; i++)
                        {
                            if (name == Reservations[i].name)
                            {
                                foundreservation = Reservations[i];
                                Console.WriteLine("Mooi, wat wilt u ermee doen?");
                                Console.WriteLine();
                                Console.WriteLine("Kies 1 om te verwijderen en 2 om te bewerken.\n");
                                string decision = Console.ReadLine();

                                while (decision != "1" && decision != "2")
                                {
                                    Console.WriteLine("Voor alstublieft alleen 1 of 2 in.");
                                    decision = Console.ReadLine();
                                }

                                if (decision == "1")
                                {
                                    Console.WriteLine();
                                    deleteReservation(foundreservation, i);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    editReservation(foundreservation);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kies dan alstublieft een ander optie van zoeken.");
                        Console.WriteLine();
                        findReservation();
                    }

                }
                else
                {
                    Console.WriteLine("We hebben geen reservering gevonden op die naam.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }
            }
            else if (findmethod == "1")
            {

                //Methode op telefoonnummer

                Console.WriteLine("Wat is de telefoonnummer van de persoon die de reservering heeft gereserveerd?");
                Console.WriteLine();
                string phonenumber = Console.ReadLine();
                Console.WriteLine();
                Reservation foundreservation;
                bool found = true;
                bool namecheck = false;
                for (int i = 0; i < Reservations.Count; i++)
                {
                    if (phonenumber == Reservations[i].phonenumber)
                    {
                        Console.WriteLine("Dit is wat er is gevonden.");
                        Console.WriteLine();
                        Reservations[i].Print();
                        namecheck = found;
                    }
                }

                Console.WriteLine();
                if (namecheck == true)
                {
                    Console.WriteLine("Was dit de reservering die je wou vinden?");
                    Console.WriteLine();
                    Console.WriteLine("ja/nee?\n");
                    string confirmation = Console.ReadLine();
                    Console.WriteLine();

                    //Filter zodat alleen ja / nee ingevoerd kan worden
                    while (confirmation != "ja" && confirmation != "nee")
                    {
                        Console.WriteLine("Voer alstublieft alleen ja of nee in.");
                        confirmation = Console.ReadLine();
                    }

                    if (confirmation == "ja")
                    {
                        for (int i = 0; i < Reservations.Count; i++)
                        {
                            if (phonenumber == Reservations[i].phonenumber)
                            {
                                foundreservation = Reservations[i];
                                Console.WriteLine("Mooi, wat wilt u ermee doen?");
                                Console.WriteLine();
                                Console.WriteLine("Kies 1 om te verwijderen en 2 om te bewerken.\n");
                                string decision = Console.ReadLine();

                                while (decision != "1" && decision != "2")
                                {
                                    Console.WriteLine("Voor alstublieft alleen 1 of 2 in.");
                                    decision = Console.ReadLine();
                                }

                                if (decision == "1")
                                {
                                    Console.WriteLine();
                                    deleteReservation(foundreservation, i);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    editReservation(foundreservation);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kies dan alstublieft een ander optie van zoeken.");
                        Console.WriteLine();
                        findReservation();
                    }

                }
                else
                {
                    Console.WriteLine("We hebben geen reservering gevonden op die telefoonnummer.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }
            }
            else //Datum tijd manier
            {
                DateTime date;
                Console.WriteLine("Type in de datum en tijd van de reservering in formaat: YY-MM-DD HH:MM");
                Console.WriteLine("Bijvoorbeeld: 2020-12-21 18:30");
                Console.WriteLine();

                bool found = true;
                bool namecheck = false;
                Reservation foundreservation;
                while (true)
                {
                    string dateinput = Console.ReadLine();
                    if (!DateTime.TryParse(dateinput, out date))
                    {
                        Console.WriteLine("Datun en tijd moet in formaat YY-MM-DD HH:MM.");
                        Console.WriteLine();
                    }
                    else
                    {
                        break; // Hier stopt de while loop, als we hier zijn dan is het correct
                    }
                }

                Console.WriteLine();

                for (int i = 0; i < Reservations.Count; i++)
                {
                    if (date == Reservations[i].date)
                    {
                        Console.WriteLine("Dit is wat er is gevonden.");
                        Console.WriteLine();
                        Reservations[i].Print();
                        namecheck = found;
                    }
                }

                Console.WriteLine();
                if (namecheck == true)
                {
                    Console.WriteLine("Was dit de reservering die je wou vinden?");
                    Console.WriteLine();
                    Console.WriteLine("ja/nee?\n");
                    string confirmation = Console.ReadLine();
                    Console.WriteLine();

                    //Filter zodat alleen ja / nee ingevoerd kan worden
                    while (confirmation != "ja" && confirmation != "nee")
                    {
                        Console.WriteLine("Voer alstublieft alleen ja of nee in.");
                        confirmation = Console.ReadLine();
                    }

                    if (confirmation == "ja")
                    {
                        for (int i = 0; i < Reservations.Count; i++)
                        {
                            if (date == Reservations[i].date)
                            {
                                foundreservation = Reservations[i];
                                Console.WriteLine("Mooi, wat wilt u ermee doen?");
                                Console.WriteLine();
                                Console.WriteLine("Kies 1 om te verwijderen en 2 om te bewerken.\n");
                                string decision = Console.ReadLine();

                                while (decision != "1" && decision != "2")
                                {
                                    Console.WriteLine("Voor alstublieft alleen 1 of 2 in.");
                                    decision = Console.ReadLine();
                                }

                                if (decision == "1")
                                {
                                    Console.WriteLine();
                                    deleteReservation(foundreservation, i);
                                }
                                else
                                {
                                    Console.WriteLine();
                                    editReservation(foundreservation);
                                }
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Kies dan alstublieft een ander optie van zoeken.");
                        Console.WriteLine();
                        findReservation();
                    }

                }
                else
                {
                    Console.WriteLine("We hebben geen reservering gevonden op die datum en tijd.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }

            }

        }

    }
}

