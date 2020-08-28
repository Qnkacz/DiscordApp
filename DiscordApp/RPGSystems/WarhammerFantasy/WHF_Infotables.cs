using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string[] losowa_umiejetnosc =
     {
            "bardzo silny","bardzo szybki","błyskotliwy","bystry wzrok","charyzmatyczny","czuł słuch","geniusz arytmetyczny","krzepki","naśladowca","niezwykle odporny",
            "oburecznosc","odpornosc na choroby","odpornosc na magie","odpornosc na trucizny","odpornosc psychiczna","opanowanie","strzelec wyborowy","szczescie",
            "szósty zmysł","szybki refleks","twardziel","urodzony wojownik","widzenie w ciemnosci"
        };
        public string[] profesje =
        {
            "akolita","banita","berserker z norski","chlop","w pizde, nie chce mi sie tego pisac"
        };
        public enum race { human, elf, krasnolud, nizlioek };
        public warhammer CreateHuman(string name, bool _sex, string eyes, string hair)
        {
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);

            Profesja = profesje[randomNumber.Next(0, profesje.Length)];

            Race = "człowiek";
            walka_wrecz = 20 + randomNumber.Next(1,10) + randomNumber.Next(1,10);
            strzelectwo = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            krzepa = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            odpowrnosc = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            zrecznosc = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            inteligencjal = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            sila_woli = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            Oglada = 20 + randomNumber.Next(1, 10) + randomNumber.Next(1, 10);
            ataki = 1;

            sila = (int)(krzepa.ToString()[0]) - 48;
            wytrzymalosc = (int)(odpowrnosc.ToString()[0]) - 48;
            szybkosc = 4;
            magia = 0;
            obled = 0;
            if (plec == false)//kobieta
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, 80, eyes, hair, umiejetnosci, zdolnosci);
            return postac;
        }
        public warhammer CreateElf(string name, bool _sex, string eyes, string hair)
        {
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);

            Profesja = profesje[randomNumber.Next(0, profesje.Length)];

            Race = "elf";
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
            if (plec == false)//kobieta
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, 80, eyes, hair, umiejetnosci, zdolnosci);
            return postac;
        }

        internal warhammer CreateDwarf(string name, bool _sex, string eyes, string hair)
        {
            Race = "krasnolud";
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);

            Profesja = profesje[randomNumber.Next(0, profesje.Length)];

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
            if (plec == false)//kobieta
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, 80, eyes, hair, umiejetnosci, zdolnosci);
            return postac;
        }

        internal warhammer CreateHalfling(string name, bool _sex, string eyes, string hair)
        {
            Race = "niziołek";
            Random randomNumber = new Random();
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);

            Profesja = profesje[randomNumber.Next(0, profesje.Length)];

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
            if (plec == false)//kobieta
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
                                            magia, obled, przeznaczenie, Profesja, 25, wysokosc, 80, eyes, hair, umiejetnosci, zdolnosci);
            return postac;
        }
    }
}
