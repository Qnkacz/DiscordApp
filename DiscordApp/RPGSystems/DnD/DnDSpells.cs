using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace DiscordApp.RPGSystems.DnD
{
    public struct attacksNSpells
    {
        public string spellName;
        public string description;
        public attacksNSpells(string _name , string _desc)
        {
            spellName = _name;
            description = _desc;
        }
    }

    public struct DnDTrait
    {
        public string spellName;
        public string description;
        public DnDTrait(string _name, string _desc)
        {
            spellName = _name;
            description = _desc;
        }
    }
    public class DnDSpells
    {
        public string spellName;
        public string description;
        public int range;
        public string duration;
        public int level;
        public string school;
        public List<string> classes;
        public DnDSpells(string _name, string _desc,int _range,string _duration,int _level,string _school,List<string> _classes)
        {
            spellName = _name;
            description = _desc;
            range = _range;
            duration = _duration;
            level = _level;
            school = _school;
            classes = _classes;
        }
        public DnDSpells(string _name, string _desc)
        {
            spellName = _name;
            description = _desc;
            range = 666;
            duration = "NA";
        }
    }
    public struct DnDitem
    {
        public string name;
        public string descr;
        public DnDitem(string _name, string _desc)
        {
            name = _name;
            descr = _desc;
        }
    }
   
    public class DnDSpellist
    {
        public List<DnDSpells> spellist = new List<DnDSpells>();
    }

}