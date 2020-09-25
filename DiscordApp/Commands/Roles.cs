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

        [Command("rpg")]
        [Description("Give you the role that let's you play RPG games with the bot")]
        public async Task rls(CommandContext ctx)
        {
            var roles = ctx.Guild.Roles.ToList();
            foreach (var item in roles)
            {
                if (item.Value.Name == "RPG - Player")
                {
                    await ctx.Member.GrantRoleAsync(item.Value);
                    break;
                }
            }
            await ctx.Member.CreateDmChannelAsync().Result.SendMessageAsync("hello, you can now use the bot on: `" + ctx.Guild.Name + Environment.NewLine + "` if you feel lost use the `>>readme` command for more help");
        }
        [Command("GM")]
        [RequireRoles(RoleCheckMode.Any, "RPG - GM")]
        [Description("GM ONLY! - grants the GM role to the mentioned user")]
        public async Task GM(CommandContext ctx, DiscordMember user)
        {
            var roles = ctx.Guild.Roles.ToList();
            foreach (var item in roles)
            {
                if (item.Value.Name == "RPG - GM")
                {
                    await user.GrantRoleAsync(item.Value);
                    break;
                }
            }
            await ctx.Channel.SendMessageAsync("Yaaaay, `" + user.DisplayName + "` is now a Game master!" + Environment.NewLine + "༼ つ ◕_◕ ༽つ༼ つ ◕_◕ ༽つ༼ つ ◕_◕ ༽つ");
            await user.CreateDmChannelAsync().Result.SendMessageAsync("I know that you'll be a good GM, dont be afraid!" + Environment.NewLine + "If you need help, just type `>>readme` for more details aboput the bot, or just ask some friends");
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
        [Command("avatar")]
        public async Task qwdoinw(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.SendMessageAsync(member.AvatarUrl);
        }
        [Command("setup")]
        public async Task setup(CommandContext ctx)
        {
            if (ctx.Member == ctx.Guild.Owner)
            {
                await ctx.Guild.CreateRoleAsync("RPG - Player", null, DiscordColor.SpringGreen);
                var gm = await ctx.Guild.CreateRoleAsync("RPG - GM", null, DiscordColor.MidnightBlue);
                var questionEmbed = new DiscordEmbedBuilder
                {
                    Title = "Hello " + ctx.Member.DisplayName + " to the RPG bot Experience!",
                    Description = "This bot was crafted with love, but I aknowledge that this is not yet a finished product," +
                   "the bot is **very** complicated at first glance but I assure you that after a while it will just click" +
                   "The bot will be updated very frequently and there is a probability that characters made now will not work in the future" +
                   "if that occurs i will send a message somehow to let you guys know" +
                   "IF you have any question then please go to the discord channel listed below, I'll try to answer them for you" +
                   "This bot was made a a fan project by `Bartosz Wąsik`"
                };
                await ctx.Member.CreateDmChannelAsync().Result.SendMessageAsync(embed: questionEmbed);
                await ctx.Member.GrantRoleAsync(gm);
            }
            else
            {
                await ctx.Channel.DeleteMessageAsync(ctx.Message);
            }

        }
    }
}
