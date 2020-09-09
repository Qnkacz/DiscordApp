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
            switch (ctx.Prefix)
            {
                case "wh":
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        string line = string.Empty;
                        string JsonFromFile = string.Empty;
                        warhammer character = new warhammer();
                        bool znaleziono = false;
                        if (ctx.Channel.Topic != "warhammer") //jezeli nie jestes na kanale to susuwa wiadomosc
                        {
                            var cosiek = await ctx.Channel.SendMessageAsync("jesteś poza kanałem do grania w rpg" + ctx.Member.Mention);
                            Thread.Sleep(30000);
                            await ctx.Channel.DeleteMessageAsync(ctx.Message);
                            await ctx.Channel.DeleteMessageAsync(cosiek);
                        }
                        else
                        {
                            var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                            List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                            List<DiscordEmbed> embed = new List<DiscordEmbed>();
                            foreach (var item in playerChars) //zapisuje embedy do listy
                            {
                                embed = item.Embeds.ToList();
                                embeds.Add(embed[0]);
                                embed.Clear();
                            }
                            foreach (var item in embeds) //przechodzi prze liste embedów
                            {

                                if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                                {
                                    znaleziono = true;
                                    using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                    {
                                        line = await reader.ReadLineAsync();
                                    }
                                    line = line.Remove(0, 8);
                                    using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                    {
                                        JsonFromFile = await reader.ReadToEndAsync();
                                    }
                                    character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                }
                                else
                                {
                                    await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                                }
                            }

                            if (znaleziono == true)
                            {
                                if (character.zywotnosc - amount <= 0)
                                {
                                    await ctx.Channel.SendMessageAsync("Twoja postać umarła");
                                    File.Delete(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json");
                                    await ctx.Channel.SendMessageAsync("Pamiętajcie, zeby odpiać postać z tablicy!");
                                }
                                else
                                {
                                    character.zywotnosc -= amount;
                                    await ctx.Channel.SendMessageAsync("zadano " + line + " " + amount + " obrażeń");
                                    JsonFromFile = JsonConvert.SerializeObject(character);
                                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                                }
                            }
                        }
                    }
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
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        string line = string.Empty;
                        string JsonFromFile = string.Empty;
                        warhammer character = new warhammer();
                        bool znaleziono = false;
                        if (ctx.Channel.Topic != "warhammer") //jezeli nie jestes na kanale to susuwa wiadomosc
                        {
                            var cosiek = await ctx.Channel.SendMessageAsync("jesteś poza kanałem do grania w rpg" + ctx.Member.Mention);
                            Thread.Sleep(30000);
                            await ctx.Channel.DeleteMessageAsync(ctx.Message);
                            await ctx.Channel.DeleteMessageAsync(cosiek);
                        }
                        else
                        {
                            var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                            List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                            List<DiscordEmbed> embed = new List<DiscordEmbed>();
                            foreach (var item in playerChars) //zapisuje embedy do listy
                            {
                                embed = item.Embeds.ToList();
                                embeds.Add(embed[0]);
                                embed.Clear();
                            }
                            foreach (var item in embeds) //przechodzi prze liste embedów
                            {

                                if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                                {
                                    znaleziono = true;
                                    using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                    {
                                        line = await reader.ReadLineAsync();
                                    }
                                    line = line.Remove(0, 8);
                                    using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                    {
                                        JsonFromFile = await reader.ReadToEndAsync();
                                    }
                                    character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                }
                                else
                                {
                                    await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                                }
                            }

                            if (znaleziono == true)
                            {
                                character.zywotnosc += amount;
                                await ctx.Channel.SendMessageAsync("wyleczone " + line + " " + amount + " obrażeń");
                                JsonFromFile = JsonConvert.SerializeObject(character);
                                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                            }
                        }
                    }
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
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string name = string.Join(" ", input);
                if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    string JsonFromFile;
                    using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                    {
                        JsonFromFile = reader.ReadToEnd();
                    }
                    switch (ctx.Prefix)
                    {
                        case "wh":
                            var template = new WHF_Infotables();
                            warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                            var plate = template.CharPlate(character);
                            plate.Title = "Moja postać";
                            await ctx.Channel.SendMessageAsync(embed: plate);
                            break;
                        case ">>":
                            await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                            break;
                    }

                }
                else
                {
                    await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
                }
            }

        }

        [Command("Join")]
        [Description("You're joining this session")]
        public async Task JoinGame(CommandContext ctx, [Description("Your character name")] params string[] input)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                string name = string.Join(" ", input);
                if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    string JsonFromFile;
                    using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                    {
                        JsonFromFile = reader.ReadToEnd();
                    }
                    switch (ctx.Prefix)
                    {
                        case "wh":
                            var template = new WHF_Infotables();
                            warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                            var plate = template.CharPlate(character);
                            plate.Title = ctx.Member.DisplayName;
                            var variable = await ctx.Channel.SendMessageAsync(embed: plate);
                            await variable.PinAsync();
                            break;
                        case ">>":
                            await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                            break;
                    }
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
                }
            }

        }

        [Command("CharList")]
        [Description("Shows the list of characters in the channels RPG system")]
        public async Task CharList(CommandContext ctx)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                string Description = string.Empty;
                if (Directory.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic))
                {
                    DirectoryInfo di = new DirectoryInfo(ctx.Member.Id + "/" + ctx.Channel.Topic);
                    FileInfo[] files = di.GetFiles();
                    foreach (var item in files)
                    {
                        Description += Path.GetFileNameWithoutExtension(item.FullName) + " // ";
                    }
                    Description.Trim('/');
                    Description.Trim('/');
                    var chars = new DiscordEmbedBuilder
                    {
                        Title = "Twoje postacie do `" + ctx.Channel.Topic + "` " + ctx.Member.DisplayName,
                        Description = Description
                    };
                    await ctx.Channel.SendMessageAsync(embed: chars);
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("Nie masz żadnych postaci do tego systemu");
                }
            }
        }

        [Command("AddItem")]
        [Description("GM ONLY! Gives player an item")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task Additem(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("item amount")] int amount, [Description("item name")]params string[] input)
        {
            switch (ctx.Prefix)
            {
                case "wh":
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                        List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                        List<DiscordEmbed> embed = new List<DiscordEmbed>();
                        foreach (var item in playerChars) //zapisuje embedy do listy
                        {
                            embed = item.Embeds.ToList();
                            embeds.Add(embed[0]);
                            embed.Clear();
                        }
                        foreach (var item in embeds) //przechodzi prze liste embedów
                        {
                            if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                            {
                                string line = string.Empty;
                                using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                {
                                    line = await reader.ReadLineAsync();
                                }
                                line = line.Remove(0, 8);
                                string JsonFromFile = string.Empty;
                                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                {
                                    JsonFromFile = await reader.ReadToEndAsync();
                                }
                                string itemname = string.Join(" ", input);
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                character.przedmioty.Add(new KeyValuePair<string, int>(itemname, amount));
                                JsonFromFile = JsonConvert.SerializeObject(character);
                                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                                await ctx.Channel.SendMessageAsync("dodałem: `" + amount + " " + itemname + "` do ekwipunku: `" + line);
                            }
                            else
                            {
                                await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                            }
                        }
                    }
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
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                        List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                        List<DiscordEmbed> embed = new List<DiscordEmbed>();
                        foreach (var item in playerChars) //zapisuje embedy do listy
                        {
                            embed = item.Embeds.ToList();
                            embeds.Add(embed[0]);
                            embed.Clear();
                        }
                        foreach (var item in embeds) //przechodzi prze liste embedów
                        {
                            if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                            {
                                string line = string.Empty;
                                using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                {
                                    line = await reader.ReadLineAsync();
                                }
                                line = line.Remove(0, 8);
                                string JsonFromFile = string.Empty;
                                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                {
                                    JsonFromFile = await reader.ReadToEndAsync();
                                }
                                string itemname = string.Join(" ", input);
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                //character.przedmioty.Add(new KeyValuePair<string, int>(itemname, amount));
                                var playeritem = new KeyValuePair<string, int>(); //wyciagniecie itemka z listy
                                foreach (var iten in character.przedmioty)
                                {
                                    if (iten.Key == itemname)
                                    {
                                        playeritem = iten;
                                        break;
                                        ;
                                    }
                                }
                                int itemcount = playeritem.Value - amount; //zmniejszenie wartosci
                                if (itemcount < 0)
                                {
                                    character.przedmioty.Remove(playeritem);
                                }
                                else
                                {
                                    var Replaceitem = new KeyValuePair<string, int>(playeritem.Key, itemcount);
                                    character.przedmioty.Add(Replaceitem);
                                }

                                JsonFromFile = JsonConvert.SerializeObject(character);
                                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                                await ctx.Channel.SendMessageAsync("usunąłem: `" + amount + " " + itemname + "` z ekwipunku: `" + line);
                            }
                            else
                            {
                                await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                            }
                        }

                    }
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
                        var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                        List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                        List<DiscordEmbed> embed = new List<DiscordEmbed>();
                        foreach (var item in playerChars) //zapisuje embedy do listy
                        {
                            embed = item.Embeds.ToList();
                            embeds.Add(embed[0]);
                            embed.Clear();
                        }
                        foreach (var item in embeds) //przechodzi prze liste embedów
                        {
                            if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                            {
                                string line = string.Empty;
                                using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                {
                                    line = await reader.ReadLineAsync();
                                }
                                line = line.Remove(0, 8);
                                string JsonFromFile = string.Empty;
                                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                {
                                    JsonFromFile = await reader.ReadToEndAsync();
                                }
                                string itemname = string.Join(" ", input);
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                character.umiejetnosci.Add(itemname);
                                JsonFromFile = JsonConvert.SerializeObject(character);
                                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                                await ctx.Channel.SendMessageAsync("dodałem: `" + line + "` umiejetnosc: `" + itemname + "`");
                            }
                            else
                            {
                                await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                            }
                        }

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
                    if (ctx.Channel.Parent.Name.ToLower() == "rpg")
                    {
                        var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                        List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                        List<DiscordEmbed> embed = new List<DiscordEmbed>();
                        foreach (var item in playerChars) //zapisuje embedy do listy
                        {
                            embed = item.Embeds.ToList();
                            embeds.Add(embed[0]);
                            embed.Clear();
                        }
                        foreach (var item in embeds) //przechodzi prze liste embedów
                        {
                            if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                            {
                                string line = string.Empty;
                                using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                                {
                                    line = await reader.ReadLineAsync();
                                }
                                line = line.Remove(0, 8);
                                string JsonFromFile = string.Empty;
                                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                                {
                                    JsonFromFile = await reader.ReadToEndAsync();
                                }
                                string itemname = string.Join(" ", input);
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                character.umiejetnosci.Remove(itemname);
                                JsonFromFile = JsonConvert.SerializeObject(character);
                                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                                await ctx.Channel.SendMessageAsync("usunałem: `" + line + "` umiejetnosc: `" + itemname + "`");
                            }
                            else
                            {
                                await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                            }
                        }

                    }
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
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {
                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        await ctx.Channel.SendMessageAsync(line);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        switch (ctx.Prefix)
                        {
                            case "wh":
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                var history = new DiscordEmbedBuilder
                                {
                                    Title = "Historia: " + character.CharName,
                                    Description = character.fluff
                                };
                                await ctx.Channel.SendMessageAsync(embed: history);
                                break;
                            case ">>":
                                await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                                break;
                        }

                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }

            }
        }

        [Command("Insanity")]
        [Description(" GM ONLY! Deal insanity Damage to player")]
        [RequireRoles(RoleCheckMode.Any, "GM")]
        public async Task DmgObled(CommandContext ctx, [Description("Mention the player")] DiscordMember user, [Description("damage amount")] int amount)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var yes = DiscordEmoji.FromName(ctx.Client, ":+1:");
                var no = DiscordEmoji.FromName(ctx.Client, ":-1:");

                string line = string.Empty;
                string JsonFromFile = string.Empty;
                warhammer character = new warhammer();
                bool znaleziono = false;

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {

                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        znaleziono = true;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }
                switch (ctx.Prefix)
                {
                    case "wh":
                        if (znaleziono == true)
                        {
                            if (character.obled + amount >= 6)
                            {
                                await ctx.Channel.SendMessageAsync("Twoja postać dostała choroby psychicznej, wpisz jej nazwe");
                                var choroba = await ctx.Channel.GetNextMessageAsync();
                                if (character.choroby.Count == 0) //kys
                                {
                                    var kysembed = new DiscordEmbedBuilder
                                    {
                                        Title = line + " chce się zabic",
                                        Description = "pozwolić?",
                                        Color = DiscordColor.Red
                                    };
                                    var kysMsg = await ctx.Channel.SendMessageAsync(embed: kysembed);
                                    await kysMsg.CreateReactionAsync(yes);
                                    await kysMsg.CreateReactionAsync(no);
                                    var interactivity = ctx.Client.GetInteractivity();
                                    Thread.Sleep(300);
                                    var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == kysMsg
                                    &&
                                    (x.Emoji == yes || x.Emoji == no)).ConfigureAwait(false);
                                    if (sexResult.Result.Emoji == yes)
                                    {
                                        Random r = new Random();
                                        if (r.Next(1, 10) <= 2)
                                        {
                                            await ctx.Channel.SendMessageAsync("Twoja postać jest bohatyrem");
                                            File.Delete(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json");
                                            return;
                                        }
                                        else
                                        {
                                            await ctx.Channel.SendMessageAsync("twoja postać żyje");
                                        }
                                    }
                                    else if (sexResult.Result.Emoji == no)
                                    {
                                        await ctx.Channel.SendMessageAsync("twoja postać żyje");
                                    }
                                }
                                character.choroby.Add(choroba.Result.Content);
                                character.obled = 0;
                                
                            }
                            else
                            {
                                character.obled += amount;
                            }
                            JsonFromFile = JsonConvert.SerializeObject(character);
                            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);
                            await ListaChorob(ctx, user);
                        }
                        break;
                    case ">>":
                        await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                        break;
                }



            }
        }

        [Command("illness")]
        [Description("Lists the mental disorders of a player")]
        public async Task ListaChorob(CommandContext ctx, [Description("Mention the player")] DiscordMember user)
        {
            if (ctx.Channel.Parent.Name.ToLower() == "rpg")
            {

                var playerChars = await ctx.Channel.GetPinnedMessagesAsync(); // dostaje wszystkie pinowane wiadomosci (inaczej postacie)
                List<DiscordEmbed> embeds = new List<DiscordEmbed>();
                List<DiscordEmbed> embed = new List<DiscordEmbed>();
                foreach (var item in playerChars) //zapisuje embedy do listy
                {
                    embed = item.Embeds.ToList();
                    embeds.Add(embed[0]);
                    embed.Clear();
                }
                foreach (var item in embeds) //przechodzi prze liste embedów
                {
                    if (item.Title == user.DisplayName) //jezeli znalazlo postac gracza to dodaje
                    {
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        string JsonFromFile = string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile = await reader.ReadToEndAsync();
                        }
                        switch (ctx.Prefix)
                        {
                            case "wh":
                                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                                string[] choroby = character.choroby.ToArray();
                                string wiadomosc = string.Join(Environment.NewLine, choroby);
                                var history = new DiscordEmbedBuilder
                                {
                                    Title = "Choroby: " + character.CharName,
                                    Description = wiadomosc
                                };
                                await ctx.Channel.SendMessageAsync(embed: history);
                                break;
                            case ">>":
                                await ctx.Channel.SendMessageAsync("use the dedicated system prefixes");
                                break;
                        }

                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("nie znalazłem gracza w tej sesji");
                    }
                }

            }
        }
    }

}

