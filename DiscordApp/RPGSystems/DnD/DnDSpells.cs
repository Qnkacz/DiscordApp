using System.Collections.Generic;

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
        public DnDSpells(string _name, string _desc,int _range,string _duration)
        {
            spellName = _name;
            description = _desc;
            range = _range;
            duration = _duration;
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
    public class DnDSpellList_cleric
    {
        public List<DnDSpells> level_0 = new List<DnDSpells>()
        {
            
        };
        public List<DnDSpells> level_1 = new List<DnDSpells>()
        {
            {new DnDSpells("Guidance","You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one ability check of its choice. It can roll the die before or after making the ability check. The spell then ends.",0,"up to a minute") },
            {new DnDSpells("Light","You touch one object that is no larger than 10 feet in any dimension. Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet. The light can be colored as you like. Completely covering the object with something opaque blocks the light. The spell ends if you cast it again or dismiss it as an action",0,"1 hour") },
            {new DnDSpells("Resisatance","You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one saving throw of its choice. It can roll the die before or after making the saving throw. The spell then ends.",0,"up to 1 minute") },
            {new DnDSpells("Sacred Flame","Flame-like radiance descends on a creature that you can see within range. The target must succeed on a Dexterity saving throw or take 1d8 radiant damage. The target gains no benefit from cover for this saving throw.The spell’s damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).",60,"Instant") },
            {new DnDSpells("Spare the Dying","You touch a living creature that has 0 hit points. The creature becomes stable. This spell has no effect on un-dead or constructs.",0,"Instant") },
            {new DnDSpells("Thaumaturgy","You manifest a minor wonder, a sign of supernatural power, within range. You create one of the following magical effects within range:",30,"Up to 1 minute") }
        };
        public List<DnDSpells> level_2 = new List<DnDSpells>();
        public List<DnDSpells> level_3= new List<DnDSpells>();
        public List<DnDSpells> level_4= new List<DnDSpells>();
        public List<DnDSpells> level_5= new List<DnDSpells>();
        public List<DnDSpells> level_6= new List<DnDSpells>();
        public List<DnDSpells> level_7= new List<DnDSpells>();
        public List<DnDSpells> level_8= new List<DnDSpells>();
        public List<DnDSpells> level_9= new List<DnDSpells>();
    }
    public class DnDSpellList_wizard
    {
        public List<DnDSpells> level_0 = new List<DnDSpells>();
        public List<DnDSpells> level_1= new List<DnDSpells>();
        public List<DnDSpells> level_2= new List<DnDSpells>();
        public List<DnDSpells> level_3= new List<DnDSpells>();
        public List<DnDSpells> level_4= new List<DnDSpells>();
        public List<DnDSpells> level_5= new List<DnDSpells>();
        public List<DnDSpells> level_6= new List<DnDSpells>();
        public List<DnDSpells> level_7= new List<DnDSpells>();
        public List<DnDSpells> level_8= new List<DnDSpells>();
        public List<DnDSpells> level_9= new List<DnDSpells>();
    }

}