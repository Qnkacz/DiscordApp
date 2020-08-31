using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.WarhammerFantasy
{
    class WHF_commands : BaseCommandModule
    {
        [Command("DMG")]
        public async Task Heal(CommandContext ctx, DiscordMember user, int amount, params string[] charName)
        {
            string name = string.Join(" ", charName);
            if (File.Exists(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
            {
                string JsonFromFile;
                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    JsonFromFile = reader.ReadToEnd();
                }
                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                character.zywotnosc -= amount;
                await ctx.Channel.SendMessageAsync("Zadano `" + name + "` " + amount + " obrażeń ");
                if (character.zywotnosc <= 3) await ctx.Channel.SendMessageAsync("uwaga, Twoja postać: `" + name + "` ma tylko: " + character.zywotnosc + " życia!");
                if (character.zywotnosc <= 0)
                {
                    await ctx.Channel.SendMessageAsync("Twoja postać: `" + name + "` Umarła");
                    File.Delete(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json");
                }
                else
                {
                    JsonFromFile = JsonConvert.SerializeObject(character);
                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + name + ".json", JsonFromFile);
                }

            }
            else
            {
                await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
            }
            //await ctx.Channel.SendMessageAsync(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json");
        }
        [Command("Heal")]
        public async Task heall(CommandContext ctx, DiscordMember user, int amount, params string[] charName)
        {
            string name = string.Join(" ", charName);
            if (File.Exists(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
            {
                string JsonFromFile;
                using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    JsonFromFile = reader.ReadToEnd();
                }
                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                character.zywotnosc += amount;
                await ctx.Channel.SendMessageAsync("Wyleczono: `" + name + "` " + amount + " obrażeń ");
                JsonFromFile = JsonConvert.SerializeObject(character);
                File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + name + ".json", JsonFromFile);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
            }
            //await ctx.Channel.SendMessageAsync(user.Id + "/" + ctx.Channel.Topic + "/" + name + ".json");
        }
        [Command("Display")]
        public async Task ShowChar(CommandContext ctx, params string[] input)
        {
            var template = new WHF_Infotables();
            string name = string.Join(" ", input);
            if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
            {
                string JsonFromFile;
                using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    JsonFromFile = reader.ReadToEnd();
                }
                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                var plate = template.CharPlate(character);
                plate.Title = "Moja postać";
                await ctx.Channel.SendMessageAsync(embed: plate);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
            }
        }
        [Command("Join")]
        public async Task JoinGame(CommandContext ctx, params string[] input)
        {
            var template = new WHF_Infotables();
            string name = string.Join(" ", input);
            if (File.Exists(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
            {
                string JsonFromFile;
                using (var reader = new StreamReader(ctx.Member.Id + "/" + ctx.Channel.Topic + "/" + name + ".json"))
                {
                    JsonFromFile = reader.ReadToEnd();
                }
                warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                var plate = template.CharPlate(character);
                plate.Title = ctx.Member.DisplayName;
                var variable = await ctx.Channel.SendMessageAsync(embed: plate);
                await variable.PinAsync();
            }
            else
            {
                await ctx.Channel.SendMessageAsync("nie znalazłem postaci");
            }
        }
        [Command("CharList")]
        public async Task CharList(CommandContext ctx)
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
        [Command("AddItem")]
        public async Task Additem(CommandContext ctx, DiscordMember user, int amount, params string[] input)
        {
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
                        await ctx.Channel.SendMessageAsync("znalazłem wiadomosc!");
                        string line = string.Empty;
                        using (System.IO.StringReader reader = new System.IO.StringReader(item.Description))
                        {
                            line = await reader.ReadLineAsync();
                        }
                        line = line.Remove(0, 8);
                        await ctx.Channel.SendMessageAsync(line);
                        string JsonFromFile =string.Empty;
                        using (var reader = new StreamReader(user.Id + "/" + ctx.Channel.Topic + "/" + line + ".json"))
                        {
                            JsonFromFile =await reader.ReadToEndAsync();
                        }
                        string itemname = string.Join(" ", input);
                        warhammer character = Newtonsoft.Json.JsonConvert.DeserializeObject<warhammer>(JsonFromFile);
                        character.przedmioty.Add(new KeyValuePair<string, int>(itemname, amount));
                        JsonFromFile = JsonConvert.SerializeObject(character);
                        File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + line + ".json", JsonFromFile);

                        await ctx.Channel.SendMessageAsync("dodałem: `"+amount+" "+itemname+"` do ekwipunku: `"+line);
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
