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
        public string spellName { get; set; }
        public int level { get; set; }
        public string school { get; set; }
        public string castTime { get; set; }
        public string range { get; set; }
        public string duration { get; set; }
        public string classes { get; set; }
    }
    public class DnDitem
    {
        public string name { get; set; }
        public string descr { get; set; }
        public int amount { get; set; }
    }
   
    public class DnDSpellist
    {
        public List<DnDSpells> Arkusz1 = new List<DnDSpells>();
        public List<DnDSpells> lvl_0 = new List<DnDSpells>();
        public List<DnDSpells> lvl_1 = new List<DnDSpells>();
        public List<DnDSpells> lvl_2 = new List<DnDSpells>();
        public List<DnDSpells> lvl_3 = new List<DnDSpells>();
        public List<DnDSpells> lvl_4 = new List<DnDSpells>();
        public List<DnDSpells> lvl_5 = new List<DnDSpells>();
        public List<DnDSpells> lvl_6 = new List<DnDSpells>();
        public List<DnDSpells> lvl_7 = new List<DnDSpells>();
        public List<DnDSpells> lvl_8 = new List<DnDSpells>();
        public List<DnDSpells> lvl_9 = new List<DnDSpells>();
    }
    

}