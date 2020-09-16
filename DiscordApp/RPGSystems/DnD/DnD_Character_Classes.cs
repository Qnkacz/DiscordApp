using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.RPGSystems.DnD
{

    public struct CharacterClass
    {
        public enum avaibleClasses
        {
            Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard
        }
        public string classname;
        public int level;
        public string description;
        public int hitDie;
        public List<string> primary_Ability;
        public List<string> SavingTHrowproficiencies;
        public List<string> armorNweaponproficiencies;
        public int baseHitPoints;
        public CharacterClass(avaibleClasses cls)
        {
            switch (cls)
            {
                case avaibleClasses.Barbarian:
                    level = 1;
                    baseHitPoints = 12;
                    classname = "Barbarian";
                    description = "A fierce warrior of primitive background who can enter a battle rage";
                    hitDie = 12;
                    primary_Ability = new List<string>() { "Strength" };
                    SavingTHrowproficiencies = new List<string>() { "Strength", " Constitution" };
                    armorNweaponproficiencies = new List<string>() { "Light armor" +
                        "medium armor" +
                        "shields" +
                        "simple weapons" +
                        "martial weapons"};
                    break;
                case avaibleClasses.Bard:
                    level = 1;
                    baseHitPoints = 8;
                    classname = "Bard";
                    description = "An inspiring magician whose power echoes the music of creation";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Dexterity", " Charisma" };
                    armorNweaponproficiencies = new List<string>() { "Light armor" +
                        "simple weapons" +
                        "hand crossbows" +
                        "longswords" +
                        "rapiers" +
                        "shortswords"};
                    break;
                case avaibleClasses.Cleric:
                    level = 1;
                    baseHitPoints = 8;
                    classname = "Cleric";
                    description = "A priestly champion who wields divine magic in service of a higher power";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Wisdom" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Charisma" };
                    armorNweaponproficiencies = new List<string>() { "Light armor" +
                        "medium armor" +
                        "shields" +
                        "simple weapons"};
                    break;
                case avaibleClasses.Druid:
                    level = 1;
                    classname = "Druid";
                    baseHitPoints = 8;
                    description = "A priest of the Old Faith, wielding the powers of nature— moonlight and plant growth, fire and lightning— and adopting animal forms";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Wisdom" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Inteligence" };
                    armorNweaponproficiencies = new List<string>() { "Light armor(nonmetal)" +
                        "Medium Armor(nonmetal" +
                        "Shields(nonmetal)" +
                        "clubs" +
                        "daggers" +
                        "darts" +
                        "javelins" +
                        "maces" +
                        "quarterstaffs" +
                        "scimitars" +
                        "sickles" +
                        "slings" +
                        "spears"};
                    break;
                case avaibleClasses.Fighter:
                    level = 1;
                    classname = "Fighter";
                    baseHitPoints = 10;
                    description = "A master of martial combat, skilled with a variety of weapons and armor";
                    hitDie = 10;
                    primary_Ability = new List<string>() { "Strenght", "Dexterity" };
                    SavingTHrowproficiencies = new List<string>() { "Strength", "Constitution" };
                    armorNweaponproficiencies = new List<string>() { "All Armor" +
                        "all shields" +
                        "simple weapons" +
                        "martial weapons"};
                    break;
                case avaibleClasses.Monk:
                    level = 1;
                    baseHitPoints = 8;
                    classname = "Monk";
                    description = "An master of martial arts, harnessing the power of the body in pursuit of physical and spiritual perfection";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Dexterity", " Wisdom" };
                    SavingTHrowproficiencies = new List<string>() { "Strength", "Dexterity" };
                    armorNweaponproficiencies = new List<string>() { "Simple weapons" +
                        "shortswords"};
                    break;
                case avaibleClasses.Paladin:
                    level = 1;
                    baseHitPoints = 10;
                    classname = "Paladin";
                    description = "A holy warrior bound to a sacred oath";
                    hitDie = 10;
                    primary_Ability = new List<string>() { "Strength", " Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Charisma" };
                    armorNweaponproficiencies = new List<string>() { "all armor" +
                        "shields" +
                        "simple weapons" +
                        "martial weapons"};
                    break;
                case avaibleClasses.Ranger:
                    level = 1;
                    baseHitPoints = 10;
                    classname = "Ranger";
                    description = "A scoundrel who uses stealth and trickery to overcome obstacles and enemies";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Dexterity" };
                    SavingTHrowproficiencies = new List<string>() { "Strength", "Dexterity" };
                    armorNweaponproficiencies = new List<string>() { "Light armor" +
                        "medium armor" +
                        "Shields" +
                        "Simple weapons" +
                        "Martial Weapons"};
                    break;
                case avaibleClasses.Rogue:
                    level = 1;
                    baseHitPoints = 8;
                    classname = "Rogue";
                    description = "A scoundrel who uses stealth and trickery to overcome obstacles and enemies";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Dexterity" };
                    SavingTHrowproficiencies = new List<string>() { "Dexterity", "Inteligence" };
                    armorNweaponproficiencies = new List<string>() { "Light armor" +
                        "simple weapons" +
                        "hand crossbows" +
                        "longswords" +
                        "rapiers" +
                        "shortswords"};
                    break;
                case avaibleClasses.Sorcerer:
                    level = 1;
                    classname = "Sorcerer";
                    description = "A spellcaster who draws on inherent magic from a gift or bloodline";
                    hitDie = 6;
                    baseHitPoints = 6;
                    primary_Ability = new List<string>() { "Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Constitution", "Charisma" };
                    armorNweaponproficiencies = new List<string>() { "daggers" +
                        "darts" +
                        "slings" +
                        "quarterstaffs" +
                        "light crossbows"};
                    break;
                case avaibleClasses.Warlock:
                    level = 1;
                    classname = "Warlock";
                    baseHitPoints = 8;
                    description = "A wielder of magic that is derived from a bargain with an extraplanar entity";
                    hitDie = 8;
                    primary_Ability = new List<string>() { "Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Charisma" };
                    armorNweaponproficiencies = new List<string>() { "light armor" +
                        "simple weapons"};
                    break;
                case avaibleClasses.Wizard:
                    level = 1;
                    classname = "Wizard";
                    baseHitPoints = 6;
                    description = "A scholarly magic-user capable of manipulating the structures of reality";
                    hitDie = 6;
                    primary_Ability = new List<string>() { "Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Inteligence" };
                    armorNweaponproficiencies = new List<string>() { "daggers" +
                        "darts" +
                        "slings" +
                        "quarterstaffs" +
                        "light crossbows"};
                    break;
                default:
                    level = 999;
                    classname = "Destroyer of worlds";
                    description = "Most powerfullbeing";
                    baseHitPoints = 666;
                    hitDie = 999;
                    primary_Ability = new List<string>() { "Charisma" };
                    SavingTHrowproficiencies = new List<string>() { "Wisdom", "Charisma" };
                    armorNweaponproficiencies = new List<string>() { "light armor" +
                        "simple weapons"};
                    break;
            }
        }

    }
}
