using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.RPGSystems.DnD
{
    public class dnd_infotables
    {
        public List<int> statRollpool = new List<int>();
        public List<int> predetermineRools = new List<int>
        {
            15,14,13,12,10,8
        };
        public enum Races { human, dwarf, Welf, Helf, halfling, half_elf, hhalf_orc, gnome };
        public enum Classes { barbarian, bard, cleric, druid, fighter, monk,palading, ranger,rouge,warlock, sourcerer,wizard };



    }
}
