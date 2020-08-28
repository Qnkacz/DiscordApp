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
                Thread.Sleep(1000);
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

        [Command("w")]
        public async Task StartCreationChat(CommandContext ctx)
        {
            Random randomNumber = new Random();
            WHF_Infotables template = new WHF_Infotables();
            warhammer PlayerCharacter = new warhammer();
            string game = "W A R H A M M E R";

            var inputStep = new StringStep(game, "Witaj w kreatorze postaci do Warhammera" + System.Environment.NewLine + "Jak sie nazywasz?", null);
            var userChannel = await ctx.Member.CreateDmChannelAsync();
            string input = string.Empty;

            var human = DiscordEmoji.FromName(ctx.Client, ":thinking:");
            var elf = DiscordEmoji.FromName(ctx.Client, ":leaves:");
            var krasnoludy = DiscordEmoji.FromName(ctx.Client, ":poop:");
            var niziolki = DiscordEmoji.FromName(ctx.Client, ":baby:");

            var kobieta = DiscordEmoji.FromName(ctx.Client, ":female_sign:");
            var mezczyzna = DiscordEmoji.FromName(ctx.Client, ":male_sign:");
            bool plec = new bool(); // false - kobieta, true - mezczyzna
            string plec_string = string.Empty;
            List<string> umiejetnosci = new List<string>();
            List<string> zdolnosci = new List<string>();

            string Charactername = string.Empty;
            string Race = string.Empty;
            string profession = input;

            inputStep.OnValidResult += (result) => input = result;
            var inputDialogueHandler = new DialogueHandler(
                ctx.Client,
                userChannel,
                ctx.User,
                inputStep
                );
            await inputDialogueHandler.ProcessDialogue();
            Charactername = input;  //added char name

            var SexEmbed = new DiscordEmbedBuilder
            {
                Title = "Jesteś kobietą, czy mężczyzną?",
                Description = kobieta + " - dla kobiety" + System.Environment.NewLine + mezczyzna + "- dla męzczyzny",
                Color = DiscordColor.Gold
            };
            var sexMsg = await userChannel.SendMessageAsync(embed: SexEmbed);
            await sexMsg.CreateReactionAsync(kobieta);
            await sexMsg.CreateReactionAsync(mezczyzna);
            var interactivity = ctx.Client.GetInteractivity();
            Thread.Sleep(10);
            var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == sexMsg
            &&
            (x.Emoji == kobieta || x.Emoji == mezczyzna)).ConfigureAwait(false);
            if (sexResult.Result.Emoji == kobieta)
            {
                plec = false;
                plec_string = "kobieta";
            }
            else if (sexResult.Result.Emoji == mezczyzna)
            {
                plec = true;
                plec_string = "mężczyzna";
            }
            await userChannel.SendMessageAsync(plec_string);
            ////////////////////////////////////////////////////////////////////
            inputStep = new StringStep(game, "jaki kolor oczu?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            string kolor_oczu = input;

            inputStep = new StringStep(game, "jaki kolor wlosów?", null);
            inputStep.OnValidResult += (result) => input = result;
            inputDialogueHandler = new DialogueHandler(
               ctx.Client,
               userChannel,
               ctx.User,
               inputStep
               );
            await inputDialogueHandler.ProcessDialogue();
            string kolor_wlosow = input;
            ////////////////////////////////////////////////////////////////////
            var RaseEmbed = new DiscordEmbedBuilder
            {
                Title = "What Race are you?",
                Description = human + " -for human race" + System.Environment.NewLine + elf + " -for elf race" + System.Environment.NewLine + krasnoludy + " -for dwarfs" + System.Environment.NewLine + niziolki + "- for halfling",
                Color = DiscordColor.Red

            };
            var raceMsg = await userChannel.SendMessageAsync(embed: RaseEmbed);
            await raceMsg.CreateReactionAsync(human);
            await raceMsg.CreateReactionAsync(elf);
            await raceMsg.CreateReactionAsync(krasnoludy);
            await raceMsg.CreateReactionAsync(niziolki);
            Thread.Sleep(10);
            var raceResult = await interactivity.WaitForReactionAsync(x => x.Message == raceMsg
            &&
            (x.Emoji == human || x.Emoji == elf || x.Emoji == krasnoludy || x.Emoji == niziolki)).ConfigureAwait(false);
            Thread.Sleep(10);
            ////////////////////////////////////////////////////////////////////
            int roll_zytowtnosc = randomNumber.Next(1, 10);
            int roll_przeznaczenie = randomNumber.Next(1, 10);
            if (raceResult.Result.Emoji == human)
            {
                PlayerCharacter = template.CreateHuman(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(10);
            }
            else if (raceResult.Result.Emoji == elf)
            {
                PlayerCharacter = template.CreateElf(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(10);
            }
            else if (raceResult.Result.Emoji == krasnoludy)
            {
                PlayerCharacter = template.CreateDwarf(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(10);
            }
            else
            {
                PlayerCharacter = template.CreateHalfling(Charactername, plec, kolor_oczu, kolor_wlosow);
                Thread.Sleep(10);
            }
            DirectoryInfo di = Directory.CreateDirectory(ctx.Member.Id.ToString() + "/warhammer/");
            string json = JsonConvert.SerializeObject(PlayerCharacter);
            File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + Charactername + ".json", json);

            var ostatnia_wiadomosc = new DiscordEmbedBuilder
            {
                Title = "Twoja postać: " + ctx.Member.DisplayName,
                Description = "Imie: " + Charactername + System.Environment.NewLine +
                            "Rasa: " + PlayerCharacter.Rasa + System.Environment.NewLine +
                            "Płeć: " + plec_string + System.Environment.NewLine +
                            "Kolor Włosów: " + PlayerCharacter.hair_color + System.Environment.NewLine +
                            "Kolor Oczu: " + PlayerCharacter.eye_color + System.Environment.NewLine +
                            "walka w ręcz: " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                            "Strzelectwo: " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                            "Krzepa: " + PlayerCharacter.krzepa + System.Environment.NewLine +
                            "odporność: " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                            "Zreczność: " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                            "Inteligencja: " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                            "Sila woli: " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                            "Ogłada: " + PlayerCharacter.Oglada + System.Environment.NewLine +
                            "Ataki: " + PlayerCharacter.ataki + System.Environment.NewLine +
                            "żywotność: " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                            "Siła: " + PlayerCharacter.sila + System.Environment.NewLine +
                            "Wytrzymałość: " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                            "Szybkość: " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                            "Magia: " + PlayerCharacter.magia + System.Environment.NewLine +
                            "Obłęd: " + PlayerCharacter.obled + System.Environment.NewLine +
                            "Przeznaczenie: " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                            "Profesja: " + PlayerCharacter.proffesion + System.Environment.NewLine +
                            "Wiek: <Na razie stale 25 bo mi sie juz nie chce>" + System.Environment.NewLine +
                            "Wysokość: " + PlayerCharacter.heigth + System.Environment.NewLine +
                            "Waga: na stale 80 bo mi sie nie chce",
                Color = DiscordColor.IndianRed
            };
            await userChannel.SendMessageAsync(embed: ostatnia_wiadomosc);
        }
    }
}
