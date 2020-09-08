using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.RPGSystems
{
    public class warhammer
    {
        public string CharName;
        
        public string Rasa;
        public int walka_wrecz;
        public int strzelectwo;
        public int krzepa;
        public int odpowrnosc;
        public int zrecznosc;
        public int inteligencjal;
        public int sila_woli;
        public int Oglada;
        public int ataki;
        public int zywotnosc;
        public int sila;
        public int wytrzymalosc;
        public int szybkosc;
        public int magia;
        public int obled;
        public int przeznaczenie;
        public string proffesion;
        public int age;
        public int heigth, weight;
        public string eye_color, hair_color;
        public List<string> umiejetnosci;
        public List<string> zdolnosci;
        public List<string> choroby;
        public string fluff;
        public bool plec; // false - kobieta, true - mezczyzna
        public string plec_string;
        public List<KeyValuePair<string, int>> przedmioty;

        public warhammer(string _name,string _race,string plec,int _ww,int _strzelectwo, int _krzepa,int _odpowrnosc,int _zrecznosc,int _inteligencjal,int _sila_woli,
                         int _Oglada,int _ataki,int _zywotnosc,int _sila, int _wytrzymalosc, int _szybkosc, int _magia, int _obled,int _przeznaczenie,
                         string _profesja, int _age, int _wysokosc, int _waga, string _oczy, string _wlosy, List<string> _umiejetnosci, List<string> _zdolnosci, List<KeyValuePair<string, int>> _items,List<string>_choroby )
        {
            CharName = _name;
            Rasa = _race;
            plec_string = plec;
            walka_wrecz = _ww;
            strzelectwo = _strzelectwo;
            krzepa = _krzepa;
            odpowrnosc = _odpowrnosc;
            zrecznosc = _zrecznosc;
            inteligencjal = _inteligencjal;
            sila_woli = _sila_woli;
            Oglada = _Oglada;
            ataki = _ataki;
            zywotnosc = _zywotnosc;
            sila = _sila;
            wytrzymalosc = _wytrzymalosc;
            szybkosc = _szybkosc;
            magia = _magia;
            obled = _obled;
            przeznaczenie = _przeznaczenie;
            proffesion = _profesja;
            heigth = _wysokosc;
            weight = _waga;
            eye_color = _oczy;
            hair_color = _wlosy;
            umiejetnosci = _umiejetnosci;
            zdolnosci = _zdolnosci;
            przedmioty=_items;
            choroby = _choroby;
        }
        public warhammer() { }
    }
}
