using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.RPGSystems.DnD
{
    public class DnD
    {
        public string name;
        public string race;
        public int exp;
        public string Faction;
        #region stats
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;
        public int wisdom;
        public int charisma;
        #endregion
        #region abilities
        public int acrobatics;
        public int animal_handling;
        public int arcana;
        public int athletics;
        public int deception;
        public int history;
        public int insight;
        public int Intimidation;
        public int medicine;
        public int nature;
        public int perception;
        public int performance;
        public int persuation;
        public int relion;
        public int relions;
        public int sleight_of_hand;
        public int stealth;
        public int survival;
        #endregion
        #region fightpoints
        public int maxHP;
        public int currHP;
        public int tempHP;
        public int armor;
        public int initiative;
        public int speed;
        #endregion
        public List<attacksNSpells> atackList;
        public List<string> equipment;
        #region personality stuff
        public List<string> Traits;
        public List<string> ideals;
        public List<string> bonds;
        public List<string> flaws;
        public List<string> features;
        #endregion
        #region body
        public int age;
        public int height;
        public int weight;
        public string eyes;
        public string skin;
        public string hair;
        #endregion
        #region other
        public string backstory;
        public List<string> treasure;
        public List<string> allies;
        #endregion

    }
}
