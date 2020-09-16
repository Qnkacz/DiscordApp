using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.RPGSystems.DnD
{
    public class DnD
    {
        public string name;
        public string race;
        public string gender;
        public int exp;
        public string Faction;
        #region stats
        public Dictionary<string, int> BaseStats = new Dictionary<string, int>();
        #endregion
        #region skills
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
        public List<CharacterClass> CharacterClass = new List<CharacterClass>();
        public List<attacksNSpells> atackList = new List<attacksNSpells>();
        public List<KeyValuePair<string, int>> equipment = new List<KeyValuePair<string, int>>();
        public List<DnDSpells> spells= new List<DnDSpells>();
        #region personality stuff
        public List<DnDTrait> Traits = new List<DnDTrait>();
        public string aligment = string.Empty;
        public List<string> ideals = new List<string>();
        public List<string> bonds = new List<string>();
        public List<string> flaws = new List<string>();
        public List<string> features = new List<string>();
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
        #endregion
        #region other
        public string backstory;
        public List<string> treasure;
        public List<string> allies;
        #endregion

    }
}
