using DiscordApp.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public enum Races { human, dwarf, Welf, Helf, halfling, half_elf, hhalf_orc, gnome };
        public enum Classes { barbarian, bard, cleric, druid, fighter, monk, palading, ranger, rouge, warlock, sourcerer, wizard };


        public async Task CreateCharacter(CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
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
            if(emojiResult.Result.Emoji==emojis.human)
            {
                character.race = "human";
            }if(emojiResult.Result.Emoji==emojis.elf)
            {
                character.race = "Wood Elf";
            }if(emojiResult.Result.Emoji==emojis.Helf)
            {
                character.race = "high elf";
            }if(emojiResult.Result.Emoji==emojis.half_elf)
            {
                character.race = "half elf";
            }if(emojiResult.Result.Emoji==emojis.krasnoludy)
            {
                character.race = "dwarf";
            }if(emojiResult.Result.Emoji==emojis.gnome)
            {
                character.race = "gnome";
            }if(emojiResult.Result.Emoji==emojis.half_orc)
            {
                character.race = "half orc";
            }if(emojiResult.Result.Emoji==emojis.niziolki)
            {
                character.race = "halfling";
            }
            #endregion

        }



    }
}
