using DiscordApp.Handlers;
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
                character.Traits.Add("Keen Senses");
                character.Traits.Add("Fey Encestry");
                character.Traits.Add("Trance");
                character.Traits.Add("Leanguage: elvish");
                character.Traits.Add("Elf weapon Training");
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
                character.Traits.Add("Mask of the wild");
            }
            if (character.race == "halfling")
            {
                character.dexterity += 2;
                character.speed = 25;
                character.Traits.Add("Lucky");
                character.Traits.Add("Brave");
                character.Traits.Add("Halfling Nimbleness.");
                character.Traits.Add("leanguage: halfling");
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
                    character.Traits.Add("Naturally Stealthy");
                    character.race += "- L i g h t f o o t";
                }
                if (emojiResult.Result.Emoji == emojis.no)
                {
                    character.constitution += 1;
                    character.Traits.Add("Stout Resilience");
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
                character.Traits.Add("Leanguage: human");
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add("Leanguage: " + response.Result);
            }
            if (character.race == "gnome")
            {
                character.intelligence += 2;
                character.speed = 25;
                character.Traits.Add("Darkvision");
                character.Traits.Add("Gnome Cunning");
                character.Traits.Add("Leanguage: Gnomish");

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
                    character.Traits.Add("Natural ilusionist");
                    character.Traits.Add(" Speak with Small Beasts");
                    character.race += "- F o r e s t";
                }
                if (emojiResult.Result.Emoji == emojis.no)
                {
                    character.constitution += 1;
                    character.Traits.Add("Artificer’s Lore");
                    character.Traits.Add("Tinker");
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
                character.Traits.Add("Darkvision");
                character.Traits.Add("Fey Ancestry");
                character.Traits.Add("Fey Ancestry");
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add("Leanguage: " + response.Result);
            }
            if (character.race == "half orc")
            {
                character.strength =+ 2;
                character.constitution += 1;
                character.speed = 30;
                character.Traits.Add("Darkvision");
                character.Traits.Add("Menacing");
                character.Traits.Add("Relentless Endurance");
                character.Traits.Add("Savage Attacks");
                character.Traits.Add("Leanguage: Common");
                character.Traits.Add("Leanguage: Orcish");
                character.Intimidation += 1;

            }
            if(character.race=="dwarf")
            {
                character.constitution += 2;
                character.speed = 25;
                character.Traits.Add("Darkvision");
                character.Traits.Add("Dwarven Resilience");
                character.Traits.Add("Dwarven Combat Training");
                character.Traits.Add("Dwarven Combat Training");
                QuestionEmbed.Title = "Choose tool proficiency"; ;
                QuestionEmbed.Description = emojis.one+" - for Smith's tools"+System.Environment.NewLine+
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
                    character.Traits.Add("Tool Proficiency: Smith's tools");
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.Traits.Add("Tool Proficiency: brewers supplies");
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.Traits.Add("Tool Proficiency: Mason's tools");
                }
                QuestionEmbed.Title = "Choose Your subrace"; ;
                QuestionEmbed.Description = emojis.yes + " - for Hill Darf" + System.Environment.NewLine + emojis.no + " - for Mountain Dwarf";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await msg.CreateReactionAsync(emojis.yes);
                await msg.CreateReactionAsync(emojis.no);
                Thread.Sleep(100);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojiResult.Result.Emoji==emojis.yes || emojiResult.Result.Emoji == emojis.no));
                if(emojiResult.Result.Emoji==emojis.yes)
                {
                    character.wisdom += 1;
                    character.Traits.Add("Dwarven Toughness");
                }
                if(emojiResult.Result.Emoji==emojis.no)
                {
                    character.strength += 2;
                    character.Traits.Add("Dwarven Armor Training");
                }
            }

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
