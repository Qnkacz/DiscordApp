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

namespace DiscordApp.Commands
{
    class komendy : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " nie budź mnie").ConfigureAwait(false);
        }
        [Command("respondmessage")]
        public async Task RespondMessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Content);
        }

        [Command("respondreaction")]
        public async Task RespondReaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Emoji);
        }
        [Command("dialogue")]
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
        public async Task Roll(CommandContext ctx, int value)
        {
            Random r = new Random();
            int val = r.Next(0, value);
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }
        [Command("rollMod")]
        public async Task Roll(CommandContext ctx, int value, int mod)
        {
            Random r = new Random();
            int val = r.Next(0, value) + mod;
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }
        [Command("open")]
        public async Task CreateChannel(CommandContext ctx, DiscordRole role, params string[] names)
        {
            string name = string.Join(" ", names);
            var blep = ctx.Guild.Channels;
            bool hasRpgCategory = false;
            foreach (var item in blep)
            {
                if (item.Value.Name.Contains("RPG"))
                {
                    hasRpgCategory = true;
                    var createdChannel = await ctx.Guild.CreateTextChannelAsync(name, item.Value, role.Name.Trim().ToLower());
                    await createdChannel.AddOverwriteAsync(ctx.Member, Permissions.All);
                    await createdChannel.SendMessageAsync("Tutaj możecie grac w " + role.Name.ToString() + ", sesja załozona przez: " + ctx.Member.Mention + " zapraszamy " + role.Mention + " na granko");
                    break;
                }
            }
            if (hasRpgCategory == false)
            {
                var category = await ctx.Guild.CreateChannelCategoryAsync("RPG");
                var createdChannel = await ctx.Guild.CreateTextChannelAsync(name, category, role.Name.Trim().ToLower());
                await createdChannel.AddOverwriteAsync(ctx.Member, Permissions.All);
                await createdChannel.SendMessageAsync("Tutaj możecie grac w " + role.Name.ToString() + ", sesja załozona przez: " + ctx.Member.Mention + " zapraszamy " + role.Mention + " na granko");
            }
        }
        [Command("stop")]
        public async Task DeleteChannel(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Children.Count() == 0)
            {
                await ctx.Channel.Parent.DeleteAsync();
            }
            await ctx.Channel.DeleteAsync();
        }
        [Command("StopLog")]
        public async Task DeleteChannelLog(CommandContext ctx)
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
        [Command("log")]
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
        public async Task Kick(CommandContext ctx, DiscordMember user)
        {
            await ctx.Channel.AddOverwriteAsync(user, Permissions.None, Permissions.All);
        }
        [Command("Cutie")]
        public async Task Ola(CommandContext ctx)
        {
            var members = ctx.Guild.Members;
            var role = ctx.Guild.GetRole(448516688779018240);
            foreach (var item in members)
            {
                if (item.Value.Roles.Contains(role))
                {
                    await ctx.Channel.SendMessageAsync(item.Value.Mention + " is a cutie");
                }
            }
        }
    }
}
