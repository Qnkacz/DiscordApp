using DiscordApp.Handlers;
using System.Collections.Generic;

namespace DiscordApp.RPGSystems.DnD
{
    public struct DnDbackground
    {
        public string name;
        public List<string> SkillProficiencies;
        public DnDInventory items;
        public string personalityTrait;
        public string ideal;
        public string bond;
        public string flaw;

        public DnDbackground(dnd_infotables.backgrounds bks)
        {
            personalityTrait = string.Empty;
            name = string.Empty;
            ideal = string.Empty;
            bond = string.Empty;
            flaw = string.Empty;
            SkillProficiencies = new List<string>();
            int trait_random = static_objects.WHF_template.r.Next(0, 7);
            int ideal_random = static_objects.WHF_template.r.Next(0, 5);
            int bond_random = static_objects.WHF_template.r.Next(0, 5);
            int flaw_random = static_objects.WHF_template.r.Next(0, 5);
            items = new DnDInventory();

            switch (bks)
            {
                case dnd_infotables.backgrounds.acolyte:
                    #region acolyte
                    name = "acolyte";
                    SkillProficiencies = new List<string>() { "insight", "religion" };
                    items.Add("Holy symbol", 1);
                    items.Add("Prayer book", 1);
                    items.Add("Incense", 5);
                    items.Add("gold", 15);
                    
                    ideal = static_objects.dnd_template.ideal_acolyte[trait_random];
                    bond = static_objects.dnd_template.bond_acolyte[bond_random];
                    flaw = static_objects.dnd_template.flaw_acolyte[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_acolyte[trait_random];
                    
                    #endregion
                    break;
                case dnd_infotables.backgrounds.criminal:
                    #region criminal
                    name = "criminal";
                    SkillProficiencies = new List<string>() { "deception", "stealth" };
                    items.Add("crowbar", 1);
                    items.Add("Dark clothes", 1);
                    items.Add("Gold", 15);
                    ideal = static_objects.dnd_template.ideal_criminal[trait_random];
                    bond = static_objects.dnd_template.bond_criminal[bond_random];
                    flaw = static_objects.dnd_template.flaw_criminal[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_criminal[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.folkHero:
                    #region folkHero
                    name = "folk hero";
                    SkillProficiencies = new List<string>() { "animal handling", "survival" };
                    items.Add("shovel", 1);
                    items.Add("Iron pot", 1);
                    items.Add("Gold", 10);
                    ideal = static_objects.dnd_template.ideal_folkHero[trait_random];
                    bond = static_objects.dnd_template.bond_folkHero[bond_random];
                    flaw = static_objects.dnd_template.flaw_folkhero[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_folkHero[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.noble:
                    #region noble
                    name = "noble";
                    SkillProficiencies = new List<string>() { "history", "persuation" };
                    items.Add("set of fine clothes", 1);
                    items.Add("a signer ring", 1);
                    items.Add("Gold", 25);
                    ideal = static_objects.dnd_template.ideal_noble[trait_random];
                    bond = static_objects.dnd_template.bond_noble[bond_random];
                    flaw = static_objects.dnd_template.flaw_noble[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_noble[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.sage:
                    #region sage
                    name = "sage";
                    SkillProficiencies = new List<string>() { "arcana", "history" };
                    items.Add("bottle of blank inc", 1);
                    items.Add("a letter", 1);
                    items.Add("Gold", 10);
                    ideal = static_objects.dnd_template.ideal_sage[trait_random];
                    bond = static_objects.dnd_template.bond_sage[bond_random];
                    flaw = static_objects.dnd_template.flaw_sage[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_sage[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.soldier:
                    #region soldier
                    name = "soldier";
                    SkillProficiencies = new List<string>() { "athletics", "intimidation" };
                    items.Add("insignia of rank", 1);
                    items.Add("Trophy", 1);
                    items.Add("A set of cards", 1);
                    items.Add("Gold", 10);
                    ideal = static_objects.dnd_template.ideal_soldier[trait_random];
                    bond = static_objects.dnd_template.bond_soldier[bond_random];
                    flaw = static_objects.dnd_template.flaw_soldier[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_soldier[trait_random];
                    #endregion
                    break;
            }
        }
    }

}