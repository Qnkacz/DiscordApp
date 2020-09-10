﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.WarhammerFantasy
{
    class WHF_commands : BaseCommandModule
    {
        [Command("DMG")]
        [Description("Deal Damage to mentioned Player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task Heal(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("Damage amount")] int amount)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.dmg(ctx, user, amount);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }

        [Command("Heal")]
        [Description("Heal the player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task heall(CommandContext ctx, [Description("Mention the player")]DiscordMember user, [Description("heal amount")] int amount)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.heal(ctx, user, amount);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }


        }

        [Command("Display")]
        [Description("Displays your character")]
        public async Task ShowChar(CommandContext ctx, [Description("Your character name")] params string[] input)
        {
            WHF_Infotables template = new WHF_Infotables();
            await template.ShowChar(ctx, input);
        }

        [Command("Join")]
        [Description("You're joining this session")]
        public async Task JoinGame(CommandContext ctx, [Description("Your character name")] params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.Join(ctx, input);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }


        }

        [Command("CharList")]
        [Description("Shows the list of characters in the channels RPG system")]
        public async Task CharList(CommandContext ctx)
        {
            WHF_Infotables template = new WHF_Infotables();
            await template.Charlist(ctx);
        }

        [Command("AddItem")]
        [Description("GM ONLY! Gives player an item")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task Additem(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("item amount")] int amount, [Description("item name")]params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.addItem(ctx, user, amount, input);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }
        }

        [Command("Removeitem")]
        [Description("GM ONLY! Romeves player an item")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task RemoveItem(CommandContext ctx, [Description("Mention the player")]DiscordMember user, [Description("item amount")] int amount, [Description("item name")] params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.RemoveItem(ctx, user, amount, input);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }
        }

        [Command("addAbility")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        [Description("GM ONLY! Give player an ability")]
        public async Task AddAbi(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("ability name")]params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        WHF_Infotables template = new WHF_Infotables();
                        await template.addability(ctx, user, input);
                    }
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }

        [Command("removeability")]
        [Description("GM ONLY! Remove ability from player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task RemoveAbi(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("ability name")] params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.removeability(ctx, user, input);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }

        [Command("historyOf")]
        [Description("Show character background story")]
        public async Task ReadFluff(CommandContext ctx, [Description("Mention the player")] DiscordMember user)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.showFluff(ctx, user);

                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }

        [Command("Insanity")]
        [Description(" GM ONLY! Deal insanity Damage to player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task DmgObled(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("damage amount")] int amount)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.insanity(ctx, user, amount);

                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }

        [Command("illness")]
        [Description("Lists the mental disorders of a player")]
        public async Task ListaChorob(CommandContext ctx, [Description("Mention the player")] DiscordMember user)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.Choroby(ctx, user);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                    break;
            }

        }
        [Command("EQ")]
        [Description("gives a list of items in inventory")]
        public async Task Listaitemkw(CommandContext ctx, [Description("mention the player")] DiscordMember user)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.ShowInventory(ctx, user);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("Use the proper rpg prefix");
                    break;
            }

        }
        [Command("abilities")]
        [Description("Gives a list of mentioned players abilities")]
        public async Task Listaumiejek(CommandContext ctx, [Description("mention the player")] DiscordMember user)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    WHF_Infotables template = new WHF_Infotables();
                    await template.ShowAbilities(ctx, user);
                    break;
                case ">>":
                    await ctx.Channel.SendMessageAsync("Use the proper rpg prefix");
                    break;
            }
        }
    }

}

