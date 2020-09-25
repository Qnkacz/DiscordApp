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
using System.Runtime.InteropServices.ComTypes;
using DSharpPlus;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace DiscordApp.Commands
{
    class komendy : BaseCommandModule
    {

        public async Task Ping(CommandContext ctx)
        {
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " nie budź mnie").ConfigureAwait(false);
        }

        public async Task RespondMessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Content);
        }


        public async Task RespondReaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Emoji);
        }

        public async Task Dialogue(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var Up = DiscordEmoji.FromName(ctx.Client, ":+1:");
            var inputStep = new StringStep("Dialog", "Zareaguj" + DiscordEmoji.FromName(ctx.Client, ":+1:") + "dla warhammera", null);

            var userChannel = await ctx.Member.CreateDmChannelAsync();
            string input = string.Empty;
            do
            {
                inputStep.OnValidResult += (result) => input = result;
                var inputDialogueHandler = new DialogueHandler(
                    ctx.Client,
                    userChannel,
                    ctx.User,
                    inputStep
                    );

                bool succeeded = await inputDialogueHandler.ProcessDialogue();
                if (!succeeded)
                {
                    return;
                }
                if (input != "raczydlo")
                    await ctx.Channel.SendMessageAsync(input); // kopiowanie z dm do kanału tutaj trzeba pracowac z JSON później, nie jest to w petli wiec tylko wysle raz
            } while (input != "raczydlo");

        }

        [Command("roll")]
        [Description("rolls a die of certain size")]
        public async Task Roll(CommandContext ctx, [Description("Die size")] int value)
        {
            Random r = new Random();
            int val = r.Next(0, value);
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }

        [Command("rollMod")]
        [Description("roll a die of a certain size and gives a modificator")]
        public async Task Roll(CommandContext ctx, [Description("Die size")] int value, [Description("modyfikator")] int mod)
        {
            Random r = new Random();
            int val = r.Next(0, value) + mod;
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }

        [Command("open")]
        [RequireRoles(RoleCheckMode.Any, "RPG - GM")]
        [Description("GM ONLY! Creates a chatroom for an rpg system")]
        public async Task CreateChannel(CommandContext ctx, [Description("channel name")] params string[] names)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string name = string.Join(" ", names);
                var blep = ctx.Guild.Channels;
                bool hasRpgCategory = false;
                string topic = string.Empty;
                await ctx.Channel.SendMessageAsync(ctx.Prefix);
                switch (ctx.Prefix.ToLower())
                {
                    case "wh":
                        topic = "warhammer";
                        break;
                    case "dnd":
                        topic = "DnD";
                        break;
                    case ">>":
                        await ctx.Channel.SendMessageAsync("use the designated command prefix");
                        return;
                }
                foreach (var item in blep)
                {
                    if (item.Value.Name.Contains("RPG"))
                    {
                        hasRpgCategory = true;
                        var createdChannel = await ctx.Guild.CreateTextChannelAsync(name, item.Value, topic);
                        await createdChannel.AddOverwriteAsync(ctx.Member, Permissions.All);
                        await createdChannel.SendMessageAsync("Tutaj możecie grac w " + topic + ", sesja załozona przez: " + ctx.Member.Mention + " zapraszamy na granko");

                        break;
                    }
                }
                if (hasRpgCategory == false)
                {
                    var category = await ctx.Guild.CreateChannelCategoryAsync("RPG");
                    var createdChannel = await ctx.Guild.CreateTextChannelAsync(name, category, topic);
                    await createdChannel.AddOverwriteAsync(ctx.Member, Permissions.All);
                    await createdChannel.SendMessageAsync("Tutaj możecie grac w " + topic + ", sesja załozona przez: " + ctx.Member.Mention + " zapraszamy na granko");
                }
            }
            else
            {
                await ctx.Channel.DeleteMessageAsync(ctx.Message);
            }
        }

        [Command("stop")]
        [RequireRoles(RoleCheckMode.Any, "RPG - GM")]
        [Description("GM ONLY! Deletes an rpg text channel")]
        public async Task DeleteChannel(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg" && ctx.Channel.Topic.ToLower()!="hub")
            {
                if (ctx.Channel.Parent.Children.Count() == 0)
                {
                    await ctx.Channel.Parent.DeleteAsync();
                }
                await ctx.Channel.DeleteAsync();
            }
            else
            {
                await ctx.Channel.DeleteMessageAsync(ctx.Message);
            }
        }

        [Command("StopLog")]
        [RequireRoles(RoleCheckMode.Any, "RPG - GM")]
        [Description("GM ONLY! Deletes an rpg text channel and PMs a log file")]
        public async Task DeleteChannelLog(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg" && ctx.Channel.Topic.ToLower() != "hub")
            {
                var logs = await ctx.Channel.GetMessagesAsync(999999);
                string txt = string.Empty;
                using (StreamWriter sw = File.CreateText(ctx.Channel.Name + ".txt"))
                {
                    foreach (var item in logs)
                    {
                        await sw.WriteLineAsync(item.Author.Username + " >> " + item.Content);
                    }
                }
                var privateMsg = await ctx.Member.CreateDmChannelAsync();
                await privateMsg.SendFileAsync(ctx.Channel.Name + ".txt");
                File.Delete(ctx.Channel.Name + ".txt");
                if (ctx.Channel.Parent.Children.Count() == 0)
                {
                    await ctx.Channel.Parent.DeleteAsync();
                }
                await ctx.Channel.DeleteAsync();
            }
            else
            {
                await ctx.Channel.DeleteMessageAsync(ctx.Message);
            }

        }

        [Command("log")]
        [Description("PMs log file for a channel ")]
        public async Task LogChannel(CommandContext ctx)
        {
            var logs = await ctx.Channel.GetMessagesAsync(999999);
            string txt = string.Empty;
            using (StreamWriter sw = File.CreateText(ctx.Channel.Name + ".txt"))
            {
                foreach (var item in logs)
                {
                    await sw.WriteLineAsync(item.Author.Username + " >> " + item.Content);
                }
            }
            var privateMsg = await ctx.Member.CreateDmChannelAsync();
            await privateMsg.SendFileAsync(ctx.Channel.Name + ".txt");
            File.Delete(ctx.Channel.Name + ".txt");
            await ctx.Message.DeleteAsync();
        }

        [Command("Kick")]
        [Description("GM ONLY! Kicks player from an rpg text channel")]
        [RequireRoles(RoleCheckMode.Any, "RPG - GM")]
        public async Task Kick(CommandContext ctx, [Description("@mention the player")] DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg" && ctx.Channel.Topic.ToLower() != "hub")
            {
                await ctx.Channel.AddOverwriteAsync(user, Permissions.None, Permissions.All);
            }

        }
        [Command("README")]
        [Description("A better help PM")]
        public async Task help(CommandContext ctx)
        {
            var userchannel = await ctx.Member.CreateDmChannelAsync();

            string desc = File.ReadAllText("README_part1.txt");
            string desc1 = File.ReadAllText("README_part2.txt");
            string desc2 = File.ReadAllText("README_part3.txt");
            var emb = new DiscordEmbedBuilder
            {
                Title = "H E L P",
                Description = desc
            };
            await userchannel.SendMessageAsync(embed: emb);
            emb.Description = desc1;
            await userchannel.SendMessageAsync(embed: emb);
            emb.Description = desc2;
            await userchannel.SendMessageAsync(embed: emb);
        }
    }
}
