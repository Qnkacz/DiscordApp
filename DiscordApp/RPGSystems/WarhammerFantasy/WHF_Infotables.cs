using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.WarhammerFantasy
{
    public class WHF_Infotables
    {
        public int walka_wrecz;
        public int strzelectwo;
        public int krzepa;
        public int odpowrnosc;
        public int zrecznosc;
        public int inteligencjal;
        public int sila_woli;
        public int Oglada;
        public int ataki;
        public int zywotnosc = 999;
        public int sila;
        public int wytrzymalosc;
        public int szybkosc;
        public int magia;
        public int obled;
        public int przeznaczenie = 999;
        public int wysokosc;
        public bool plec = true; // false - kobieta, true - mezczyzna
        public string plec_string;
        public List<string> umiejetnosci = new List<string>();
        public List<string> zdolnosci = new List<string>();
        public string Race;
        public string Profesja;
        public int Waga;
        public string[] losowa_umiejetnosc =
     {
            "bardzo silny","bardzo szybki","błyskotliwy","bystry wzrok","charyzmatyczny","czuł słuch","geniusz arytmetyczny","krzepki","naśladowca","niezwykle odporny",
            "oburecznosc","odpornosc na choroby","odpornosc na magie","odpornosc na trucizny","odpornosc psychiczna","opanowanie","strzelec wyborowy","szczescie",
            "szósty zmysł","szybki refleks","twardziel","urodzony wojownik","widzenie w ciemnosci"
        };
        public string[] profesje =
        {
            "akolita","banita","berserker z norski","chłop","ciura obozowa","cyrkowiec","Cyrulik","Fanatyk","Flisak","Giermiek","Gladiator","Goniec","górnik","Guślerz","Hiena cmentarna",
            "Kanciarz","Kozak kislevski","Leśnik","Łowca","Łowca nagród","Mieszczanin","Mytnik","najemnik","ochotnik","ochroniarzx","Oprych","paź","podżegacz","porywacz zwłok","Posłaniec",
            "przemytnik","Przepatrywacz","Rybak","Rzecznik rodu","Rzemieślnik","Rzezimieszek","skryba","Sługa","Strażnik","Strażnik","Strażnik dróg","sttażnik pól","Strażnik wiezienny",
            "Szczurołap","Szermierz estalijski","Szlachcic","Smieciarz","Tarczoenik","Uczeń czarodzieja","węglarz","Włóczykij","wojownik klanowy","woźnica","zabójca troli","zarządca",
            "złodziej","żak","żeglarz","Żołnierz","Zołnierz okrętowy"
        };

        public List<string> ProfesjeHuman = new List<string>();
        public List<string> ProfesjeElf = new List<string>();
        public List<string> ProfesjeDwarf = new List<string>();
        public List<string> ProfesjeHalfling = new List<string>();
        private object user;

        public enum race { human, elf, krasnolud, nizlioek };
        public WHF_Infotables()
        {
            ProfesjeHuman = CreateHumanProfesionList();
            ProfesjeElf = createElfProfesionList();
            ProfesjeDwarf = createDwarfProfesionList();
            ProfesjeHalfling = CreateHalflingProfesionList();
        }

        private List<string> CreateHalflingProfesionList()
        {
            //(Number == 2 || Number == 5 || Number == 6 || Number == 7 || Number == 15 || Number == 16 || Number == 19 || Number == 20 || Number == 21 || Number == 22 || Number == 23
            //|| Number == 24 || Number == 28 || Number == 27 || Number == 29 || Number == 30 || Number == 33 || Number == 34 || Number == 36 || Number == 39 || Number == 40 || Number == 41 || Number == 42
            //|| Number == 44 || Number == 47 || Number == 51 || Number == 50 || Number == 56 || Number == 57 || Number == 59);
            List<string> returned = new List<string>();
            returned.Add(profesje[1]);
            returned.Add(profesje[4]);
            returned.Add(profesje[5]);
            returned.Add(profesje[6]);
            returned.Add(profesje[14]);
            returned.Add(profesje[15]);
            returned.Add(profesje[18]);
            returned.Add(profesje[19]);
            returned.Add(profesje[20]);
            returned.Add(profesje[21]);
            returned.Add(profesje[22]);
            returned.Add(profesje[23]);
            returned.Add(profesje[27]);
            returned.Add(profesje[26]);
            returned.Add(profesje[28]);
            returned.Add(profesje[29]);
            returned.Add(profesje[32]);
            returned.Add(profesje[33]);
            returned.Add(profesje[35]);
            returned.Add(profesje[38]);
            returned.Add(profesje[39]);
            returned.Add(profesje[40]);
            returned.Add(profesje[41]);
            returned.Add(profesje[43]);
            returned.Add(profesje[46]);
            returned.Add(profesje[50]);
            returned.Add(profesje[49]);
            returned.Add(profesje[55]);
            returned.Add(profesje[56]);
            returned.Add(profesje[58]);

            return returned;
        }

        private List<string> createDwarfProfesionList()
        {
            //(Number == 2 || Number == 6 || Number == 11 || Number == 12 || Number == 13 || Number == 15 || Number == 19 || Number == 21 || Number == 22 || Number == 23
            //|| Number == 24 || Number == 25 || Number == 28 || Number == 36 || Number == 37 || Number == 38 || Number == 39 || Number == 40 || Number == 43
            //|| Number == 44 || Number == 46 || Number == 48 || Number == 53 || Number == 54 || Number == 56 || Number == 57 || Number == 58 || Number == 59 || Number == 60);
            List<string> returned = new List<string>();
            returned.Add(profesje[1]);
            returned.Add(profesje[6]);
            returned.Add(profesje[10]);
            returned.Add(profesje[11]);
            returned.Add(profesje[12]);
            returned.Add(profesje[14]);
            returned.Add(profesje[18]);
            returned.Add(profesje[20]);
            returned.Add(profesje[21]);
            returned.Add(profesje[22]);
            returned.Add(profesje[23]);
            returned.Add(profesje[24]);
            returned.Add(profesje[27]);
            returned.Add(profesje[35]);
            returned.Add(profesje[36]);
            returned.Add(profesje[37]);
            returned.Add(profesje[38]);
            returned.Add(profesje[39]);
            returned.Add(profesje[42]);
            returned.Add(profesje[43]);
            returned.Add(profesje[45]);
            returned.Add(profesje[47]); returned.Add(profesje[52]); returned.Add(profesje[53]); returned.Add(profesje[56]); returned.Add(profesje[57]); returned.Add(profesje[58]); returned.Add(profesje[59]);

            return returned;
        }

        public List<string> createElfProfesionList()
        {
            //(Number == 2 || Number == 6 || Number == 16 || Number == 19 || Number == 23 || Number == 27 || Number == 30
            //|| Number == 32 || Number == 35 || Number == 36 || Number == 38 || Number == 49 || Number == 51 || Number == 52 || Number == 56
            //|| Number == 56 || Number == 58);
            List<string> returned = new List<string>();
            returned.Add(profesje[1]);
            returned.Add(profesje[5]);
            returned.Add(profesje[15]);
            returned.Add(profesje[19]);
            returned.Add(profesje[22]);
            returned.Add(profesje[26]);
            returned.Add(profesje[29]);
            returned.Add(profesje[31]);
            returned.Add(profesje[34]);
            returned.Add(profesje[35]);
            returned.Add(profesje[37]);
            returned.Add(profesje[48]);
            returned.Add(profesje[50]);
            returned.Add(profesje[51]);
            returned.Add(profesje[55]);
            returned.Add(profesje[56]);
            returned.Add(profesje[57]);
            return returned;
        }

        public List<string> CreateHumanProfesionList()
        {
            List<string> returned = profesje.ToList();
            returned.RemoveAt(11);
            returned.RemoveAt(34);
            returned.RemoveAt(41);
            returned.RemoveAt(47);
            returned.RemoveAt(51);
            returned.RemoveAt(53);
            return returned;
        }

        public warhammer CreateHuman(string name, bool _sex, string eyes, string hair)
        {
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);

            Profesja = RandomProfesionHuman();
            Race = "człowiek";
            Waga = RandomWeight(Race);
            walka_wrecz = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            strzelectwo = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            krzepa = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            odpowrnosc = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            zrecznosc = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            inteligencjal = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            sila_woli = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            Oglada = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            ataki = 1;
            var items = new List<KeyValuePair<string, int>>();
            sila = (int)(krzepa.ToString()[0]) - 48;
            wytrzymalosc = (int)(odpowrnosc.ToString()[0]) - 48;
            szybkosc = 4;
            magia = 0;
            obled = 0;
            if (_sex == false)//kobieta
            {
                wysokosc = 150 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "female";
            }
            else // mezczyzna
            {
                wysokosc = 160 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "Male";
            }

            //// zywotnosc
            zywotnosc = PoczatkowaZywotnosc(Race);
            /// przeznaczenie
            if (Enumerable.Range(1, 4).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 2;
            }
            else if (Enumerable.Range(5, 10).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 3;
            }
            ///
            umiejetnosci.Add("plotkowanie"); umiejetnosci.Add("wiedza(imperium)"); umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
            zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
            zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
            Profesja = profesje[randomNumber.Next(0, profesje.Length)];
            warhammer postac = new warhammer(name, Race, plec_string, walka_wrecz, strzelectwo, krzepa, odpowrnosc, zrecznosc, inteligencjal, sila_woli, Oglada, ataki, zywotnosc, sila, wytrzymalosc, szybkosc,
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci, items);
            return postac;
        }
        public warhammer CreateElf(string name, bool _sex, string eyes, string hair)
        {
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);
            var items = new List<KeyValuePair<string, int>>();
            Profesja = RandomProfesionElf();

            Race = "elf";
            Waga = RandomWeight(Race);
            walka_wrecz = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            strzelectwo = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            krzepa = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            odpowrnosc = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            zrecznosc = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            inteligencjal = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            sila_woli = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            Oglada = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            ataki = 1;
            sila = (int)(krzepa.ToString()[0]) - 48;
            wytrzymalosc = (int)(odpowrnosc.ToString()[0]) - 48;
            szybkosc = 5;
            magia = 0;
            obled = 0;
            if (_sex == false)//kobieta
            {
                wysokosc = 160 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "male";
            }
            else // mezczyzna
            {
                wysokosc = 170 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "male";
            }
            //// zywotnosc
            zywotnosc = PoczatkowaZywotnosc(Race);
            ///
            if (Enumerable.Range(1, 4).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 1;
            }
            else if (Enumerable.Range(5, 10).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 2;
            }
            ///
            umiejetnosci.Add("wiedza(elfy)"); umiejetnosci.Add("znajomosc jezyka(eltharin"); umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
            zdolnosci.Add("bystry wzrok"); zdolnosci.Add("widzenie w ciemnosci");
            warhammer postac = new warhammer(name, Race, plec_string, walka_wrecz, strzelectwo, krzepa, odpowrnosc, zrecznosc, inteligencjal, sila_woli, Oglada, ataki, zywotnosc, sila, wytrzymalosc, szybkosc,
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci,items);
            return postac;
        }

        public warhammer CreateDwarf(string name, bool _sex, string eyes, string hair)
        {
            Race = "krasnolud";
            Waga = RandomWeight(Race);
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);
            var items = new List<KeyValuePair<string, int>>();
            Profesja = RandomProfesionDwarf();

            walka_wrecz = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            strzelectwo = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            krzepa = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            odpowrnosc = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            zrecznosc = 10 + randomNumber.Next(10) + randomNumber.Next(10);
            inteligencjal = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            sila_woli = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            Oglada = 10 + randomNumber.Next(10) + randomNumber.Next(10);
            ataki = 1;
            sila = (int)(krzepa.ToString()[0]) - 48;
            wytrzymalosc = (int)(odpowrnosc.ToString()[0]) - 48;
            szybkosc = 3;
            magia = 0;
            obled = 0;
            if (_sex == false)//kobieta
            {
                wysokosc = 130 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "female";
            }
            else // mezczyzna
            {
                wysokosc = 145 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "male";
            }
            //// zywotnosc
            zywotnosc = PoczatkowaZywotnosc(Race);
            ///
            if (Enumerable.Range(1, 4).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 1;
            }
            else if (Enumerable.Range(5, 7).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 2;
            }
            else if (Enumerable.Range(8, 10).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 3;
            }
            ///
            umiejetnosci.Add("wiedza(krasnoludy)"); umiejetnosci.Add("znajomosc jezyka(khazalid)"); umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
            zdolnosci.Add("krasnoludzki fach"); zdolnosci.Add("krzepki"); zdolnosci.Add("odpornosc na magie"); zdolnosci.Add("odwaga"); zdolnosci.Add("widzenie w ciemnosci"); zdolnosci.Add("zapiekła nienawiść");
            warhammer postac = new warhammer(name, Race, plec_string, walka_wrecz, strzelectwo, krzepa, odpowrnosc, zrecznosc, inteligencjal, sila_woli, Oglada, ataki, zywotnosc, sila, wytrzymalosc, szybkosc,
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci,items);
            return postac;
        }

        public warhammer CreateHalfling(string name, bool _sex, string eyes, string hair)
        {
            Race = "niziołek";
            Waga = RandomWeight(Race);
            Random randomNumber = new Random();
            int roll_przeznaczenie = randomNumber.Next(1, 10);
            var items = new List<KeyValuePair<string, int>>();
            Profesja = RandomProfesionHalfLing();

            walka_wrecz = 10 + randomNumber.Next(10) + randomNumber.Next(10);
            strzelectwo = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            krzepa = 10 + randomNumber.Next(10) + randomNumber.Next(10);
            odpowrnosc = 10 + randomNumber.Next(10) + randomNumber.Next(10);
            zrecznosc = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            inteligencjal = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            sila_woli = 20 + randomNumber.Next(10) + randomNumber.Next(10);
            Oglada = 30 + randomNumber.Next(10) + randomNumber.Next(10);
            ataki = 1;
            sila = (int)(krzepa.ToString()[0]) - 48;
            wytrzymalosc = (int)(odpowrnosc.ToString()[0]) - 48;
            szybkosc = 4;
            magia = 0;
            obled = 0;
            if (_sex == false)//kobieta
            {
                wysokosc = 100 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "female";
            }
            else // mezczyzna
            {
                wysokosc = 110 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
                plec_string = "male";
            }
            //// zywotnosc
            zywotnosc = PoczatkowaZywotnosc(Race);
            ///
            if (Enumerable.Range(1, 7).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 2;
            }
            else if (Enumerable.Range(8, 10).Contains(roll_przeznaczenie))
            {
                przeznaczenie = 3;
            }


            umiejetnosci.Add("nauka(genealogia/heraldyka"); umiejetnosci.Add("wiedza(niziołki"); umiejetnosci.Add("znajomosc jezyka(niziolki"); umiejetnosci.Add("znajomosc jezyka staroswiatowy)");
            zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
            warhammer postac = new warhammer(name, Race, plec_string, walka_wrecz, strzelectwo, krzepa, odpowrnosc, zrecznosc, inteligencjal, sila_woli, Oglada, ataki, zywotnosc, sila, wytrzymalosc, szybkosc,
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci,items);
            return postac;
        }

        public string RandomProfesionHuman()
        {
            Random randomNumber = new Random();
            int Number = randomNumber.Next(0, ProfesjeHuman.Count);
            return profesje[Number];
        }
        public string RandomProfesionElf()
        {
            Random randomNumber = new Random();
            int Number = randomNumber.Next(0, ProfesjeElf.Count);
            return profesje[Number];
        }
        public string RandomProfesionDwarf()
        {
            Random randomNumber = new Random();
            int Number = randomNumber.Next(0, ProfesjeDwarf.Count);
            return profesje[Number];
        }
        public string RandomProfesionHalfLing()
        {
            Random randomNumber = new Random();
            int Number = randomNumber.Next(0, ProfesjeHalfling.Count);
            return profesje[Number];
        }
        public int RandomWeight(string rasa)
        {
            Random r = new Random();
            int var = r.Next(1, 100);
            if (var == 1)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 50;
                    case "elf":
                        return 40;
                    case "krasnolud":
                        return 45;
                    case "niziołek":
                        return 35;
                }

            }
            else if (var >= 2 && var <= 10)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 50;
                    case "elf":
                        return 40;
                    case "krasnolud":
                        return 45;
                    case "niziołek":
                        return 35;
                }
            }
            else if (var >= 11 && var <= 20)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 55;
                    case "elf":
                        return 45;
                    case "krasnolud":
                        return 50;
                    case "niziołek":
                        return 35;
                }
            }
            else if (var >= 21 && var <= 30)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 60;
                    case "elf":
                        return 50;
                    case "krasnolud":
                        return 55;
                    case "niziołek":
                        return 40;
                }
            }
            else if (var >= 31 && var <= 40)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 65;
                    case "elf":
                        return 55;
                    case "krasnolud":
                        return 60;
                    case "niziołek":
                        return 40;
                }
            }
            else if (var >= 41 && var <= 50)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 70;
                    case "elf":
                        return 60;
                    case "krasnolud":
                        return 65;
                    case "niziołek":
                        return 45;
                }
            }
            else if (var >= 51 && var <= 60)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 75;
                    case "elf":
                        return 65;
                    case "krasnolud":
                        return 70;
                    case "niziołek":
                        return 45;
                }

            }
            else if (var >= 61 && var <= 70)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 80;
                    case "elf":
                        return 70;
                    case "krasnolud":
                        return 75;
                    case "niziołek":
                        return 50;
                }
            }
            else if (var >= 71 && var <= 80)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 85;
                    case "elf":
                        return 75;
                    case "krasnolud":
                        return 80;
                    case "niziołek":
                        return 50;
                }
            }
            else if (var >= 81 && var <= 90)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 95;
                    case "elf":
                        return 85;
                    case "krasnolud":
                        return 90;
                    case "niziołek":
                        return 60;
                }
            }
            else if (var >= 91 && var <= 99)
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 100;
                    case "elf":
                        return 90;
                    case "krasnolud":
                        return 95;
                    case "niziołek":
                        return 65;
                }
            }
            else
            {
                switch (rasa.Trim().ToLower())
                {
                    case "człowiek":
                        return 110;
                    case "elf":
                        return 95;
                    case "krasnolud":
                        return 100;
                    case "niziołek":
                        return 70;
                }
            }
            return 999;
        }

        public int PoczatkowaZywotnosc(string rasa)
        {
            Random r = new Random();
            int roll_zytowtnosc = r.Next(1, 10);
            int zywotnosc = 999;
            switch (rasa.ToLower())
            {
                case "człowiek":
                    if (Enumerable.Range(1, 3).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 10;
                    }
                    else if (Enumerable.Range(4, 6).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 11;
                    }
                    else if (Enumerable.Range(7, 9).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 12;
                    }
                    else if (roll_zytowtnosc == 10)
                    {
                        zywotnosc = 13;
                    }
                    break;
                case "elf":
                    if (Enumerable.Range(1, 3).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 9;
                    }
                    else if (Enumerable.Range(4, 6).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 10;
                    }
                    else if (Enumerable.Range(7, 9).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 11;
                    }
                    else if (roll_zytowtnosc == 10)
                    {
                        zywotnosc = 12;
                    }
                    break;
                case "krasnolud":
                    if (Enumerable.Range(1, 3).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 11;
                    }
                    else if (Enumerable.Range(4, 6).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 12;
                    }
                    else if (Enumerable.Range(7, 9).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 13;
                    }
                    else if (roll_zytowtnosc == 10)
                    {
                        zywotnosc = 14;
                    }
                    break;
                case "niziołek":
                    if (Enumerable.Range(1, 3).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 8;
                    }
                    else if (Enumerable.Range(4, 6).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 9;
                    }
                    else if (Enumerable.Range(7, 9).Contains(roll_zytowtnosc))
                    {
                        zywotnosc = 10;
                    }
                    else if (roll_zytowtnosc == 10)
                    {
                        zywotnosc = 11;
                    }
                    break;
            }
            return zywotnosc;
        }
        public int PoczatkowaWysokosc(string rasa, bool plec)
        {
            Random r = new Random();
            int bazo = 999;
            int rzut = r.Next(1, 10) + r.Next(1, 10);
            if (plec == false)
            {
                switch (rasa.ToLower())
                {
                    case "człowiek":
                        bazo = 150;
                        break;
                    case "elf":
                        bazo = 160;
                        break;
                    case "krasnolud":
                        bazo = 130;
                        break;
                    case "niziołek":
                        bazo = 100;
                        break;
                }
            }
            else
            {
                switch (rasa.ToLower())
                {
                    case "człowiek":
                        bazo = 160;
                        break;
                    case "elf":
                        bazo = 170;
                        break;
                    case "krasnolud":
                        bazo = 145;
                        break;
                    case "niziołek":
                        bazo = 110;
                        break;
                }
            }
            return bazo + rzut;
        }
        public int PoczatkowePrzeznaczenie(string rasa)
        {
            Random r = new Random();
            int roll_przeznaczenie = r.Next(1, 10);
            int result = 999;
            if (Enumerable.Range(1, 4).Contains(roll_przeznaczenie))
            {
                switch (rasa.ToLower())
                {
                    case "człowiek":
                        result = 2;
                        break;
                    case "elf":
                        result = 1;
                        break;
                    case "krasnolud":
                        result = 1;
                        break;
                    case "niziołek":
                        result = 2;
                        break;
                }
            }
            else if (Enumerable.Range(5, 7).Contains(roll_przeznaczenie))
            {
                switch (rasa.ToLower())
                {
                    case "człowiek":
                        result = 3;
                        break;
                    case "elf":
                        result = 2;
                        break;
                    case "krasnolud":
                        result = 2;
                        break;
                    case "niziołek":
                        result = 2;
                        break;
                }
            }
            else if (Enumerable.Range(8, 10).Contains(roll_przeznaczenie))
            {
                switch (rasa.ToLower())
                {
                    case "człowiek":
                        result = 3;
                        break;
                    case "elf":
                        result = 2;
                        break;
                    case "krasnolud":
                        result = 3;
                        break;
                    case "niziołek":
                        result = 3;
                        break;
                }
            }
            return result;
        }
        public int PoczatkowaSzybkosz(string rasa)
        {
            switch (rasa.ToLower())
            {
                case "człowiek":
                    return 4;
                case "elf":
                    return 5;
                case "krasnolud":
                    return 3;
                case "niziołek":
                    return 4;
                default:
                    return 666;
            }

        }
        public void AddDefaultValues(warhammer chara)
        {
            switch (chara.Rasa.ToLower())
            {
                case "człowiek":
                    chara.walka_wrecz += 20;
                    chara.strzelectwo += 20;
                    chara.krzepa += 20;
                    chara.odpowrnosc += 20;
                    chara.zrecznosc += 20;
                    chara.inteligencjal += 20;
                    chara.sila_woli += 20;
                    chara.Oglada += 20;
                    break;
                case "elf":
                    chara.walka_wrecz += 20;
                    chara.strzelectwo += 30;
                    chara.krzepa += 20;
                    chara.odpowrnosc += 20;
                    chara.zrecznosc += 30;
                    chara.inteligencjal += 20;
                    chara.sila_woli += 20;
                    chara.Oglada += 20;
                    break;
                case "krasnolud":
                    chara.walka_wrecz += 30;
                    chara.strzelectwo += 20;
                    chara.krzepa += 20;
                    chara.odpowrnosc += 30;
                    chara.zrecznosc += 10;
                    chara.inteligencjal += 20;
                    chara.sila_woli += 20;
                    chara.Oglada += 10;
                    break;
                case "niziołek":
                    chara.walka_wrecz += 10;
                    chara.strzelectwo += 30;
                    chara.krzepa += 10;
                    chara.odpowrnosc += 10;
                    chara.zrecznosc += 30;
                    chara.inteligencjal += 20;
                    chara.sila_woli += 20;
                    chara.Oglada += 30;
                    break;

            }
        }
        public DiscordEmbedBuilder CharPlate(warhammer PlayerCharacter)
        {
            var siusiak = new DiscordEmbedBuilder
            {
                Title = "Sample Text: ",
                Description = "`Imie:` " + PlayerCharacter.CharName + System.Environment.NewLine +
                             "`Rasa:` " + PlayerCharacter.Rasa + System.Environment.NewLine +
                             "`Płeć:` " + PlayerCharacter.plec_string + System.Environment.NewLine +
                             "`Kolor Włosów:` " + PlayerCharacter.hair_color + System.Environment.NewLine +
                             "`Kolor Oczu:` " + PlayerCharacter.eye_color + System.Environment.NewLine +
                             "`walka w ręcz:` " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                             "`Strzelectwo:` " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                             "`Krzepa:` " + PlayerCharacter.krzepa + System.Environment.NewLine +
                             "`odporność:` " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                             "`Zreczność:` " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                             "`Inteligencja:` " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                             "`Sila woli:` " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                             "`Ogłada:` " + PlayerCharacter.Oglada + System.Environment.NewLine +
                             "`Ataki:` " + PlayerCharacter.ataki + System.Environment.NewLine +
                             "`żywotność:` " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                             "`Siła:` " + PlayerCharacter.sila + System.Environment.NewLine +
                             "`Wytrzymałość:` " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                             "`Szybkość:` " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                             "`Magia:` " + PlayerCharacter.magia + System.Environment.NewLine +
                             "`Obłęd:` " + PlayerCharacter.obled + System.Environment.NewLine +
                             "`Przeznaczenie:` " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                             "`Profesja:` " + PlayerCharacter.proffesion + System.Environment.NewLine +
                             "`Wiek:` " + PlayerCharacter.age + System.Environment.NewLine +
                             "`Wysokość:` " + PlayerCharacter.heigth + System.Environment.NewLine +
                             "`Waga:` " + PlayerCharacter.weight,
                Color = DiscordColor.IndianRed
            };
            return siusiak;
        }
        public void AddStartUmiejetnosci(warhammer chara)
        {
            Random randomNumber = new Random();
            switch (chara.Rasa.ToLower())
            {
                case "człowiek":

                    chara.umiejetnosci.Add("plotkowanie"); chara.umiejetnosci.Add("wiedza(imperium)"); chara.umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
                    chara.zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
                    chara.zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
                    break;
                case "elf":

                    chara.umiejetnosci.Add("wiedza(elfy)"); chara.umiejetnosci.Add("znajomosc jezyka(eltharin"); chara.umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
                    chara.zdolnosci.Add("bystry wzrok"); chara.zdolnosci.Add("widzenie w ciemnosci");
                    break;
                case "krasnolud":
                    chara.umiejetnosci.Add("wiedza(krasnoludy)"); chara.umiejetnosci.Add("znajomosc jezyka(khazalid)"); chara.umiejetnosci.Add("znajomosc jezyka(staroswiatowy)");
                    chara.zdolnosci.Add("krasnoludzki fach"); chara.zdolnosci.Add("krzepki");chara.zdolnosci.Add("odpornosc na magie"); chara.zdolnosci.Add("odwaga"); chara.zdolnosci.Add("widzenie w ciemnosci"); chara.zdolnosci.Add("zapiekła nienawiść");
                    break;
                case "niziołek":
                    chara.umiejetnosci.Add("nauka(genealogia/heraldyka"); chara.umiejetnosci.Add("wiedza(niziołki"); chara.umiejetnosci.Add("znajomosc jezyka(niziolki"); chara.umiejetnosci.Add("znajomosc jezyka staroswiatowy)");
                    chara.zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
                    break;

            }
        }
    }
}
