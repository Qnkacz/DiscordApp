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
        public int price { get; set; }
        public string weight { get; set; }
        public int amount { get; set; }
    }
   
    public class DnDWeapon : DnDitem
    {
        public string damage { get; set; }
        public string properties { get; set; }
    }
    public class DnDArmor : DnDitem
    {
        public string AC { get; set; }
        public string requirements { get; set; }
        public string Stealth { get; set; }
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

        public DnDSpells GetSpellFromName(string name)
        {
            for (int i = 0; i < Arkusz1.Count; i++)
            {
                if(Arkusz1[i].spellName.ToLower().Trim()==name.ToLower().Trim())
                {
                    return Arkusz1[i];
                }
            }
            return null;
        }
    }
    public class DnDItemList
    {
        public List<DnDWeapon> SimpleMeleeWeapons = new List<DnDWeapon>();
        public List<DnDWeapon> SimpleRangedWeapons = new List<DnDWeapon>();
        public List<DnDWeapon> MartialMeleeWeapons = new List<DnDWeapon>();
        public List<DnDWeapon> MartialRangedWeapons = new List<DnDWeapon>();
        public List<DnDArmor> LightArmor = new List<DnDArmor>();
        public List<DnDArmor> MediumArmor = new List<DnDArmor>();
        public List<DnDArmor> HeavyArmor = new List<DnDArmor>();
        public List<DnDitem> Ammunition = new List<DnDitem>();
        public List<DnDitem> Misc = new List<DnDitem>();
        public List<DnDitem> allitems = new List<DnDitem>();
    }

}