﻿using DiscordApp.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.DnD
{
    public class dnd_infotables
    {
        public List<int> statRollpool = new List<int>();
        public List<int> predetermineRools = new List<int>
        {
            15,14,13,12,10,8
        };
        public List<int> chosenpool;

        public enum Races { human, dwarf, Welf, Helf, halfling, half_elf, hhalf_orc, gnome };
        public enum Classes { barbarian, bard, cleric, druid, fighter, monk, palading, ranger, rouge, warlock, sourcerer, wizard };


        public async Task CreateCharacter(CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
            List<int> customRolls = new List<int>();
            Random random = new Random();
            DnD character = new DnD();
            var QuestionEmbed = new DiscordEmbedBuilder
            {
                Title = "Welcome to the DnD Character creation menu",
                Description = "What is your name?"
            };

            var msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            var response = await userChannel.GetNextMessageAsync();
            character.name = response.Result.Content;
            QuestionEmbed.Title = "What is your race, react acordingly";
            QuestionEmbed.Description = emojis.human + "- for `human`" + System.Environment.NewLine +
                emojis.elf + "- for `Woodelf`" + System.Environment.NewLine +
                emojis.Helf + "- for `HighElf`" + System.Environment.NewLine +
                emojis.half_elf + "- for `half-elf`" + System.Environment.NewLine +
                emojis.krasnoludy + "- for `Dwarf`" + System.Environment.NewLine +
                emojis.gnome + "- for `Gnome`" + System.Environment.NewLine +
                emojis.half_orc + "- for `Half-Orc`" + System.Environment.NewLine +
                emojis.niziolki + "- for `Halfling`" + System.Environment.NewLine;
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            foreach (var item in emojis.DnDRaceEmojiArr)
            {
                await msg.CreateReactionAsync(item);
            }
            Thread.Sleep(150);
            var interactivity = ctx.Client.GetInteractivity();
            var emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (emojis.DnDRaceEmojiArr.Contains(x.Emoji)));
            Thread.Sleep(150);
            #region racePicker
            if (emojiResult.Result.Emoji == emojis.human)
            {
                character.race = "human";
            }
            if (emojiResult.Result.Emoji == emojis.elf)
            {
                character.race = "wood Elf";
            }
            if (emojiResult.Result.Emoji == emojis.Helf)
            {
                character.race = "high elf";
            }
            if (emojiResult.Result.Emoji == emojis.half_elf)
            {
                character.race = "half elf";
            }
            if (emojiResult.Result.Emoji == emojis.krasnoludy)
            {
                character.race = "dwarf";
            }
            if (emojiResult.Result.Emoji == emojis.gnome)
            {
                character.race = "gnome";
            }
            if (emojiResult.Result.Emoji == emojis.half_orc)
            {
                character.race = "half orc";
            }
            if (emojiResult.Result.Emoji == emojis.niziolki)
            {
                character.race = "halfling";
            }
            #endregion
            QuestionEmbed.Title = emojis.yes + " - You roll your stats" + emojis.no + "- use the premade one?";
            QuestionEmbed.Description = "react acordingly";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            await msg.CreateReactionAsync(emojis.yes);
            await msg.CreateReactionAsync(emojis.no);
            Thread.Sleep(150);
            emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (x.Emoji == emojis.yes || x.Emoji == emojis.no));
            if (emojiResult.Result.Emoji == emojis.yes)
            {
                int numbah = -1;
                for (int i = 0; i <= 5; i++)
                {
                    numbah = getDndStatRolls();
                    customRolls.Add(numbah);
                }
                chosenpool = customRolls;
            }
            if (emojiResult.Result.Emoji == emojis.no)
            {
                chosenpool = predetermineRools;
            }
            QuestionEmbed.Title = "Here are your rolls";
            QuestionEmbed.Description = string.Join(" `:` ", chosenpool);
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            string[] statTitles = new string[]
            {
                "What will be your `Strenght`",
                "What will be your `Desxterity`",
                "What will be your `Constitution`",
                "What will be your `Inteligence`",
                "What will be your `Wisdom`",
                "What will be your `Charizma`"
            };
            int[] liczby = new int[6];
            string WszystkieCechyString = string.Empty;
            for (int i = 0; i <= 5; i++) //przydzielanie liczb to statystyk
            {
                WszystkieCechyString = string.Join("` : `", chosenpool);
                QuestionEmbed.Title = statTitles[i];
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < chosenpool.Count; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    liczby[i] = chosenpool[0];
                    chosenpool.RemoveAt(0);
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    liczby[i] = chosenpool[1];
                    chosenpool.RemoveAt(1);
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    liczby[i] = chosenpool[2];
                    chosenpool.RemoveAt(2);
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    liczby[i] = chosenpool[3];
                    chosenpool.RemoveAt(3);
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    liczby[i] = chosenpool[4];
                    chosenpool.RemoveAt(4);
                }
                if (emojiResult.Result.Emoji == emojis.six)
                {
                    liczby[i] = chosenpool[5];
                    chosenpool.RemoveAt(5);
                }
                await userChannel.DeleteMessageAsync(msg);
            }
            character.strength = liczby[0];
            character.dexterity = liczby[1];
            character.constitution = liczby[2];
            character.intelligence = liczby[3];
            character.wisdom = liczby[4];
            character.charisma = liczby[5];
            if (character.race == "wood elf" || character.race == "high elf")
            {
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Accustom ed to twilit forests and the night sky, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if itw ere bright light, and in darkness as if it were dim light.You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Keen Senses.", "You have proficiency in the Perception skill."));
                character.Traits.Add(new DnDTrait("Fey Encestry", "You have advantage on saving throws against being charm ed, and m agic can’t put you to sleep."));
                character.Traits.Add(new DnDTrait("Trance", "Elves don’t need to sleep. Instead, they meditate deeply, remaining sem iconscious, for 4 hours a day. (The Com m on w ord for such meditation is “trance.”) W hile meditating, you can dream after a fashion; such dream s are actually mental exercises that have becom e reflexive through years of practice. After resting in this way, you gain the sam e benefit that a human does from 8 hours of sleep."));
                character.Traits.Add(new DnDTrait("Leanguage", "elfish"));
                character.Traits.Add(new DnDTrait("Elf Weapon Training.", "You have proficiency with the longsword, shortsword, shortbow, and longbow."));
            }
            if (character.race == "high elf")
            {

                character.intelligence += 1;
                QuestionEmbed.Title = "Cantrip";
                QuestionEmbed.Title = "Write one cantrip of your choice from wizard spell list";
                await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                var spellname = response.Result.Content;
                QuestionEmbed.Title = spellname;
                QuestionEmbed.Description = "write the spell description";
                response = await userChannel.GetNextMessageAsync();
                var spellDescr = response.Result.Content;
                DnDSpells spell = new DnDSpells();
                spell.spellName = spellname;
                spell.description = spellDescr;
                character.spells.Add(spell);
            }
            if (character.race == "wood elf")
            {
                character.wisdom += 1;
                character.speed = 35;
                character.Traits.Add(new DnDTrait("Mask of the wild", "You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, falling snow, mist, and other natural phenomena."));
            }
            if (character.race == "halfling")
            {
                character.dexterity += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Lucky", "W hen you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll."));
                character.Traits.Add(new DnDTrait("Brave", "You have advantage on saving throws against being frightened."));
                character.Traits.Add(new DnDTrait("Halfling Nimbleness.", "You can move through the space of any creature that is of a size larger than yours."));
                character.Traits.Add(new DnDTrait("leanguage", "halfling"));
                QuestionEmbed.Title = "Are you a lightfoot or a stout?";
                QuestionEmbed.Description = emojis.yes + "- for lightfoot" + System.Environment.NewLine + emojis.no + " - for stout";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await msg.CreateReactionAsync(emojis.yes); await msg.CreateReactionAsync(emojis.no);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                if (emojiResult.Result.Emoji == emojis.yes)
                {
                    character.charisma += 1;
                    character.Traits.Add(new DnDTrait("Naturally Stealthy", "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you."));
                    character.race += "- L i g h t f o o t";
                }
                if (emojiResult.Result.Emoji == emojis.no)
                {
                    character.constitution += 1;
                    character.Traits.Add(new DnDTrait("Stout Resilience", "You have advantage on saving throws against poison, and you have resistance against poison damage."));
                    character.race += "- S t o u t";
                }
            }
            if (character.race == "human")
            {
                character.strength += 1;
                character.dexterity += 1;
                character.constitution += 1;
                character.intelligence += 1;
                character.wisdom += 1;
                character.charisma += 1;
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Leanguage: ", "human"));
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add(new DnDTrait("Leanguage: ", response.Result.Content));
            }
            if (character.race == "gnome")
            {
                character.intelligence += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Darkvision", "Accustom ed to life underground, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Gnome Cunning", "You have advantage on all Intelligence, W isdom, and Charisma saving throws against magic."));
                character.Traits.Add(new DnDTrait("Leanguage: ", "Gnomish"));

                QuestionEmbed.Title = "Are you a Forest or a Rock gnome?";
                QuestionEmbed.Description = emojis.yes + "- for Forest" + System.Environment.NewLine + emojis.no + " - for Rtout";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await msg.CreateReactionAsync(emojis.yes); await msg.CreateReactionAsync(emojis.no);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                if (emojiResult.Result.Emoji == emojis.yes)
                {
                    character.dexterity += 1;
                    character.Traits.Add(new DnDTrait("Natural ilusionist", "You know the minor illusion cantrip.Intelligence is your spellcasting ability for it."));
                    character.Traits.Add(new DnDTrait(" Speak with Small Beasts", "Through sounds and gestures, you can com m unicate simple ideas with Small or sm aller beasts.Forest gnom es love animals and often keep squirrels, badgers, rabbits, m oles, w oodpeckers, and other creatures as beloved pets."));
                    character.race += "- F o r e s t";
                }
                if (emojiResult.Result.Emoji == emojis.no)
                {
                    character.constitution += 1;
                    character.Traits.Add(new DnDTrait("Artificer’s Lore", "W henever you make an Intelligence (History) check related to m agic items, alchemical objects, or technological devices, you can add tw ice your proficiency bonus, instead of any proficiency bonus you normally apply."));
                    character.Traits.Add(new DnDTrait("Tinker", "You have proficiency with artisan’s tools (tinker’s tools).Using those tools, you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockw ork device(AC 5, 1 hp).The device ceases to function after 24 hours(unless you spend 1 hour repairing it to keep the device functioning), or when you use your action to dismantle it; at that time, you can reclaim the materials used to create it.You can have up to three such devices active at a time."));
                    character.race += "- R o c k";
                }
            }
            if (character.race == "half elf")
            {
                character.charisma += 2;
                WszystkieCechyString = string.Join("`:`", statTitles);



                QuestionEmbed.Title = QuestionEmbed.Title = "Choose 1st of two of your stats that you want to increase by 1"; ;
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < 6; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.strength += 1;
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.dexterity += 1;
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.constitution += 1;
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    character.intelligence += 1;
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    character.wisdom += 1;
                }
                if (emojiResult.Result.Emoji == emojis.six)
                {
                    character.charisma += 1;
                }
                await userChannel.DeleteMessageAsync(msg);

                QuestionEmbed.Title = QuestionEmbed.Title = "Choose 2nd of two of your stats that you want to increase by 1"; ;
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < 5; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.strength += 1;
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.dexterity += 1;
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.constitution += 1;
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    character.intelligence += 1;
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    character.wisdom += 1;
                }
                await userChannel.DeleteMessageAsync(msg);
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Thanks to your elf blood, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it were dim light.You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Fey Ancestry", "You have advantage on saving throws against being charm ed, and m agic can’t put you to sleep."));
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add(new DnDTrait("Leanguage: ", response.Result.Content));
            }
            if (character.race == "half orc")
            {
                character.strength = +2;
                character.constitution += 1;
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Thanks to your orc blood, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it w ere dim light. You can't discern color in darkness, only shades o f gray."));
                character.Traits.Add(new DnDTrait("Menacing", "You gain proficiency in the Intimidation skill."));
                character.Traits.Add(new DnDTrait("Relentless Endurance", "W hen you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead.You can’t use this feature again until you finish a long rest."));
                character.Traits.Add(new DnDTrait("Savage Attacks", "W hen you score a critical hit with a melee weapon attack, you can roll one of the w eapon’s damage dice one additional time and add it to the extra damage of the critical hit."));
                character.Traits.Add(new DnDTrait("Leanguage", "Common"));
                character.Traits.Add(new DnDTrait("Leanguage", "Orcish"));
                character.Intimidation += 1;

            }
            if (character.race == "dwarf")
            {
                character.constitution += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Darkvision", "A ccustom ed to life underground, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it w ere dim light. You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Dwarven Resilience", "You have advantage on saving throws against poison, and you have resistance against poison damage"));
                character.Traits.Add(new DnDTrait("Dwarven Combat Training", "You have proficiency with the battleaxe, handaxe, throwing hammer, and warhammer."));
                QuestionEmbed.Title = "Choose tool proficiency"; ;
                QuestionEmbed.Description = emojis.one + " - for Smith's tools" + System.Environment.NewLine +
                    emojis.two + " - for brewers supplies" + System.Environment.NewLine +
                    emojis.three + " - for Mason's tools";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j <= 2; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency:", " Smith's tools"));
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency", " brewers supplies"));
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency", " Mason's tools"));
                }
                QuestionEmbed.Title = "Choose Your subrace"; ;
                QuestionEmbed.Description = emojis.yes + " - for Hill Darf" + System.Environment.NewLine + emojis.no + " - for Mountain Dwarf";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await msg.CreateReactionAsync(emojis.yes);
                await msg.CreateReactionAsync(emojis.no);
                Thread.Sleep(100);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojiResult.Result.Emoji == emojis.yes || emojiResult.Result.Emoji == emojis.no));
                if (emojiResult.Result.Emoji == emojis.yes)
                {
                    character.wisdom += 1;
                    character.Traits.Add(new DnDTrait("Dwarven Toughness", "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level."));
                }
                if (emojiResult.Result.Emoji == emojis.no)
                {
                    character.strength += 2;
                    character.Traits.Add(new DnDTrait("Dwarven Armor Training", "You have proficiency with light and medium armor."));
                }
            }
            QuestionEmbed.Title = "How tall are you";
            QuestionEmbed.Description = "`lore friendly` propositions:" + System.Environment.NewLine +
                "`dwarf` -> 120 - 152 cm" + System.Environment.NewLine +
                "`elf` -> 152 - 190 cm" + System.Environment.NewLine +
                "`halfling` -> around 90 cm" + System.Environment.NewLine +
                "`human` -> 150 - 200 cm" + System.Environment.NewLine +
                "`gnome` -> 90 - 120 cm" + System.Environment.NewLine +
                "`half-elf` -> 150 - 200 cm" + System.Environment.NewLine +
                "`half-orc` -> 160 - 200+ cm" + System.Environment.NewLine +
                "** Write only the number below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            character.height = Int32.Parse(response.Result.Content);
            Thread.Sleep(110);
            QuestionEmbed.Title = "How old are you";
            QuestionEmbed.Description = "`lore friendly` propositions:" + System.Environment.NewLine +
                "`dwarf` -> 5 - 350 Years" + System.Environment.NewLine +
                "`elf` -> 5 - 750 Years" + System.Environment.NewLine +
                "`halfling` -> 5 - 65 years" + System.Environment.NewLine +
                "`human` -> 5 - 80 Years" + System.Environment.NewLine +
                "`gnome` -> 5 - 500 Years" + System.Environment.NewLine +
                "`half-elf` -> 5 - 200 Years" + System.Environment.NewLine +
                "`half-orc` -> 5 - 75 Years" + System.Environment.NewLine +
                "** Write only the number below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(110);

            QuestionEmbed.Title = "What is your Aligment?";
            QuestionEmbed.Description = "Lawful good |.| Neutral Good |.| Chaotic Good" + System.Environment.NewLine +
             "Lawful Neutral |.| True Neutral |.| Chaotic Neutral" + System.Environment.NewLine +
             "Lawful evil |.|  Neutral evil |.| Chaotic evil";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            for (int i = 0; i < 6; i++)
            {
                await msg.CreateReactionAsync(emojis.onetototen[i]);
            }
            emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (emojis.onetototen.Contains(x.Emoji)));
            if (emojiResult.Result.Emoji == emojis.one)
            {
                character.aligment = "Lawful good";
            }
            if (emojiResult.Result.Emoji == emojis.two)
            {
                character.aligment = "Neutral Good";
            }
            if (emojiResult.Result.Emoji == emojis.three)
            {
                character.aligment = "Chaotic Good";
            }
            if (emojiResult.Result.Emoji == emojis.four)
            {
                character.aligment = "Lawful Neutral";
            }
            if (emojiResult.Result.Emoji == emojis.five)
            {
                character.aligment = "True Neutral";
            }
            if (emojiResult.Result.Emoji == emojis.six)
            {
                character.aligment = "Chaotic Neutral";
            } 
            if (emojiResult.Result.Emoji == emojis.seven)
            {
                character.aligment = "Lawful evi";
            } 
            if (emojiResult.Result.Emoji == emojis.eight)
            {
                character.aligment = "Neutral Evil";
            }
            if (emojiResult.Result.Emoji == emojis.nine)
            {
                character.aligment = "Chaotic evil";
            }
            await userChannel.SendMessageAsync("You chose: **" + character.aligment + "**");

        }

        public int getDndStatRolls()
        {
            Random r = new Random();
            int output = 0;
            List<int> threes = new List<int>();
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Sort();
            threes.RemoveAt(0);
            foreach (var item in threes)
            {
                output += item;
            }
            return output;
        }
    }
}
