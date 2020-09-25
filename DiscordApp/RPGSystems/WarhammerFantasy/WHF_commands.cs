using DiscordApp.Handlers;
using DSharpPlus.CommandsNext;
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
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.dmg(ctx, user, amount);
                    break;
                case "dnd":
                    await static_objects.dnd_template.dmg(ctx, user, amount);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }

        }

        [Command("Heal")]
        [Description("Heal the player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task heall(CommandContext ctx, [Description("Mention the player")]DiscordMember user, [Description("heal amount")] int amount)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.heal(ctx, user, amount);
                    break;
                case "dnd":
                    await static_objects.dnd_template.heal(ctx, user, amount);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }


        }

        [Command("Display")]
        [Description("Displays your character")]
        public async Task ShowChar(CommandContext ctx, [Description("Your character name")] params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.ShowChar(ctx, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.ShowChar(ctx, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }

        }

        [Command("Join")]
        [Description("You're joining this session")]
        public async Task JoinGame(CommandContext ctx, [Description("Your character name")] params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.Join(ctx, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.Join(ctx, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }


        }

        [Command("CharList")]
        [Description("Shows the list of characters in the channels RPG system")]
        public async Task CharList(CommandContext ctx)
        {

            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.Charlist(ctx);
                    break;
                case "dnd":
                    await static_objects.dnd_template.CharList(ctx);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }

        [Command("AddItem")]
        [Description("GM ONLY! Gives player an item")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task Additem(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("item amount")] int amount, [Description("item name")]params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.addItem(ctx, user, amount, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.Additem(ctx, user);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }

        [Command("Removeitem")]
        [Description("GM ONLY! Romeves player an item")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task RemoveItem(CommandContext ctx, [Description("Mention the player")]DiscordMember user, [Description("item amount")] int amount, [Description("item name")] params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.RemoveItem(ctx, user, amount, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.RemoveItem(ctx, user, amount, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }

        [Command("addAbility")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        [Description("GM ONLY! Give player an ability")]
        public async Task AddAbi(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("ability name")]params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.addability(ctx, user, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.addability(ctx, user, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }

        }

        [Command("removeability")]
        [Description("GM ONLY! Remove ability from player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task RemoveAbi(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("ability name")] params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.removeability(ctx, user, input);
                    break;
                case "dnd":
                    await static_objects.dnd_template.removeability(ctx, user, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
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
                    await static_objects.WHF_template.showFluff(ctx, user);

                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
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
                    await static_objects.WHF_template.insanity(ctx, user, amount);

                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
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
                    await static_objects.WHF_template.Choroby(ctx, user);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
        [Command("EQ")]
        [Description("gives a list of items in inventory")]
        public async Task Listaitemkw(CommandContext ctx, [Description("mention the player")] DiscordMember user)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.ShowInventory(ctx, user);
                    break;
                case "dnd":
                    await static_objects.dnd_template.ShowInventory(ctx, user);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
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
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
        [Command("journal")]
        [Description("write your own journal")]
        public async Task WriteJournal(CommandContext ctx, [Description("read or write?")] params string[] input)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "wh":
                    await static_objects.WHF_template.Journal(ctx, "warhammer", input);
                    break;
                case "dnd":
                    await static_objects.WHF_template.Journal(ctx, "DnD", input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
        [Command("mutate")]
        [Description("GM ONLY! Give player a mutation")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task GiveMutation(CommandContext ctx, DiscordMember user, params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    await static_objects.WHF_template.Mutate(ctx, user, input);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
        [Command("mutations")]
        [Description("Show players mutations")]
        public async Task showmutations(CommandContext ctx, DiscordMember user)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    await static_objects.WHF_template.Mutations(ctx, user);
                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }

        [Command("ShowSpells")]
        [Description("Shows spells from chosen level")]
        public async Task ShowSpels(CommandContext ctx)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "dnd":
                    await static_objects.dnd_template.ShowLevelSpells(ctx);

                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
        [Command("spelldetails")]
        [Description("shows details of a spell")]
        public async Task spellDetails(CommandContext ctx, params string[] name)
        {
            switch (ctx.Prefix.ToLower())
            {
                case "dnd":
                    await static_objects.dnd_template.spellinfo(ctx, name);

                    break;
                case ">>":
                    if (ctx.Channel.Topic == "warhammer" || ctx.Channel.Topic == "DnD")
                    {
                        await ctx.Channel.SendMessageAsync("use the dedicated rpg command");
                    }
                    else
                    {
                        await ctx.Channel.DeleteMessageAsync(ctx.Message);
                    }
                    break;
            }
        }
    }

}

