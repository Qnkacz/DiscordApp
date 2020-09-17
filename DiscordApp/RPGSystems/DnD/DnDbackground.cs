using DiscordApp.Handlers;
using System.Collections.Generic;

namespace DiscordApp.RPGSystems.DnD
{
    public class DnDbackground
    {
        public string name;
        public List<string> SkillProficiencies;
        public Dictionary<DnDitem, int> items = new Dictionary<DnDitem, int>();
        public string personalityTrait;
        public string ideal;
        public string bond;
        public string flaw;

        public DnDbackground(dnd_infotables.backgrounds bks)
        {
            int trait_random = static_objects.WHF_template.r.Next(0, 7);
            int ideal_random = static_objects.WHF_template.r.Next(0, 5);
            int bond_random = static_objects.WHF_template.r.Next(0, 5);
            int flaw_random = static_objects.WHF_template.r.Next(0, 5);

            switch (bks)
            {
                case dnd_infotables.backgrounds.acolyte:
                    #region acolyte
                    name = "acolyte";
                    SkillProficiencies = new List<string>() { "insight", "religion" };
                    items.Add(new DnDitem("Holy symbol", "a gift to you when you entered the priesthood)"), 1);
                    items.Add(new DnDitem("Prayer book", "holds the prayers of your god"), 1);
                    items.Add(new DnDitem("Incense", "smells nice"), 5);
                    items.Add(new DnDitem("gold", "Currency in the game"), 15);
                    
                    ideal = static_objects.dnd_template.ideal_acolyte[trait_random];
                    bond = static_objects.dnd_template.bond_acolyte[bond_random];
                    flaw = static_objects.dnd_template.flaw_acolyte[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_acolyte[trait_random];
                    
                    #endregion
                    break;
                case dnd_infotables.backgrounds.criminal:
                    #region criminal
                    items.Add(new DnDitem("crowbar", "watch out for headcrabs!"), 1);
                    items.Add(new DnDitem("Dark clothes", "the common type!"), 1);
                    items.Add(new DnDitem("Gold", "currency in the game!"), 15);
                    ideal = static_objects.dnd_template.ideal_criminal[trait_random];
                    bond = static_objects.dnd_template.bond_criminal[bond_random];
                    flaw = static_objects.dnd_template.flaw_criminal[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_criminal[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.folkHero:
                    #region folkHero
                    items.Add(new DnDitem("shovel", "TO dig holes"), 1);
                    items.Add(new DnDitem("Iron pot", "You can cook in it"), 1);
                    items.Add(new DnDitem("Gold", "currency in the game!"), 10);
                    ideal = static_objects.dnd_template.ideal_folkHero[trait_random];
                    bond = static_objects.dnd_template.bond_folkHero[bond_random];
                    flaw = static_objects.dnd_template.flaw_folkhero[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_folkHero[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.noble:
                    #region noble
                    items.Add(new DnDitem("set of fine clothes", "Fancy!"), 1);
                    items.Add(new DnDitem("a signer ring", "rom a dead colleague posing a question you have not yet been able to answer"), 1);
                    items.Add(new DnDitem("Gold", "currency in the game!"), 25);
                    ideal = static_objects.dnd_template.ideal_noble[trait_random];
                    bond = static_objects.dnd_template.bond_noble[bond_random];
                    flaw = static_objects.dnd_template.flaw_noble[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_noble[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.sage:
                    #region sage
                    items.Add(new DnDitem("bottle of blank inc", "for writing a message"), 1);
                    items.Add(new DnDitem("a letter", "rom a dead colleague posing a question you have not yet been able to answer"), 1);
                    items.Add(new DnDitem("Gold", "currency in the game!"), 10);
                    ideal = static_objects.dnd_template.ideal_sage[trait_random];
                    bond = static_objects.dnd_template.bond_sage[bond_random];
                    flaw = static_objects.dnd_template.flaw_sage[flaw_random];
                    personalityTrait = static_objects.dnd_template.trait_sage[trait_random];
                    #endregion
                    break;
                case dnd_infotables.backgrounds.soldier:
                    #region soldier
                    items.Add(new DnDitem("insignia of rank", "An antique!"), 1);
                    items.Add(new DnDitem("Trophy", "from an old enemy"), 1);
                    items.Add(new DnDitem("A set of cards", "For making money and enemies"), 1);
                    items.Add(new DnDitem("Gold", "currency in the game!"), 10);
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