using DiscordApp.Handlers;
using DiscordApp.Handlers.Dialogue;
using DiscordApp.Handlers.Dialogue.Steps;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.WarhammerFantasy
{
    public class WHF_Infotables
    {
        public Random r = new Random();
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
        public bool plec = new bool(); // false - kobieta, true - mezczyzna
        public string plec_string;
        public List<string> umiejetnosci = new List<string>();
        public List<string> zdolnosci = new List<string>();
        public List<string> choroby = new List<string>();
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci, items, new List<string>(), _sex, new List<string>());
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
                plec_string = "female";
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci, items, new List<string>(), _sex, new List<string>());
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci, items, new List<string>(), _sex, new List<string>());
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, Waga, eyes, hair, umiejetnosci, zdolnosci, items, new List<string>(), _sex, new List<string>());
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
                    chara.zdolnosci.Add("krasnoludzki fach"); chara.zdolnosci.Add("krzepki"); chara.zdolnosci.Add("odpornosc na magie"); chara.zdolnosci.Add("odwaga"); chara.zdolnosci.Add("widzenie w ciemnosci"); chara.zdolnosci.Add("zapiekła nienawiść");
                    break;
                case "niziołek":
                    chara.umiejetnosci.Add("nauka(genealogia/heraldyka"); chara.umiejetnosci.Add("wiedza(niziołki"); chara.umiejetnosci.Add("znajomosc jezyka(niziolki"); chara.umiejetnosci.Add("znajomosc jezyka staroswiatowy)");
                    chara.zdolnosci.Add(losowa_umiejetnosc[randomNumber.Next(1, losowa_umiejetnosc.Length)]);
                    break;

            }
        }
        public async Task dmg(CommandContext ctx, DiscordMember user, int amount)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string line = string.Empty;
                string JsonFromFile = string.Empty;
                warhammer character = new warhammer();
                bool znaleziono = false;
                if (ctx.Channel.Topic != "warhammer") //jezeli nie jestes na kanale to susuwa wiadomosc
                {
                    var cosiek = await ctx.Channel.SendMessageAsync("jesteś poza kanałem do grania w rpg" + ctx.Member.Mention);
                    Thread.Sleep(30000);
                    await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    await ctx.Channel.DeleteMessageAsync(cosiek);
                }
                else
                {
                    var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                    List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                    List<DiscordEmbed> embed = new List<DiscordEmbed>();
                    foreach (var item in playerChars) //zapisuje embedy do listy
                    {
                        embed = item.Embeds.ToList();
                        embeds.Add(embed[0]);
                        embed.Clear();
                    }
                    foreach (var item in embeds) //przechodzi prze liste embedów
                    {

                        if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                        {
                            znaleziono = true;
                            using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                            {
                                line = await reader.ReadLineAsync();
                            }
                            line = line.Remove(0, 8);
                            using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                            {
                                JsonFromFile = await reader.ReadToEndAsync();
                            }
                            character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                        }
                    }

                    if (znaleziono == true)
                    {
                        if (character.zywotnosc - amount <= 0)
                        {
                            await ctx.Channel.SendMessageAsync("This character has died");
                            File.Delete(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json");
                            await ctx.Channel.SendMessageAsync("Remember to unpin the charactersheet!!");
                        }
                        else
                        {
                            character.zywotnosc -= amount;
                            await ctx.Channel.SendMessageAsync("dealed " + line + " " + amount + " damage");
                            JsonFromFile = JsonConvert.SerializeObject(character);
                            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                        }
                    }
                }
            }
        }
        public async Task heal(CommandContext ctx, DiscordMember user, int amount)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string line = string.Empty;
                string JsonFromFile = string.Empty;
                warhammer character = new warhammer();
                bool znaleziono = false;
                if (ctx.Channel.Topic != "warhammer") //jezeli nie jestes na kanale to susuwa wiadomosc
                {
                    var cosiek = await ctx.Channel.SendMessageAsync("You are outside of rpg territory" + ctx.Member.Mention);
                    Thread.Sleep(30000);
                    await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    await ctx.Channel.DeleteMessageAsync(cosiek);
                }
                else
                {
                    var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                    List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                    List<DiscordEmbed> embed = new List<DiscordEmbed>();
                    foreach (var item in playerChars) //zapisuje embedy do listy
                    {
                        embed = item.Embeds.ToList();
                        embeds.Add(embed[0]);
                        embed.Clear();
                    }
                    foreach (var item in embeds) //przechodzi prze liste embedów
                    {

                        if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                        {
                            znaleziono = true;
                            using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                            {
                                line = await reader.ReadLineAsync();
                            }
                            line = line.Remove(0, 8);
                            using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                            {
                                JsonFromFile = await reader.ReadToEndAsync();
                            }
                            character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync("Couldn't find that player in this session");
                        }
                    }

                    if (znaleziono == true)
                    {
                        character.zywotnosc += amount;
                        await ctx.Channel.SendMessageAsync("healed " + line + " " + amount + " damage");
                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                    }
                }
            }
        }
        public async Task ShowChar(CommandContext ctx, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string name = string.Join(" ", input);
                if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    string JsonFromFile;
                    using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                    {
                        JsonFromFile = reader.ReadToEnd();
                    }
                    switch (ctx.Prefix)
                    {
                        case "wh":
                            var template = new WHF_Infotables();
                            warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                            var plate = template.CharPlate(character);
                            plate.Title = "Moja postać";
                            await ctx.Channel.SendMessageAsync(embed: plate);
                            break;
                        case ">>":
                            await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                            break;
                    }

                }
                else
                {
                    await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
                }
            }
        }
        public async Task Join(CommandContext ctx, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string name = string.Join(" ", input);
                if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    string JsonFromFile;
                    using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                    {
                        JsonFromFile = reader.ReadToEnd();
                    }
                    var template = new WHF_Infotables();
                    warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                    var plate = template.CharPlate(character);
                    plate.Title = ctx.Member.DisplayName;
                    var variable = await ctx.Channel.SendMessageAsync(embed: plate);
                    await variable.PinAsync();
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
                }
            }
        }
        public async Task Charlist(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                string Description = string.Empty;
                if (Directory.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic))
                {
                    DirectoryInfo di = new DirectoryInfo(ctx.Member.Id + "/" + ctx.Channel.Topic);
                    FileInfo[] files = di.GetFiles();
                    foreach (var item in files)
                    {
                        Description += Path.GetFileNameWithoutExtension(item.FullName) + " // ";
                    }
                    Description.Trim('/');
                    Description.Trim('/');
                    var chars = new DiscordEmbedBuilder
                    {
                        Title = "Twoje postacie do `" + ctx.Channel.Topic + "` " + ctx.Member.DisplayName,
                        Description = Description
                    };
                    await ctx.Channel.SendMessageAsync(embed: chars);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("Nie masz żadnych postaci do tego systemu");
                }
            }
        }
        public async Task addItem(CommandContext ctx, DiscordMember user, int amount, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        string itemname = string.Join(" ", input);
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        var noweprzedmioty = character.przedmioty;
                        KeyValuePair<string, int> itemek = new KeyValuePair<string, int>("chuj", 0);
                        for (int i = 0; i < noweprzedmioty.Count; i++)
                        {
                            if (noweprzedmioty[i].Key == itemname)//znaleziono przedmiiot
                            {
                                itemek = new KeyValuePair<string, int>(noweprzedmioty[i].Key, noweprzedmioty[i].Value + 1);
                                noweprzedmioty.RemoveAt(i);
                            }
                        }
                        if (itemek.Key == "chuj")
                        {
                            character.przedmioty.Add(new KeyValuePair<string, int>(itemname, amount));
                        }
                        else
                        {
                            character.przedmioty.Add(itemek);
                        }

                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                        await ctx.Channel.SendMessageAsync("Added: `" + amount + " " + itemname + "` To eq of: `" + line + "`");
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("Coudln't find the playr in this session");
                    }
                }
            }
        }
        public async Task RemoveItem(CommandContext ctx, DiscordMember user, int amount, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        string itemname = string.Join(" ", input);
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        var noweprzedmioty = character.przedmioty;
                        KeyValuePair<string, int> itemek = new KeyValuePair<string, int>("chuj", 0);
                        for (int i = 0; i < noweprzedmioty.Count; i++)
                        {
                            if (noweprzedmioty[i].Key == itemname)//znaleziono przedmiiot
                            {
                                itemek = new KeyValuePair<string, int>(noweprzedmioty[i].Key, noweprzedmioty[i].Value - 1);
                                noweprzedmioty.RemoveAt(i);
                            }
                        }
                        if (itemek.Value > 0)
                        {
                            noweprzedmioty.Add(itemek);
                        }
                        character.przedmioty = noweprzedmioty;
                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                        await ctx.Channel.SendMessageAsync("Removed: `" + amount + " " + itemname + "` From inventory of: `" + line + "`");
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("Coudn't find player in session");
                    }
                }
            }
        }
        public async Task addability(CommandContext ctx, DiscordMember user, params string[] input)
        {
            var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
            List<DiscordEmbed> embeds = new List<DiscordEmbed>();
            List<DiscordEmbed> embed = new List<DiscordEmbed>();
            foreach (var item in playerChars) //zapisuje embedy do listy
            {
                embed = item.Embeds.ToList();
                embeds.Add(embed[0]);
                embed.Clear();
            }
            foreach (var item in embeds) //przechodzi prze liste embedów
            {
                if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                {
                    string line = string.Empty;
                    using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                    {
                        line = await reader.ReadLineAsync();
                    }
                    line = line.Remove(0, 8);
                    string JsonFromFile = string.Empty;
                    using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                    {
                        JsonFromFile = await reader.ReadToEndAsync();
                    }
                    string itemname = string.Join(" ", input);
                    warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                    character.umiejetnosci.Add(itemname);
                    JsonFromFile = JsonConvert.SerializeObject(character);
                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                    await ctx.Channel.SendMessageAsync("dodałem: `" + line + "` umiejetnosc: `" + itemname + "`");
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                }
            }
        }
        public async Task removeability(CommandContext ctx, DiscordMember user, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        string itemname = string.Join(" ", input);
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        character.umiejetnosci.Remove(itemname);
                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                        await ctx.Channel.SendMessageAsync("usunałem: `" + line + "` umiejetnosc: `" + itemname + "`");
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }

            }
        }
        public async Task showFluff(CommandContext ctx, DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        await ctx.Channel.SendMessageAsync(line);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Historia: " + character.CharName,
                            Description = character.fluff
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);
                        break;
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }

            }
        }
        public async Task insanity(CommandContext ctx, DiscordMember user, int amount)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var yes = DiscordEmoji.FromName(ctx.Client, ":+1:");
                var no = DiscordEmoji.FromName(ctx.Client, ":-1:");

                string line = string.Empty;
                string JsonFromFile = string.Empty;
                warhammer character = new warhammer();
                bool znaleziono = false;

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {

                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        znaleziono = true;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        if (znaleziono == true)
                        {
                            if (character.obled + amount >= 6)
                            {
                                await ctx.Channel.SendMessageAsync("Twoja postać dostała choroby psychicznej, wpisz jej nazwe");
                                var choroba = await ctx.Channel.GetNextMessageAsync();
                                if (character.choroby.Count == 0) //kys
                                {
                                    var kysembed = new DiscordEmbedBuilder
                                    {
                                        Title = line + " chce się zabic",
                                        Description = "pozwolić?",
                                        Color = DiscordColor.Red
                                    };
                                    var kysMsg = await ctx.Channel.SendMessageAsync(embed: kysembed);
                                    await kysMsg.CreateReactionAsync(yes);
                                    await kysMsg.CreateReactionAsync(no);
                                    var interactivity = ctx.Client.GetInteractivity();
                                    Thread.Sleep(300);
                                    var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == kysMsg
                                    &&
                                    (x.Emoji == yes || x.Emoji == no)).ConfigureAwait(false);
                                    if (sexResult.Result.Emoji == yes)
                                    {
                                        Random r = new Random();
                                        if (r.Next(1, 10) <= 2)
                                        {
                                            await ctx.Channel.SendMessageAsync("Twoja postać jest bohatyrem");
                                            File.Delete(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json");
                                            return;
                                        }
                                        else
                                        {
                                            await ctx.Channel.SendMessageAsync("twoja postać żyje");
                                        }
                                    }
                                    else if (sexResult.Result.Emoji == no)
                                    {
                                        await ctx.Channel.SendMessageAsync("twoja postać żyje");
                                    }
                                }
                                character.choroby.Add(choroba.Result.Content);
                                character.obled = 0;
                                await ctx.Channel.SendMessageAsync("Your character has: " +
                                    choroba.Result.Content);
                            }
                            else
                            {
                                character.obled += amount;
                                await ctx.Channel.SendMessageAsync("Dealed " +
                                    user.DisplayName + " " + amount + " insanity damage");
                            }
                            JsonFromFile = JsonConvert.SerializeObject(character);
                            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                            // await ListaChorob(ctx, user);
                        }
                        else
                        {
                            await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                        }
                    }
                }
            }
        }
        public async Task Choroby(CommandContext ctx, DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        string[] choroby = character.choroby.ToArray();
                        string wiadomosc = string.Join(Environment.NewLine, choroby);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Choroby: " + character.CharName,
                            Description = wiadomosc
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);

                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }

            }
        }
        public async Task ShowInventory(CommandContext ctx, DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        var choroby = character.przedmioty.ToList();
                        string wiadomosc = string.Join(Environment.NewLine, choroby);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Items of: " + character.CharName,
                            Description = wiadomosc
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("Couldn't find the player in this session");
                    }
                }

            }
        }
        public async Task ShowAbilities(CommandContext ctx, DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        var choroby = character.umiejetnosci.ToList();
                        string wiadomosc = string.Join(Environment.NewLine, choroby);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Abilities of: " + character.CharName,
                            Description = wiadomosc
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }
            }
        }
        public async Task SlowCharacter(CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
            Random randomNumber = new Random();
            WHF_Infotables template = new WHF_Infotables();
            warhammer PlayerCharacter = new warhammer();
            var inputStep = new StringStep("bottom text", "Witaj w kreatorze postaci do Warhammera" + System.Environment.NewLine + "Jak sie nazywasz?", null);

            string input = string.Empty;
            string plec_string = string.Empty;
            List<string> umiejetnosci = new List<string>();
            List<string> zdolnosci = new List<string>();
            List<int> PulaLiczb = new List<int>();
            string Charactername = string.Empty;

            inputStep.OnValidResult += (result) => input = result;
            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                userChannel,
                ctx.User,
                inputStep
                );
            await inputDialogueHandler.ProcessDialogue();
            Charactername = input;  //added char name
            PlayerCharacter.CharName = Charactername;
            var SexEmbed = new DiscordEmbedBuilder
            {
                Title = "What `gender` are you?",
                Description = emojis.kobieta + " - For Female" + System.Environment.NewLine + emojis.mezczyzna + "- For Male",
                Color = DiscordColor.Gold
            };
            var sexMsg = await userChannel.SendMessageAsync(embed: SexEmbed);
            await sexMsg.CreateReactionAsync(emojis.kobieta);
            await sexMsg.CreateReactionAsync(emojis.mezczyzna);
            var interactivity = ctx.Client.GetInteractivity();
            Thread.Sleep(300);
            var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == sexMsg
            &&
            (x.Emoji == emojis.kobieta || x.Emoji == emojis.mezczyzna)).ConfigureAwait(false);
            if (sexResult.Result.Emoji == emojis.kobieta)
            {
                PlayerCharacter.plec = false;
                PlayerCharacter.plec_string = plec_string = "Female";

            }
            else if (sexResult.Result.Emoji == emojis.mezczyzna)
            {
                PlayerCharacter.plec = true;
                PlayerCharacter.plec_string = plec_string = "Male";
            }

            var RaseEmbed = new DiscordEmbedBuilder
            {
                Title = "What `Race` are you?",
                Description = emojis.human + " -for human race" + System.Environment.NewLine + emojis.elf + " -for elf race" + System.Environment.NewLine + emojis.krasnoludy + " -for dwarfs" + System.Environment.NewLine + emojis.niziolki + "- for halfling",
                Color = DiscordColor.Red

            };
            var raceMsg = await userChannel.SendMessageAsync(embed: RaseEmbed);
            await raceMsg.CreateReactionAsync(emojis.human);
            await raceMsg.CreateReactionAsync(emojis.elf);
            await raceMsg.CreateReactionAsync(emojis.krasnoludy);
            await raceMsg.CreateReactionAsync(emojis.niziolki);
            Thread.Sleep(300);
            var raceResult = await interactivity.WaitForReactionAsync(x => x.Message == raceMsg
            &&
            (x.Emoji == emojis.human || x.Emoji == emojis.elf || x.Emoji == emojis.krasnoludy || x.Emoji == emojis.niziolki)).ConfigureAwait(false);
            Thread.Sleep(300);
            ////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////////////
            inputStep = new StringStep("bottom text", "What is your `Eye Color`?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            string kolor_oczu = input;
            PlayerCharacter.eye_color = input;

            inputStep = new StringStep("bottom text", "What is your `Hair Colour`", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );

            await inputDialogueHandler.ProcessDialogue();
            string kolor_wlosow = input;
            PlayerCharacter.hair_color = input;
            inputStep = new StringStep(",", "Whant to write something about yourself", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            PlayerCharacter.fluff = input;

            inputStep = new StringStep(",", "How `Old` are you?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            PlayerCharacter.age = Int32.Parse(input);
            ////////////////////////////////////////////////////////////////////
            string profesje = string.Empty;
            if (raceResult.Result.Emoji == emojis.human)
            {
                PlayerCharacter.Rasa = "Człowiek";
                profesje = string.Join("` : `", template.ProfesjeHuman);
            }
            else if (raceResult.Result.Emoji == emojis.elf)
            {
                PlayerCharacter.Rasa = "Elf";
                profesje = string.Join("` : `", template.ProfesjeElf);
            }
            else if (raceResult.Result.Emoji == emojis.krasnoludy)
            {
                PlayerCharacter.Rasa = "Krasnolud";
                profesje = string.Join("` : `", template.ProfesjeDwarf);
            }
            else if (raceResult.Result.Emoji == emojis.niziolki)
            {
                PlayerCharacter.Rasa = "Niziołek";
                profesje = string.Join("` : `", template.ProfesjeHalfling);
            }
            await userChannel.SendMessageAsync("Choose `one` from below:");
            await userChannel.SendMessageAsync(profesje);
            string wybranaProfesja = string.Empty;
            do
            {
                inputStep = new StringStep("bottom text", "You pick by writing `one` of the `proffesions` above", null);
                inputStep.OnValidResult += (result) => input = result;
                inputDialogueHandler = new DialogueHandler(
                   ctx.Client,
                   userChannel,
                   ctx.User,
                   inputStep
                   );
                await inputDialogueHandler.ProcessDialogue();
                wybranaProfesja = input;
            } while (!template.profesje.Contains(input));
            PlayerCharacter.proffesion = wybranaProfesja;

            List<int> rollPolOne = new List<int>();
            List<int> rollPollTwo = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                rollPolOne.Add(randomNumber.Next(1, 10) + randomNumber.Next(1, 10));
                rollPollTwo.Add(randomNumber.Next(1, 10) + randomNumber.Next(1, 10));
            }
            await userChannel.SendMessageAsync("Here are your two sets of die rolls");
            string pierwszaPulaString = string.Join("` : `", rollPolOne);
            string drugaPulaString = string.Join("` : `", rollPollTwo);
            var poolOneEmbed = new DiscordEmbedBuilder
            {
                Title = "First set",
                Description = pierwszaPulaString
            };
            var pool2ncEmbed = new DiscordEmbedBuilder
            {
                Title = "Second set",
                Description = drugaPulaString
            };
            await userChannel.SendMessageAsync(embed: poolOneEmbed);
            await userChannel.SendMessageAsync(embed: pool2ncEmbed);
            var PoolEmbed = new DiscordEmbedBuilder
            {
                Title = "What set do `you` choose?",
                Description = emojis.one + " - for 1st set" + System.Environment.NewLine + emojis.two + "- for 2nd set",
                Color = DiscordColor.Gold
            };
            var PoolChoice = await userChannel.SendMessageAsync(embed: PoolEmbed);
            await PoolChoice.CreateReactionAsync(emojis.one);
            await PoolChoice.CreateReactionAsync(emojis.two);
            Thread.Sleep(300);
            var PoolResult = await interactivity.WaitForReactionAsync(x => x.Message == PoolChoice
            &&
            (x.Emoji == emojis.one || x.Emoji == emojis.two)).ConfigureAwait(false);
            if (PoolResult.Result.Emoji == emojis.one)
            {
                PulaLiczb = rollPolOne;
            }
            if (PoolResult.Result.Emoji == emojis.two)
            {
                PulaLiczb = rollPollTwo;
            }

            ///////// 7 cech

            string[] tytuly = new string[]
            {
                       "Wybierz która z liczb będzie Twoją Walka wręcz","Wybierz która z liczb będzie Twoją Umiejętnością Strzelecką","Wybierz która z liczb będzie Twoją Krzepą",
                       "Wybierz która z liczb będzie Twoją Odpornością","Wybierz która z liczb będzie Twoją Zręcznością?","Wybierz która z liczb będzie Twoją Inteligencją?","Wybierz która z liczb będzie Twoją Siłą Woli?","Wybierz która z liczb będzie Twoją Oglada?"

            };
            int[] liczby = new int[8];
            int siurek = PulaLiczb.Count;
            for (int i = 0; i <= siurek; i++) //loop przez wszystkie cechy
            {
                if (PulaLiczb.Count <= 0) break;
                string WszystkieCechyString = string.Join("` : `", PulaLiczb);
                var CechaEmbed = new DiscordEmbedBuilder
                {
                    Title = tytuly[i],
                    Description = WszystkieCechyString
                };
                var cechaMsg = await userChannel.SendMessageAsync(embed: CechaEmbed);
                for (int j = 0; j < PulaLiczb.Count; j++)
                {
                    await cechaMsg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(100);
                var WWResult = await interactivity.WaitForReactionAsync(x => x.Message == cechaMsg
                &&
                (x.Emoji == emojis.one || x.Emoji == emojis.two || x.Emoji == emojis.three || x.Emoji == emojis.four || x.Emoji == emojis.five || x.Emoji == emojis.six || x.Emoji == emojis.seven)).ConfigureAwait(false);
                if (WWResult.Result.Emoji == emojis.one)
                {
                    liczby[i] = PulaLiczb[0];
                    PulaLiczb.RemoveAt(0);
                }
                if (WWResult.Result.Emoji == emojis.two)
                {
                    liczby[i] = PulaLiczb[1];
                    PulaLiczb.RemoveAt(1);
                }
                if (WWResult.Result.Emoji == emojis.three)
                {
                    liczby[i] = PulaLiczb[2];
                    PulaLiczb.RemoveAt(2);
                }
                if (WWResult.Result.Emoji == emojis.four)
                {
                    liczby[i] = PulaLiczb[3];
                    PulaLiczb.RemoveAt(3);
                }
                if (WWResult.Result.Emoji == emojis.five)
                {
                    liczby[i] = PulaLiczb[4];
                    PulaLiczb.RemoveAt(4);
                }
                if (WWResult.Result.Emoji == emojis.six)
                {
                    liczby[i] = PulaLiczb[5];
                    PulaLiczb.RemoveAt(5);
                }
                if (WWResult.Result.Emoji == emojis.seven)
                {
                    liczby[i] = PulaLiczb[6];
                    PulaLiczb.RemoveAt(6);
                }
                if (WWResult.Result.Emoji == emojis.eight)
                {
                    liczby[i] = PulaLiczb[7];
                    PulaLiczb.RemoveAt(7);
                }
                await userChannel.DeleteMessageAsync(cechaMsg);
            }
            //wychodzi z loopa (sprawdzone, rzecvzywiście wychodzi)
            ///dodanie bazowych rzeczh
            template.AddDefaultValues(PlayerCharacter);
            PlayerCharacter.umiejetnosci = new List<string>();
            PlayerCharacter.zdolnosci = new List<string>();
            PlayerCharacter.walka_wrecz += liczby[0];
            PlayerCharacter.strzelectwo += liczby[1];
            PlayerCharacter.krzepa += liczby[2];
            PlayerCharacter.odpowrnosc += liczby[3];
            PlayerCharacter.zrecznosc += liczby[4];
            PlayerCharacter.inteligencjal += liczby[5];
            PlayerCharacter.sila_woli += liczby[6];
            PlayerCharacter.Oglada += liczby.Last();
            PlayerCharacter.sila = (int)(PlayerCharacter.krzepa.ToString()[0]) - 48;
            PlayerCharacter.wytrzymalosc = (int)(PlayerCharacter.odpowrnosc.ToString()[0]) - 48;
            PlayerCharacter.zywotnosc = template.PoczatkowaZywotnosc(PlayerCharacter.Rasa);
            PlayerCharacter.heigth = template.PoczatkowaWysokosc(PlayerCharacter.Rasa, PlayerCharacter.plec);
            PlayerCharacter.weight = template.RandomWeight(PlayerCharacter.Rasa);
            PlayerCharacter.przeznaczenie = template.PoczatkowePrzeznaczenie(PlayerCharacter.Rasa.ToLower());
            PlayerCharacter.ataki = 1;
            PlayerCharacter.szybkosc = template.PoczatkowaSzybkosz(PlayerCharacter.Rasa.ToLower());
            PlayerCharacter.przedmioty = new List<KeyValuePair<string, int>>();
            PlayerCharacter.choroby = new List<string>();

            template.AddStartUmiejetnosci(PlayerCharacter);
            var ostatnia_wiadomosc = new DiscordEmbedBuilder
            {
                Title = "Your character: " + ctx.Member.DisplayName,
                Description = "`Name:` " + Charactername + System.Environment.NewLine +
                           "`Race:` " + PlayerCharacter.Rasa + System.Environment.NewLine +
                           "`Gender:` " + PlayerCharacter.plec_string + System.Environment.NewLine +
                           "`Hair Colour:` " + PlayerCharacter.hair_color + System.Environment.NewLine +
                           "`Hair Colour:` " + PlayerCharacter.eye_color + System.Environment.NewLine +
                           "`walka w ręcz:` " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                           "`Strzelectwo:` " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                           "`Krzepa:` " + PlayerCharacter.krzepa + System.Environment.NewLine +
                           "`odporność:` " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                           "`Dexterity:` " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                           "`Inteligence:` " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                           "`Will power:` " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                           "`Ogłada:` " + PlayerCharacter.Oglada + System.Environment.NewLine +
                           "`Ataki:` " + PlayerCharacter.ataki + System.Environment.NewLine +
                           "`żywotność:` " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                           "`Strength:` " + PlayerCharacter.sila + System.Environment.NewLine +
                           "`Wytrzymałość:` " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                           "`Szybkość:` " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                           "`Magic:` " + PlayerCharacter.magia + System.Environment.NewLine +
                           "`Insanity:` " + PlayerCharacter.obled + System.Environment.NewLine +
                           "`Przeznaczenie:` " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                           "`Profession:` " + PlayerCharacter.proffesion + System.Environment.NewLine +
                           "`Age:` " + PlayerCharacter.age + System.Environment.NewLine +
                           "`Height:` " + PlayerCharacter.heigth + System.Environment.NewLine +
                           "`Weight:` " + PlayerCharacter.weight,
                Color = DiscordColor.IndianRed
            };
            var fluffEmbed = new DiscordEmbedBuilder
            {
                Title = "Your Background Story: " + Charactername,
                Description = PlayerCharacter.fluff
            };
            DirectoryInfo di = Directory.CreateDirectory(ctx.Member.Id.ToString() + "/warhammer/");
            string json = JsonConvert.SerializeObject(PlayerCharacter);
            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + Charactername + ".json", json);
            await userChannel.SendMessageAsync(embed: ostatnia_wiadomosc);
            await userChannel.SendMessageAsync(embed: fluffEmbed);
        }
        public async Task Create(CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
            WHF_Infotables template = new WHF_Infotables();
            warhammer PlayerCharacter = new warhammer();
            var inputStep = new StringStep("", "Witaj w kreatorze postaci do Warhammera" + System.Environment.NewLine + "What is your `Name`?", null);

            string input = string.Empty;


            bool plec = new bool(); // false - kobieta, true - mezczyzna
            string plec_string = string.Empty;
            List<string> umiejetnosci = new List<string>();
            List<string> zdolnosci = new List<string>();

            string Charactername = string.Empty;

            inputStep.OnValidResult += (result) => input = result;
            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                userChannel,
                ctx.User,
                inputStep
                );
            await inputDialogueHandler.ProcessDialogue();
            Charactername = input;  //added char name

            var SexEmbed = new DiscordEmbedBuilder
            {
                Title = "What `gender` are you?",
                Description = emojis.kobieta + " - For Female" + System.Environment.NewLine + emojis.mezczyzna + "- For male",
                Color = DiscordColor.Gold
            };
            var sexMsg = await userChannel.SendMessageAsync(embed: SexEmbed);
            await sexMsg.CreateReactionAsync(emojis.kobieta);
            await sexMsg.CreateReactionAsync(emojis.mezczyzna);
            var interactivity = ctx.Client.GetInteractivity();
            Thread.Sleep(300);
            var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == sexMsg
            &&
            (x.Emoji == emojis.kobieta || x.Emoji == emojis.mezczyzna)).ConfigureAwait(false);
            if (sexResult.Result.Emoji == emojis.kobieta)
            {
                plec = false;
                plec_string = "Female";
            }
            else if (sexResult.Result.Emoji == emojis.mezczyzna)
            {
                plec = true;
                plec_string = "Male";
            }

            var RaseEmbed = new DiscordEmbedBuilder
            {
                Title = "What Race are you?",
                Description = emojis.human + " -for human race" + System.Environment.NewLine + emojis.elf + " -for elf race" + System.Environment.NewLine + emojis.krasnoludy + " -for dwarfs" + System.Environment.NewLine + emojis.niziolki + "- for halfling",
                Color = DiscordColor.Red
            };
            var raceMsg = await userChannel.SendMessageAsync(embed: RaseEmbed);
            await raceMsg.CreateReactionAsync(emojis.human);
            await raceMsg.CreateReactionAsync(emojis.elf);
            await raceMsg.CreateReactionAsync(emojis.krasnoludy);
            await raceMsg.CreateReactionAsync(emojis.niziolki);
            Thread.Sleep(300);
            var raceResult = await interactivity.WaitForReactionAsync(x => x.Message == raceMsg
            &&
            (x.Emoji == emojis.human || x.Emoji == emojis.elf || x.Emoji == emojis.krasnoludy || x.Emoji == emojis.niziolki)).ConfigureAwait(false);
            Thread.Sleep(10);
            ////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////////////
            inputStep = new StringStep("", "What is you `Eye Colour`", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            string kolor_oczu = input;

            inputStep = new StringStep("", "What is your `Hair Colour`", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            string kolor_wlosow = input;


            ////////////////////////////////////////////////////////////////////
            if (raceResult.Result.Emoji == emojis.human)
            {
                PlayerCharacter = template.CreateHuman(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(300);
            }
            else if (raceResult.Result.Emoji == emojis.elf)
            {
                PlayerCharacter = template.CreateElf(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(300);
            }
            else if (raceResult.Result.Emoji == emojis.krasnoludy)
            {
                PlayerCharacter = template.CreateDwarf(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(300);
            }
            else
            {
                PlayerCharacter = template.CreateHalfling(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(300);
            }
            inputStep = new StringStep("", "What is your background story?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            PlayerCharacter.fluff = input;

            inputStep = new StringStep("", "How `old` are you?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            PlayerCharacter.age = Int32.Parse(input);

            DirectoryInfo di = Directory.CreateDirectory(ctx.Member.Id.ToString() + "/warhammer/");
            string json = JsonConvert.SerializeObject(PlayerCharacter);
            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + Charactername + ".json", json);

            var ostatnia_wiadomosc = new DiscordEmbedBuilder
            {
                Title = "Your Character: " + ctx.Member.DisplayName,
                Description = "`Name:` " + Charactername + System.Environment.NewLine +
                            "`Race:` " + PlayerCharacter.Rasa + System.Environment.NewLine +
                            "`Gender:` " + PlayerCharacter.plec_string + System.Environment.NewLine +
                            "`Hair Colour:` " + PlayerCharacter.hair_color + System.Environment.NewLine +
                            "`Eye Colour:` " + PlayerCharacter.eye_color + System.Environment.NewLine +
                            "`walka w ręcz:` " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                            "`Strzelectwo:` " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                            "`Krzepa:` " + PlayerCharacter.krzepa + System.Environment.NewLine +
                            "`odporność:` " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                            "`Dexterity:` " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                            "`Inteligence:` " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                            "`Sila woli:` " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                            "`Ogłada:` " + PlayerCharacter.Oglada + System.Environment.NewLine +
                            "`Ataki:` " + PlayerCharacter.ataki + System.Environment.NewLine +
                            "`żywotność:` " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                            "`Strength:` " + PlayerCharacter.sila + System.Environment.NewLine +
                            "`Wytrzymałość:` " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                            "`Szybkość:` " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                            "`Magic:` " + PlayerCharacter.magia + System.Environment.NewLine +
                            "`Insanity:` " + PlayerCharacter.obled + System.Environment.NewLine +
                            "`Przeznaczenie:` " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                            "`Profesion:` " + PlayerCharacter.proffesion + System.Environment.NewLine +
                            "`Age:` " + PlayerCharacter.age + System.Environment.NewLine +
                            "`Height:` " + PlayerCharacter.heigth + System.Environment.NewLine +
                            "`Weight:` " + PlayerCharacter.weight,
                Color = DiscordColor.IndianRed
            };

            var fluffEmbed = new DiscordEmbedBuilder
            {
                Title = "Your background Story: " + Charactername,
                Description = PlayerCharacter.fluff
            };
            await userChannel.SendMessageAsync(embed: ostatnia_wiadomosc);
            await userChannel.SendMessageAsync(embed: fluffEmbed);
        }
        public async Task Journal(CommandContext ctx, string rpgSystem, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var userChannel = await ctx.Member.CreateDmChannelAsync();
                var userID = ctx.Member.Id;
                string say = string.Join(" ", input).Trim().ToLower();
                if (say[0] == 'r')
                {

                    if (File.Exists(ctx.Member.Id.ToString() + "/" + rpgSystem + "/" + "journal.txt"))
                    {
                        string output = File.ReadAllText(ctx.Member.Id.ToString() + "/" + rpgSystem + "/" + "journal.txt");
                        var emb = new DiscordEmbedBuilder
                        {
                            Title = "Your Journal",
                            Description = output
                        };
                        await userChannel.SendMessageAsync(embed: emb);
                    }
                    else
                    {
                        await userChannel.SendMessageAsync("you have no journal yet");
                    }
                }
                if (say[0] == 'w')
                {
                    string output = string.Empty;
                    if (File.Exists(ctx.Member.Id.ToString() + "/" + rpgSystem + "/" + "journal.txt"))
                    {
                        output = File.ReadAllText(ctx.Member.Id.ToString() + "/" + rpgSystem + "/" + "journal.txt");
                        var emb = new DiscordEmbedBuilder
                        {
                            Title = "Your Journal",
                            Description = output
                        };
                        await userChannel.SendMessageAsync(embed: emb);
                    }
                    else
                    {
                        await userChannel.SendMessageAsync("you have no journal yet");
                    }
                    await userChannel.SendMessageAsync("What do you want to write?");
                    var addition = await userChannel.GetNextMessageAsync();
                    var additionstring = addition.Result.Content;
                    output += additionstring;
                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + rpgSystem + "/" + "journal.txt", output);
                }
            }
        }
        public async Task Mutate(CommandContext ctx, DiscordMember user, params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        if (character.mutacje == null)
                        {
                            character.mutacje = new List<string>();
                        }
                        var mutacja = string.Join(" ", input);
                        var mutacje = character.mutacje.ToList();
                        mutacje.Add(mutacja);
                        string wiadomosc = string.Join(Environment.NewLine, mutacje);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Mutations of: " + character.CharName,
                            Description = wiadomosc
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);
                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }
            }
        }
        public async Task Mutations(CommandContext ctx, DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        if (character.mutacje == null)
                        {
                            character.mutacje = new List<string>();
                        }
                        var mutacje = character.mutacje.ToList();
                        string wiadomosc = string.Join(Environment.NewLine, mutacje);
                        var history = new DiscordEmbedBuilder
                        {
                            Title = "Mutations of: " + character.CharName,
                            Description = wiadomosc
                        };
                        await ctx.Channel.SendMessageAsync(embed: history);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }
            }
        }
    }
}