using DiscordApp.Handlers.Dialogue;
using DiscordApp.Handlers.Dialogue.Steps;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Interactivity;
using DSharpPlus.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Threading;
using DiscordApp.RPGSystems;
using System.IO;
using Newtonsoft.Json;
using DiscordApp.RPGSystems.WarhammerFantasy;
using System.Runtime.InteropServices.ComTypes;
using DiscordApp.Handlers;
/// <TODO>
/// 
/// ZAPIS W JSON JEST NA SZTYWNO USTAWIONY MALE
/// </summary>
namespace DiscordApp.Commands
{
    class Roles : BaseCommandModule
    {
        [Command("RPGRoles")]
        public async Task RPGRoles(CommandContext ctx)
        {
            var roleEmbed = new DiscordEmbedBuilder
            {
                Title = "Warcraft Fantasy 2ED",
                Description = "Zareaguj łapke w góre jezeli chcesz grac w Warhammera, łapke w dół jeżeli juz nie grasz i monke jezeli jestem GM",
                Color = DiscordColor.Red

            };
            var warcarfMsg = await ctx.Channel.SendMessageAsync(embed: roleEmbed);
            var Up = DiscordEmoji.FromName(ctx.Client, ":+1:");
            var down = DiscordEmoji.FromName(ctx.Client, ":-1:");
            var GM = DiscordEmoji.FromName(ctx.Client, ":monkey_face:");
            await warcarfMsg.CreateReactionAsync(Up);
            await warcarfMsg.CreateReactionAsync(down);
            await warcarfMsg.CreateReactionAsync(GM);

            var interactivity = ctx.Client.GetInteractivity();
            while (true)
            {
                var result = await interactivity.WaitForReactionAsync(x => x.Message == warcarfMsg && (x.Emoji == Up || x.Emoji == down));
                var role = ctx.Guild.GetRole(748113258107371540);
                var GM_WH = ctx.Guild.GetRole(748164402137530508);
                if (result.Result.Emoji == Up)
                {
                    await ctx.Member.GrantRoleAsync(role);
                }
                if (result.Result.Emoji == down)
                {
                    await ctx.Member.RevokeRoleAsync(role);
                }
                if (result.Result.Emoji == GM)
                {
                    await ctx.Member.GrantRoleAsync(GM_WH);
                }
                Thread.Sleep(1500);
            }

        }
        [Command("Role")]
        public async Task rls(CommandContext ctx, TimeSpan duration, params DiscordEmoji[] EmojiOptions)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var option = EmojiOptions.Select(x => x.ToString());

            var Ember = new DiscordEmbedBuilder
            {
                Title = "W jakiego RPG grasz?",
                Description = string.Join(" ", option)
            };
            var pollMsg = await ctx.Channel.SendMessageAsync(embed: Ember);
            foreach (var item in EmojiOptions)
            {
                await pollMsg.CreateReactionAsync(item);
            }
        }

        [Command("CreateQ")]
        [Description("Create character quick, use wh prefix for warhammer creation")]
        public async Task CreateWarhammerCharacter_quick(CommandContext ctx)
        {
            var userChannel = await ctx.Member.CreateDmChannelAsync();
            var prefix = ctx.Prefix;
            var emojis = new EmojiBase(ctx);
            switch (prefix)
            {
                case "wh":
                   await static_objects.WHF_template.Create(ctx, userChannel, emojis);
                    break;
                case ">>":
                    await userChannel.SendMessageAsync("use prefixes `wh` `dnd` `coc` or `ner` to create characters for that system");
                    break;
            }


        }

        [Command("Create")]
        [Description("Create character, use wh prefix for warhammer creation")]
        public async Task CreateWarhammerCharacter(CommandContext ctx)
        {
            var prefix = ctx.Prefix;
            var userChannel = await ctx.Member.CreateDmChannelAsync();
            var emojis = new EmojiBase(ctx);
            switch (prefix)
            {
                case "wh":
                    await static_objects.WHF_template.SlowCharacter(ctx, userChannel, emojis);
                    break;
                case "dnd":
                        await static_objects.dnd_template.CreateCharacter(ctx, userChannel, emojis);
                    break;
                case ">>":
                    await userChannel.SendMessageAsync("use prefixes `wh` `dnd` `coc` or `ner` to create characters for that system");
                    break;
            }
        }

    }
}
