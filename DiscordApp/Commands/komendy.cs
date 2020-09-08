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
        [Description("rzuca kostką o danej wielkosci")]
        public async Task Roll(CommandContext ctx, [Description("Wielkość kosci")] int value)
        {
            Random r = new Random();
            int val = r.Next(0, value);
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }
        
        [Command("rollMod")]
        [Description("rzuca kostką o danej wielkosci i modyfikowatorem")]
        public async Task Roll(CommandContext ctx, [Description("Wielkość kosci")] int value, [Description("modyfikator")] int mod)
        {
            Random r = new Random();
            int val = r.Next(0, value) + mod;
            var chuj = ctx.Member.Mention;
            await ctx.Channel.SendMessageAsync(chuj + " " + val.ToString());
        }
        
        [Command("open")]
        [RequireRoles(RoleCheckMode.Any,"GM")]
        [Description("Otwiera pokój gier dla danego systemu rpg na podstawie podanej roli")]
        public async Task CreateChannel(CommandContext ctx, [Description("Dla jakiego systemu jest rpg")] DiscordRole role, [Description("nazwa kanału")] params string[] names)
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
        [RequireRoles(RoleCheckMode.Any, "GM")]
        [Description("Zamyka pokój gier")]
        public async Task DeleteChannel(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Children.Count() == 0)
            {
                await ctx.Channel.Parent.DeleteAsync();
            }
            await ctx.Channel.DeleteAsync();
        }
        
        [Command("StopLog")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        [Description("Zamyka pokój gier i wysyła logi na priva")]
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
        [Description("Wysyła logi")]
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
        [Description("kickuje gracza z kanału")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task Kick(CommandContext ctx, [Description("kickowany użytkownik")] DiscordMember user)
        {
            await ctx.Channel.AddOverwriteAsync(user, Permissions.None, Permissions.All);
        }
    }
}
