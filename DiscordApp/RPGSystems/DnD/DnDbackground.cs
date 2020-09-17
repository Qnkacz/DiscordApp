using System.Collections.Generic;

namespace DiscordApp.RPGSystems.DnD
{
    public class DnDbackground
    {
        public string name;
        public List<string> SkillProficiencies;
        public Dictionary<DnDitem, int> items;
        public string personalityTrait;
        public string ideal;
        public string bond;
        public string flaw;
    }
  
}