using DiscordApp.Handlers;
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
        public int level;
        public string name;
        public string race;
        public string gender;
        public int exp;
        public string Faction;

        public string background;
        #region stats
        public Dictionary<string, int> BaseStats = new Dictionary<string, int>()
        {
            { "Strength",0},
            { "Dexterity",0},
            { "Constitution",0},
            { "Intelligence",0},
            { "Wisdom",0},
            { "Charisma",0},
        };
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
            { "religion",0},
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
        //public string backstory;
        //public List<string> treasure;
        //public List<string> allies;
        #endregion

    }
    public class DnDInventory
    {
        public List<object> inventoryList = new List<object>();

        public void Add(string v1, string v2, int startMoney)
        {
            string itemName = string.Empty;
            int i = 0;
            foreach (var item in inventoryList) //znajduje itemek
            {
                DnDitem var = (DnDitem)item;
                if (var.name.Trim().ToLower() == v1.Trim().ToLower())
                {
                    itemName = var.name;
                    break;
                }
                i++;
            }
            if (string.IsNullOrEmpty(itemName)) // nie ma takiego itemka, dodaj do listy
            {
                var item = new DnDitem();
                item.name = v1;
                item.descr = v2;
                item.amount = startMoney;
                inventoryList.Add(item);
            }
            else//znalazł itemek, dodajemy
            {
               ((DnDitem)inventoryList[i]).amount += startMoney;
            }
        }
        public void Add(string v1, int amount)
        {
            string itemName = string.Empty;
            int i = 0;
            foreach (var item in inventoryList) //znajduje itemek
            {
                DnDitem var = (DnDitem)item;
                if (var.name.Trim().ToLower() == v1.Trim().ToLower())
                {
                    itemName = var.name;
                    break;
                }
                i++;
            }
            if (string.IsNullOrEmpty(itemName)) // nie ma takiego itemka, dodaj do listy
            {
                DnDitem var = static_objects.dnd_template.items.GetitemFromName(v1);
                var.amount = amount;
                inventoryList.Add(var);
            }
            else//znalazł itemek, dodajemy
            {
                ((DnDitem)inventoryList[i]).amount += amount;
            }
        }

        public void remove(string v1, int amount)
        {
            
            string itemName = string.Empty;
            int i = 0;
            foreach (var item in inventoryList ) //znajduje itemek
            {
                DnDitem var = (DnDitem)item;
                if (var.name.Trim().ToLower() == v1.Trim().ToLower())
                {
                    itemName = var.name;
                    break;
                }
                i++;
            }
            if (string.IsNullOrEmpty(itemName))
            {

            }
            else
            {
               
                ((DnDitem) inventoryList[i]).amount -= amount;
                if(((DnDitem)inventoryList[i]).amount<=0)
                {
                    inventoryList.RemoveAt(i);
                }
            }
        }
        public async Task showInventory(DiscordChannel ctx, params string[] charname)
        {
            string descrr = string.Empty;
            foreach (var item in inventoryList )
            {
                DnDitem var = (DnDitem)item;
                descrr += var.name + ", amount: " + var.amount + Environment.NewLine;
            }
            var inventoryEmbed = new DiscordEmbedBuilder
            {
                Title = "Inventory of: " + "**" + string.Join(" ", charname) + "**",
                Description = descrr
            };
            await ctx.SendMessageAsync(embed: inventoryEmbed);
        }
        public async Task showItem(CommandContext ctx, params string[] itemnanme)
        {
            string name = string.Join(" ", itemnanme).Trim().ToLower();
            string descr = string.Empty;
            foreach (var item in inventoryList.ToArray()) //znajduje itemek
            {
                DnDitem var = (DnDitem)item;
                if (var.name.Trim().ToLower() == name.Trim().ToLower())
                {
                    name = var.name;
                    descr = var.descr;
                    break;
                }
            }
            var itemEmbed = new DiscordEmbedBuilder
            {
                Title = "**" + name + "**",
                Description = "*" + descr + "*"
            };
            await ctx.Channel.SendMessageAsync(embed: itemEmbed);
        }

    }
}
