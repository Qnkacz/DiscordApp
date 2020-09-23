using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.DnD
{
    public class DnD
    {
        public string name;
        public string race;
        public string gender;
        public int exp;
        public string Faction;
        public DnDInventory inventory = new DnDInventory();
        public string background;
        #region stats
        public Dictionary<string, int> BaseStats = new Dictionary<string, int>();
        public Dictionary<string, int> BaseStatsModificator = new Dictionary<string, int>()
        {
            { "Strength",0},
            { "Dexterity",0},
            { "Constitution",0},
            { "Intelligence",0},
            { "Wisdom",0},
            { "Charisma",0},
           
        };
        public Dictionary<string, int> baseStatSavingThrow = new Dictionary<string, int>()
        {
            { "Strength",0},
            { "Dexterity",0},
            { "Constitution",0},
            { "Intelligence",0},
            { "Wisdom",0},
            { "Charisma",0},
           
        };
        #endregion
        #region skills

        public Dictionary<string, int> skills = new Dictionary<string, int>()
        {
            { "acrobatics",0},
            { "animal handling",0},
            { "arcana",0},
            { "athletics",0},
            { "deception",0},
            { "history",0},
            { "insight",0},
            { "intimidation",0},
            { "investigation",0},
            { "medicine",0},
            { "nature",0},
            { "perception",0},
            { "performance",0},
            { "persuation",0},
            { "relion",0},
            { "sleight of hand",0},
            { "stealth",0},
            { "survival",0},
        };
        
        #endregion
        #region fightpoints
        public int maxHP;
        public int currHP;
        public int tempHP;
        public int armor;
        public int initiative;
        public int speed;
        #endregion
        public List<CharacterClass> CharacterClass = new List<CharacterClass>();
        public List<attacksNSpells> atackList = new List<attacksNSpells>();
        public List<DnDSpells> spells = new List<DnDSpells>();
        #region personality stuff
        public List<DnDTrait> Traits = new List<DnDTrait>();
        public string personalityTrait;
        public string aligment;
        public string ideals;
        public string bonds;
        public string flaws;
        public string features;
        #endregion
        #region body
        public int age;
        public int height;
        public int weight;
        public string eyes;
        public string skin;
        public string hair;
        #endregion
        #region proficiencies
        public List<string> abilityProficiencies = new List<string>();
        public List<string> SavingThrowProficiencies = new List<string>();
        public List<string> ArmorNWeaponProficiencies = new List<string>();
        public List<string> SkillProficiencies = new List<string>();
        #endregion
        #region other
        public string backstory;
        public List<string> treasure;
        public List<string> allies;
        #endregion

    }
    public class DnDInventory
    {
        public Dictionary<DnDitem, int> inventoryList = new Dictionary<DnDitem, int>();

        public void Add(string v1, string v2, int startMoney)
        {
            string itemName = string.Empty;
            foreach (var item in inventoryList.ToArray()) //znajduje itemek
            {
                if (item.Key.name.Trim().ToLower() == v1.Trim().ToLower())
                {
                    itemName = item.Key.name;
                    break;
                }
            }
            if (string.IsNullOrEmpty(itemName)) // nie ma takiego itemka, dodaj do disct
            {
                inventoryList.Add(new DnDitem(v1, v2), startMoney);
            }
            else//znalazł itemek, dodajemy
            {
                var item = new DnDitem(v1, v2);
                inventoryList[item] += startMoney;
            }
        }

        public void remove(string v1, int amount)
        {
            string itemName = string.Empty;
            string descr = string.Empty;
            foreach (var item in inventoryList.ToArray()) //znajduje itemek
            {
                if (item.Key.name.Trim().ToLower() == v1.Trim().ToLower())
                {
                    itemName = item.Key.name;
                    descr = item.Key.descr;
                    break;
                }
            }
            if (string.IsNullOrEmpty(itemName))
            {

            }
            else
            {
                var item = new DnDitem(v1, descr);

                if (inventoryList[item] - amount <= 0)
                {
                    inventoryList.Remove(item);
                }
                else
                {
                    inventoryList[item] -= amount;
                }
            }
        }
        public async Task showInventory(DiscordChannel ctx,params string[] charname)
        {
            string descrr = string.Empty;
            foreach (var item in inventoryList)
            {
                descrr += item.Key.name + ", amount: " + item.Value+Environment.NewLine;
            }
            var inventoryEmbed = new DiscordEmbedBuilder
            {
                Title = "Inventory of: " + "**" + string.Join(" ",charname) + "**",
                Description=descrr
            };
            await ctx.SendMessageAsync(embed: inventoryEmbed);
        }
        public async Task showItem(CommandContext ctx, params string[] itemnanme)
        {
            string name = string.Join(" ", itemnanme).Trim().ToLower();
            string descr = string.Empty;
            foreach (var item in inventoryList.ToArray()) //znajduje itemek
            {
                if (item.Key.name.Trim().ToLower() == name.Trim().ToLower())
                {
                    name = item.Key.name;
                    descr = item.Key.descr;
                    break;
                }
            }
            var itemEmbed = new DiscordEmbedBuilder
            { 
                Title = "**"+name+"**",
                Description = "*"+descr+"*"
            };
            await ctx.Channel.SendMessageAsync(embed: itemEmbed);
        }
        
    }
}
