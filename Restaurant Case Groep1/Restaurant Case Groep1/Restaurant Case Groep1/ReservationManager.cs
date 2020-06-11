using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Restaurant_Case_Groep1
{   //Steven Ren
    class ReservationManager
    {
        //Reservering lijst
        //Lijst bestaat uit reserveringen die je haalt van een JSON file. De JSON objecten worden geconvert naar C# Reservation OBJECTS en dat zit dus in de lijst
        public List<Reservation> Reservations = JsonConvert.DeserializeObject<List<Reservation>>(File.ReadAllText("reservations.json"));

        //Reservering navigatie
        public void reservationMenu()
        {
            Console.WriteLine("Welkom bij het reserveringsscherm. Kies uit de volgende opties:");
            Console.WriteLine("1. Reservering maken ");
            Console.WriteLine("2. Reservering vinden ");
            Console.WriteLine("3. Print reserveringen van vandaag");
            Console.Write("Optie: ");
            switch (Console.ReadLine())
            {
                case "1":
                    makeReservation();
                    break;
                case "2":
                    findReservation();
                    break;
                case "3":
                    PrintToday();
                    break;

            }
        }
        //Functie dat reservering aanmaakt / Het vraagt voor details etc. en maakt uiteindelijk een reservering object aan van de RESERVATION class
        public void makeReservation()
        {   //Naam invoer
            Console.WriteLine("Type uw naam in.\n");
            string name = Console.ReadLine();
            Console.WriteLine();
            while (name.Length < 3 || name.Length > 20)
            {
                if (name.Length < 3)
                {
                    Console.WriteLine("Type een langere naam in alstublieft.\n");
                    name = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Type een kortere naam in alstublieft.\n");
                    name = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            Console.Clear();

            //E-mail invoer
            Console.WriteLine("Type uw e-mail in.\n");
            string email = Console.ReadLine();
            char[] emailverify = email.ToCharArray();
            while (!(emailverify.Contains('@')))
            {
                Console.WriteLine();
                Console.WriteLine("Uw e-mail moet @ bevatten. Type uw e-mail alstublieft opnieuw in.");
                Console.WriteLine();
                email = Console.ReadLine();
                emailverify = email.ToCharArray();
            }


            Console.Clear();

            //Telefoonnummer invoer
            int num;
            Console.WriteLine("Type uw telefoonnummer in.\n");
            string phonenumber = Console.ReadLine();
            while (phonenumber.Length != 10 || (!int.TryParse(phonenumber, out num)))
            {
                Console.WriteLine();
                if (!int.TryParse(phonenumber, out num))
                {
                    Console.WriteLine("Een telefoonnummer bevat alleen nummers, type alstublieft een telefoonnummer in met 10 nummers.\n");
                    phonenumber = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Type een telefoonnummer in met 10 nummers alstublieft.\n");
                    phonenumber = Console.ReadLine();
                }
            }

            Console.Clear();

            //Aantal personen reservering
            Console.WriteLine("Voor hoeveel personen is de reservering? U kunt kiezen uit: 2 / 3 / 4 / 5\n");
            string capacitynum = Console.ReadLine();
            while (!int.TryParse(capacitynum, out num) || (capacitynum != "2" && capacitynum != "3" && capacitynum != "4" && capacitynum != "5"))
            {
                if (!int.TryParse(capacitynum, out num))
                {
                    Console.WriteLine();
                    Console.WriteLine("U kunt alleen de nummers: 2/3/4/5 invoeren en geen andere tekens.");
                    Console.WriteLine("Voer alstublieft een correct nummer in.\n");
                    capacitynum = Console.ReadLine();
                }
                Console.WriteLine();
                Console.WriteLine("U kunt alleen kiezen uit: 2/3/4/5");
                Console.WriteLine("Voer alstublieft een correct nummer in.\n");
                capacitynum = Console.ReadLine();
            }
            int capacity = Int32.Parse(capacitynum);

            Console.Clear();

            //Tijd maand / dag / uur
            //Dictionary voor maand kiezen 
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

            Console.WriteLine("Voor welk maand reserveert u?\nU kunt de naam van de maand invoeren. Bijvoorbeeld: januari.\n");
            string monthnumverify = Console.ReadLine();
            string monthnum = monthnumverify.ToLower();
            int month = 13;
            while (month > 12 || month <= 0)
            {
                Console.WriteLine();
                if (monthdic.ContainsKey(monthnum))
                {
                    month = monthdic[monthnum];
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{monthnumverify} is geen geldig maand.\nDit zijn de geldige maanden die u kunt invoeren.\n");
                    Console.WriteLine("januari\nfebruari\nmaart\napril\nmei\njuni\njuli\naugustus\nseptember\noktober\nnovember\ndecember\n");
                    monthnumverify = Console.ReadLine();
                    monthnum = monthnumverify.ToLower();
                }
            }

            //Dag
            Console.Clear();

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

            //Checkt of die dag wel bestaat in de maand en kijkt ook naar invoer fouten.
            Console.WriteLine($"Voor welke dag van {monthnum} wilt u reserveren?\nU kunt de dagen 1 - {days} invoeren.");
            Console.WriteLine();
            string daynum = Console.ReadLine();
            while ((!int.TryParse(daynum, out num)) || Int32.Parse(daynum) <= 0 || Int32.Parse(daynum) > days)
            {
                Console.Clear();
                Console.WriteLine($"{daynum} {monthnum} bestaat niet. Voer alstublieft een valide dag in voor {monthnum}.\n Voor {monthnum} kunt u 1 - {days} invoeren.");
                Console.WriteLine();
                daynum = Console.ReadLine();
            }

            int day = Int32.Parse(daynum);

            //Tijd

            Console.Clear();
            Console.WriteLine("We zijn open van 8:00 tot 22:30. Voer in de tijd van de reservering in HH:MM formaat.\n");
            DateTime time;
            while (true)
            {
                string timestr = Console.ReadLine();
                Console.WriteLine();
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
                    Console.WriteLine($"Keuze uit {time.Hour}:00 , {time.Hour}:05, {time.Hour}:10, {time.Hour}:15 enzovoort met intervallen van 5 minuten.\n");
                }
                else
                {
                    break; // Hier stopt de while loop, als we hier zijn dan is de tijd correct
                }
            }

            //Bevestiging
            Console.Clear();
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
                string jsonstringreservations = JsonConvert.SerializeObject(Reservations, Formatting.Indented);
                StreamWriter sw = new StreamWriter("reservations.json");
                sw.WriteLine(jsonstringreservations);
                sw.Flush();
                sw.Close();
                Console.Clear();
                Console.WriteLine("Reservering is aangemaakt.");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
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

        //Functie dat reserveringen print van vandaag
        public void PrintToday()
        {
            //Aangeven de detum van vandaag
            DateTime today = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Reserveringen");
            Console.WriteLine("Datum= " + today);
            Console.WriteLine("--------------------------------------------------");

            bool anyReservation = false;

            foreach (Reservation reservation in Reservations)
            {
                if (reservation.date.Day == today.Day)
                {
                    reservation.Print();
                    Console.WriteLine();
                    anyReservation = true;
                }
                if (anyReservation == false)
                {
                    Console.WriteLine("Geen reserveringen vandaag!");
                }
            }


            Console.WriteLine("--------------------------------------------------");
        }

        //Functie dat een reservering verwijdert
        public void deleteReservation(Reservation currentreservation, int listnumber)
        {
            Reservations.RemoveAt(listnumber);
            currentreservation = null;
            Console.Clear();
            Console.WriteLine("De reservering is sucessvol verwijderd.\n");
            string jsonstringreservations = JsonConvert.SerializeObject(Reservations, Formatting.Indented);
            StreamWriter sw = new StreamWriter("reservations.json");
            sw.WriteLine(jsonstringreservations);
            sw.Flush();
            sw.Close();
        }

        //Functie dat een reservering bewerkt
        public void editReservation(Reservation currentreservation)
        {
            Console.Clear();
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
                Console.WriteLine();
                Console.WriteLine("Type de nieuwe naam in.\n");
                string name = Console.ReadLine();
                while (name.Length < 3 || name.Length > 20)
                {
                    if (name.Length < 3)
                    {
                        Console.WriteLine("Type een langere naam in alstublieft.\n");
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
                char[] emailverify = email.ToCharArray();
                while (!(emailverify.Contains('@')))
                {
                    Console.WriteLine();
                    Console.WriteLine("Uw e-mail moet @ bevatten. Type uw e-mail alstublieft opnieuw in.");
                    Console.WriteLine();
                    email = Console.ReadLine();
                    emailverify = email.ToCharArray();
                }
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
                    Console.WriteLine();
                    if (!int.TryParse(phonenumber, out num))
                    {
                        Console.WriteLine("Een telefoonnummer bevat alleen nummers, type alstublieft een telefoonnummer in met 10 nummers.\n");
                        phonenumber = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Type een telefoonnummer in met 10 nummers alstublieft.\n");
                        phonenumber = Console.ReadLine();
                    }
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
                    while (!int.TryParse(capacitynum, out num))
                    {
                        Console.WriteLine();
                        Console.WriteLine("U kunt alleen de nummers: 2/3/4/5 invoeren en geen andere tekens.");
                        Console.WriteLine("Voer alstublieft een correct nummer in.\n");
                        capacitynum = Console.ReadLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("U kunt alleen kiezen uit: 2/3/4/5");
                    Console.WriteLine("Voer alstublieft een correct nummer in.\n");
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
                Console.WriteLine("We zijn open van 8:00 tot 22:30. Voer de nieuwe tijd van de reservering in HH:MM formaat.\n");
                DateTime time;
                while (true)
                {
                    string timestr = Console.ReadLine();
                    Console.WriteLine();
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
                        Console.WriteLine($"Keuze uit {time.Hour}:00 , {time.Hour}:05, {time.Hour}:10, {time.Hour}:15 enzovoort met intervallen van 5 minuten.\n");
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
            string jsonstringreservations = JsonConvert.SerializeObject(Reservations, Formatting.Indented);
            StreamWriter sw = new StreamWriter("reservations.json");
            sw.WriteLine(jsonstringreservations);
            sw.Flush();
            sw.Close();
        }

        //Functie dat reserveringen vind op naam/telefoonnummer/datum --- dit leidt ook tot het kiezen van wat je met de reservering wilt doen na het vinden
        public void findReservation()
        {
            //3 manieren om reservering te vinden.
            Console.WriteLine("Op welke manier wilt u de reservering vinden?\n");
            Console.WriteLine("Wilt u de reservering vinden op naam, telefoonnummer of datum en tijd?\n");
            Console.WriteLine("Voor naam voer in 0, voor telefoonnummer voer in 1 en voor datum en tijd voer in 2.\n");
            string findmethod = Console.ReadLine();

            while (findmethod != "0" && findmethod != "1" && findmethod != "2")
            {
                Console.WriteLine();
                Console.WriteLine("Voer alstublieft alleen 0, 1 of 2 in. Andere tekens zijn niet toegestaan.\n");
                findmethod = Console.ReadLine();
            }

            if (findmethod == "0")
            {
                //Methode op naam
                Console.Clear();
                Console.WriteLine("Onder welke naam staat de reservering?\nLet op het is hoofdletter gevoelig dus voer alstublieft de naam precies in.");
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
                        Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("We hebben geen reservering gevonden op die naam.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }
            }
            else if (findmethod == "1")
            {

                //Methode op telefoonnummer
                Console.Clear();
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
                        Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("We hebben geen reservering gevonden op die telefoonnummer.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }
            }
            else //Datum tijd manier
            {

                Console.Clear();
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
                        Console.WriteLine();
                        Console.WriteLine("Datum en tijd moet in formaat YY-MM-DD HH:MM.");
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
                        Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("We hebben geen reservering gevonden op die datum en tijd.");
                    Console.WriteLine("Probeer alstublieft opnieuw of kies een ander optie van vinden.");
                    Console.WriteLine();
                    findReservation();
                }

            }

        }

    }
}
