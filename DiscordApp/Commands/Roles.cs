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
                    WHF_Infotables template = new WHF_Infotables();
                    warhammer PlayerCharacter = new warhammer();
                    var inputStep = new StringStep("", "Witaj w kreatorze postaci do Warhammera" + System.Environment.NewLine + "Jak sie nazywasz?", null);

                    string input = string.Empty;


                    bool plec = new bool(); // false - kobieta, true - mezczyzna
                    string plec_string = string.Empty;
                    List<string> umiejetnosci = new List<string>();
                    List<string> zdolnosci = new List<string>();

                    string Charactername = string.Empty;

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
                        Description = emojis.kobieta + " - dla kobiety" + System.Environment.NewLine + emojis.mezczyzna + "- dla męzczyzny",
                        Color = DiscordColor.Gold
                    };
                    var sexMsg = await userChannel.SendMessageAsync(embed: SexEmbed);
                    await sexMsg.CreateReactionAsync(emojis.kobieta);
                    await sexMsg.CreateReactionAsync(emojis.mezczyzna);
                    var interactivity = ctx.Client.GetInteractivity();
                    Thread.Sleep(300);
                    var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == sexMsg
                    &&
                    (x.Emoji == emojis.kobieta || x.Emoji == emojis.mezczyzna)).ConfigureAwait(false);
                    if (sexResult.Result.Emoji == emojis.kobieta)
                    {
                        plec = false;
                        plec_string = "kobieta";
                        await userChannel.SendMessageAsync(plec.ToString() + plec_string);
                    }
                    else if (sexResult.Result.Emoji == emojis.mezczyzna)
                    {
                        plec = true;
                        plec_string = "mężczyzna";
                        await userChannel.SendMessageAsync(plec.ToString() + plec_string);
                    }

                    var RaseEmbed = new DiscordEmbedBuilder
                    {
                        Title = "What Race are you?",
                        Description = emojis.human + " -for human race" + System.Environment.NewLine + emojis.elf + " -for elf race" + System.Environment.NewLine + emojis.krasnoludy + " -for dwarfs" + System.Environment.NewLine + emojis.niziolki + "- for halfling",
                        Color = DiscordColor.Red
                    };
                    var raceMsg = await userChannel.SendMessageAsync(embed: RaseEmbed);
                    await raceMsg.CreateReactionAsync(emojis.human);
                    await raceMsg.CreateReactionAsync(emojis.elf);
                    await raceMsg.CreateReactionAsync(emojis.krasnoludy);
                    await raceMsg.CreateReactionAsync(emojis.niziolki);
                    Thread.Sleep(300);
                    var raceResult = await interactivity.WaitForReactionAsync(x => x.Message == raceMsg
                    &&
                    (x.Emoji == emojis.human || x.Emoji == emojis.elf || x.Emoji == emojis.krasnoludy || x.Emoji == emojis.niziolki)).ConfigureAwait(false);
                    Thread.Sleep(10);
                    ////////////////////////////////////////////////////////////////////


                    ////////////////////////////////////////////////////////////////////
                    inputStep = new StringStep("", "jaki kolor oczu?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    string kolor_oczu = input;

                    inputStep = new StringStep("", "jaki kolor wlosów?", null);
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
                    if (raceResult.Result.Emoji == emojis.human)
                    {
                        PlayerCharacter = template.CreateHuman(Charactername, plec, kolor_oczu, kolor_wlosow);
                        Thread.Sleep(300);
                    }
                    else if (raceResult.Result.Emoji == emojis.elf)
                    {
                        PlayerCharacter = template.CreateElf(Charactername, plec, kolor_oczu, kolor_wlosow);
                        Thread.Sleep(300);
                    }
                    else if (raceResult.Result.Emoji == emojis.krasnoludy)
                    {
                        PlayerCharacter = template.CreateDwarf(Charactername, plec, kolor_oczu, kolor_wlosow);
                        Thread.Sleep(300);
                    }
                    else
                    {
                        PlayerCharacter = template.CreateHalfling(Charactername, plec, kolor_oczu, kolor_wlosow);
                        Thread.Sleep(300);
                    }
                    inputStep = new StringStep("", "Opowiedz coś o sobie?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    PlayerCharacter.fluff = input;

                    inputStep = new StringStep("", "Ile masz lat?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    PlayerCharacter.age = Int32.Parse(input);

                    DirectoryInfo di = Directory.CreateDirectory(ctx.Member.Id.ToString() + "/warhammer/");
                    string json = JsonConvert.SerializeObject(PlayerCharacter);
                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + Charactername + ".json", json);

                    var ostatnia_wiadomosc = new DiscordEmbedBuilder
                    {
                        Title = "Twoja postać: " + ctx.Member.DisplayName,
                        Description = "`Imie:` " + Charactername + System.Environment.NewLine +
                                    "`Rasa:` " + PlayerCharacter.Rasa + System.Environment.NewLine +
                                    "`Płeć:` " + PlayerCharacter.plec_string + System.Environment.NewLine +
                                    "`Kolor Włosów:` " + PlayerCharacter.hair_color + System.Environment.NewLine +
                                    "`Kolor Oczu:` " + PlayerCharacter.eye_color + System.Environment.NewLine +
                                    "`walka w ręcz:` " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                                    "`Strzelectwo:` " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                                    "`Krzepa:` " + PlayerCharacter.krzepa + System.Environment.NewLine +
                                    "`odporność:` " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                                    "`Zreczność:` " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                                    "`Inteligencja:` " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                                    "`Sila woli:` " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                                    "`Ogłada:` " + PlayerCharacter.Oglada + System.Environment.NewLine +
                                    "`Ataki:` " + PlayerCharacter.ataki + System.Environment.NewLine +
                                    "`żywotność:` " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                                    "`Siła:` " + PlayerCharacter.sila + System.Environment.NewLine +
                                    "`Wytrzymałość:` " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                                    "`Szybkość:` " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                                    "`Magia:` " + PlayerCharacter.magia + System.Environment.NewLine +
                                    "`Obłęd:` " + PlayerCharacter.obled + System.Environment.NewLine +
                                    "`Przeznaczenie:` " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                                    "`Profesja:` " + PlayerCharacter.proffesion + System.Environment.NewLine +
                                    "`Wiek:` " + PlayerCharacter.age + System.Environment.NewLine +
                                    "`Wysokość:` " + PlayerCharacter.heigth + System.Environment.NewLine +
                                    "`Waga:` " + PlayerCharacter.weight,
                        Color = DiscordColor.IndianRed
                    };

                    var fluffEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Historia twojej postaci: " + Charactername,
                        Description = PlayerCharacter.fluff
                    };
                    await userChannel.SendMessageAsync(embed: ostatnia_wiadomosc);
                    await userChannel.SendMessageAsync(embed: fluffEmbed);
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

                    Random randomNumber = new Random();
                    WHF_Infotables template = new WHF_Infotables();
                    warhammer PlayerCharacter = new warhammer();
                    var inputStep = new StringStep("bottom text", "Witaj w kreatorze postaci do Warhammera" + System.Environment.NewLine + "Jak sie nazywasz?", null);

                    string input = string.Empty;
                    bool plec = new bool(); // false - kobieta, true - mezczyzna
                    string plec_string = string.Empty;
                    List<string> umiejetnosci = new List<string>();
                    List<string> zdolnosci = new List<string>();
                    List<int> PulaLiczb = new List<int>();
                    string Charactername = string.Empty;

                    inputStep.OnValidResult += (result) => input = result;
                    var inputDialogueHandler = new DialogueHandler(
                        ctx.Client,
                        userChannel,
                        ctx.User,
                        inputStep
                        );
                    await inputDialogueHandler.ProcessDialogue();
                    Charactername = input;  //added char name
                    PlayerCharacter.CharName = Charactername;
                    var SexEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Jesteś kobietą, czy mężczyzną?",
                        Description = emojis.kobieta + " - dla kobiety" + System.Environment.NewLine + emojis.mezczyzna + "- dla męzczyzny",
                        Color = DiscordColor.Gold
                    };
                    var sexMsg = await userChannel.SendMessageAsync(embed: SexEmbed);
                    await sexMsg.CreateReactionAsync(emojis.kobieta);
                    await sexMsg.CreateReactionAsync(emojis.mezczyzna);
                    var interactivity = ctx.Client.GetInteractivity();
                    Thread.Sleep(300);
                    var sexResult = await interactivity.WaitForReactionAsync(x => x.Message == sexMsg
                    &&
                    (x.Emoji == emojis.kobieta || x.Emoji == emojis.mezczyzna)).ConfigureAwait(false);
                    if (sexResult.Result.Emoji == emojis.kobieta)
                    {
                        PlayerCharacter.plec = plec = false;
                        PlayerCharacter.plec_string = plec_string = "kobieta";

                    }
                    else if (sexResult.Result.Emoji == emojis.mezczyzna)
                    {
                        PlayerCharacter.plec = plec = true;
                        PlayerCharacter.plec_string = plec_string = "mężczyzna";
                    }

                    var RaseEmbed = new DiscordEmbedBuilder
                    {
                        Title = "What Race are you?",
                        Description = emojis.human + " -for human race" + System.Environment.NewLine + emojis.elf + " -for elf race" + System.Environment.NewLine + emojis.krasnoludy + " -for dwarfs" + System.Environment.NewLine + emojis.niziolki + "- for halfling",
                        Color = DiscordColor.Red

                    };
                    var raceMsg = await userChannel.SendMessageAsync(embed: RaseEmbed);
                    await raceMsg.CreateReactionAsync(emojis.human);
                    await raceMsg.CreateReactionAsync(emojis.elf);
                    await raceMsg.CreateReactionAsync(emojis.krasnoludy);
                    await raceMsg.CreateReactionAsync(emojis.niziolki);
                    Thread.Sleep(300);
                    var raceResult = await interactivity.WaitForReactionAsync(x => x.Message == raceMsg
                    &&
                    (x.Emoji == emojis.human || x.Emoji == emojis.elf || x.Emoji == emojis.krasnoludy || x.Emoji == emojis.niziolki)).ConfigureAwait(false);
                    Thread.Sleep(300);
                    ////////////////////////////////////////////////////////////////////


                    ////////////////////////////////////////////////////////////////////
                    inputStep = new StringStep("bottom text", "jaki kolor oczu?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    string kolor_oczu = input;
                    PlayerCharacter.eye_color = input;

                    inputStep = new StringStep("bottom text", "jaki kolor wlosów?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );

                    await inputDialogueHandler.ProcessDialogue();
                    string kolor_wlosow = input;
                    PlayerCharacter.hair_color = input;
                    inputStep = new StringStep(",", "Opowiedz coś o sobie?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    PlayerCharacter.fluff = input;

                    inputStep = new StringStep(",", "Ile masz lat?", null);
                    inputStep.OnValidResult += (result) => input = result;
                    inputDialogueHandler = new DialogueHandler(
                       ctx.Client,
                       userChannel,
                       ctx.User,
                       inputStep
                       );
                    await inputDialogueHandler.ProcessDialogue();
                    PlayerCharacter.age = Int32.Parse(input);
                    ////////////////////////////////////////////////////////////////////
                    string profesje = string.Empty;
                    if (raceResult.Result.Emoji == emojis.human)
                    {
                        PlayerCharacter.Rasa = "Człowiek";
                        profesje = string.Join("` : `", template.ProfesjeHuman);
                    }
                    else if (raceResult.Result.Emoji == emojis.elf)
                    {
                        PlayerCharacter.Rasa = "Elf";
                        profesje = string.Join("` : `", template.ProfesjeElf);
                    }
                    else if (raceResult.Result.Emoji == emojis.krasnoludy)
                    {
                        PlayerCharacter.Rasa = "Krasnolud";
                        profesje = string.Join("` : `", template.ProfesjeDwarf);
                    }
                    else if (raceResult.Result.Emoji == emojis.niziolki)
                    {
                        PlayerCharacter.Rasa = "Niziołek";
                        profesje = string.Join("` : `", template.ProfesjeHalfling);
                    }
                    await userChannel.SendMessageAsync("Wybierz jedną z ponizszych profesji:");
                    await userChannel.SendMessageAsync(profesje);
                    string wybranaProfesja = string.Empty;
                    do
                    {
                        inputStep = new StringStep("bottom text", "Wybór Dokonujesz wpisując dokładną nazwę Profesji", null);
                        inputStep.OnValidResult += (result) => input = result;
                        inputDialogueHandler = new DialogueHandler(
                           ctx.Client,
                           userChannel,
                           ctx.User,
                           inputStep
                           );
                        await inputDialogueHandler.ProcessDialogue();
                        wybranaProfesja = input;
                    } while (!template.profesje.Contains(input));
                    PlayerCharacter.proffesion = wybranaProfesja;

                    List<int> rollPolOne = new List<int>();
                    List<int> rollPollTwo = new List<int>();
                    for (int i = 0; i < 7; i++)
                    {
                        rollPolOne.Add(randomNumber.Next(1, 10) + randomNumber.Next(1, 10));
                        rollPollTwo.Add(randomNumber.Next(1, 10) + randomNumber.Next(1, 10));
                    }
                    await userChannel.SendMessageAsync("Oto twoje dwie pule rzutów do losowania cech");
                    string pierwszaPulaString = string.Join("` : `", rollPolOne);
                    string drugaPulaString = string.Join("` : `", rollPollTwo);
                    var poolOneEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Pierwsza pula rzutów",
                        Description = pierwszaPulaString
                    };
                    var pool2ncEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Druga pula rzutów",
                        Description = drugaPulaString
                    };
                    await userChannel.SendMessageAsync(embed: poolOneEmbed);
                    await userChannel.SendMessageAsync(embed: pool2ncEmbed);
                    var PoolEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Które rzuty wybierasz?",
                        Description = emojis.one + " - dla 1 puli" + System.Environment.NewLine + emojis.two + "- dla 2 puli",
                        Color = DiscordColor.Gold
                    };
                    var PoolChoice = await userChannel.SendMessageAsync(embed: PoolEmbed);
                    await PoolChoice.CreateReactionAsync(emojis.one);
                    await PoolChoice.CreateReactionAsync(emojis.two);
                    Thread.Sleep(300);
                    var PoolResult = await interactivity.WaitForReactionAsync(x => x.Message == PoolChoice
                    &&
                    (x.Emoji == emojis.one || x.Emoji == emojis.two)).ConfigureAwait(false);
                    if (PoolResult.Result.Emoji == emojis.one)
                    {
                        PulaLiczb = rollPolOne;
                    }
                    if (PoolResult.Result.Emoji == emojis.two)
                    {
                        PulaLiczb = rollPollTwo;
                    }

                    ///////// 7 cech
                    string WszystkieCechyString = string.Join("` : `", PulaLiczb);
                    string[] tytuly = new string[]
                    {
                       "Wybierz która z liczb będzie Twoją Walka wręcz","Wybierz która z liczb będzie Twoją Umiejętnością Strzelecką","Wybierz która z liczb będzie Twoją Krzepą",
                       "Wybierz która z liczb będzie Twoją Odpornością","Wybierz która z liczb będzie Twoją Zręcznością?","Wybierz która z liczb będzie Twoją Siłą Woli?",

                    };
                    int[] liczby = new int[7];
                    for (int i = 0; i < PulaLiczb.Count; i++) //loop przez wszystkie cechy
                    {
                        var CechaEmbed = new DiscordEmbedBuilder
                        {
                            Title = tytuly[i],
                            Description = WszystkieCechyString
                        };
                        var cechaMsg = await userChannel.SendMessageAsync(embed: CechaEmbed);
                        for (int j = 0; i < PulaLiczb.Count; j++)
                        {
                            await cechaMsg.CreateReactionAsync(emojis.onetototen[j]);
                        }
                        Thread.Sleep(300);
                        var WWResult = await interactivity.WaitForReactionAsync(x => x.Message == cechaMsg
                        &&
                        (x.Emoji == emojis.one || x.Emoji == emojis.two || x.Emoji == emojis.three || x.Emoji == emojis.four || x.Emoji == emojis.five || x.Emoji == emojis.six || x.Emoji == emojis.seven)).ConfigureAwait(false);
                        if (WWResult.Result.Emoji == emojis.one)
                        {
                            liczby[i] = PulaLiczb[0];
                            PulaLiczb.RemoveAt(0);
                        }
                        if (WWResult.Result.Emoji == emojis.two)
                        {
                            liczby[i] = PulaLiczb[1];
                            PulaLiczb.RemoveAt(1);
                        }
                        if (WWResult.Result.Emoji == emojis.three)
                        {
                            liczby[i] = PulaLiczb[2];
                            PulaLiczb.RemoveAt(2);
                        }
                        if (WWResult.Result.Emoji == emojis.four)
                        {
                            liczby[i] = PulaLiczb[3];
                            PulaLiczb.RemoveAt(3);
                        }
                        if (WWResult.Result.Emoji == emojis.five)
                        {
                            liczby[i] = PulaLiczb[5];
                            PulaLiczb.RemoveAt(5);
                        }
                        if (WWResult.Result.Emoji == emojis.six)
                        {
                            liczby[i] = PulaLiczb[5];
                            PulaLiczb.RemoveAt(5);
                        }
                        if (WWResult.Result.Emoji == emojis.seven)
                        {
                            liczby[i] = PulaLiczb[6];
                            PulaLiczb.RemoveAt(6);
                        }
                        await userChannel.DeleteMessageAsync(cechaMsg);
                    }

                    ///dodanie bazowych rzeczh
                    template.AddDefaultValues(PlayerCharacter);
                    PlayerCharacter.umiejetnosci = new List<string>();
                    PlayerCharacter.zdolnosci = new List<string>();
                    PlayerCharacter.Oglada = PulaLiczb[0];
                    PlayerCharacter.sila = (int)(PlayerCharacter.krzepa.ToString()[0]) - 48;
                    PlayerCharacter.wytrzymalosc = (int)(PlayerCharacter.odpowrnosc.ToString()[0]) - 48;
                    PlayerCharacter.zywotnosc = template.PoczatkowaZywotnosc(PlayerCharacter.Rasa);
                    PlayerCharacter.heigth = template.PoczatkowaWysokosc(PlayerCharacter.Rasa, PlayerCharacter.plec);
                    PlayerCharacter.weight = template.RandomWeight(PlayerCharacter.Rasa);
                    PlayerCharacter.przeznaczenie = template.PoczatkowePrzeznaczenie(PlayerCharacter.Rasa.ToLower());
                    PlayerCharacter.ataki = 1;
                    PlayerCharacter.szybkosc = template.PoczatkowaSzybkosz(PlayerCharacter.Rasa.ToLower());
                    PlayerCharacter.przedmioty = new List<KeyValuePair<string, int>>();
                    PlayerCharacter.choroby = new List<string>();

                    template.AddStartUmiejetnosci(PlayerCharacter);
                    var ostatnia_wiadomosc = new DiscordEmbedBuilder
                    {
                        Title = "Twoja postać: " + ctx.Member.DisplayName,
                        Description = "`Imie:` " + Charactername + System.Environment.NewLine +
                                   "`Rasa:` " + PlayerCharacter.Rasa + System.Environment.NewLine +
                                   "`Płeć:` " + PlayerCharacter.plec_string + System.Environment.NewLine +
                                   "`Kolor Włosów:` " + PlayerCharacter.hair_color + System.Environment.NewLine +
                                   "`Kolor Oczu:` " + PlayerCharacter.eye_color + System.Environment.NewLine +
                                   "`walka w ręcz:` " + PlayerCharacter.walka_wrecz.ToString() + System.Environment.NewLine +
                                   "`Strzelectwo:` " + PlayerCharacter.strzelectwo.ToString() + System.Environment.NewLine +
                                   "`Krzepa:` " + PlayerCharacter.krzepa + System.Environment.NewLine +
                                   "`odporność:` " + PlayerCharacter.odpowrnosc + System.Environment.NewLine +
                                   "`Zreczność:` " + PlayerCharacter.zrecznosc + System.Environment.NewLine +
                                   "`Inteligencja:` " + PlayerCharacter.inteligencjal + System.Environment.NewLine +
                                   "`Sila woli:` " + PlayerCharacter.sila_woli + System.Environment.NewLine +
                                   "`Ogłada:` " + PlayerCharacter.Oglada + System.Environment.NewLine +
                                   "`Ataki:` " + PlayerCharacter.ataki + System.Environment.NewLine +
                                   "`żywotność:` " + PlayerCharacter.zywotnosc + System.Environment.NewLine +
                                   "`Siła:` " + PlayerCharacter.sila + System.Environment.NewLine +
                                   "`Wytrzymałość:` " + PlayerCharacter.wytrzymalosc + System.Environment.NewLine +
                                   "`Szybkość:` " + PlayerCharacter.szybkosc + System.Environment.NewLine +
                                   "`Magia:` " + PlayerCharacter.magia + System.Environment.NewLine +
                                   "`Obłęd:` " + PlayerCharacter.obled + System.Environment.NewLine +
                                   "`Przeznaczenie:` " + PlayerCharacter.przeznaczenie + System.Environment.NewLine +
                                   "`Profesja:` " + PlayerCharacter.proffesion + System.Environment.NewLine +
                                   "`Wiek:` " + PlayerCharacter.age + System.Environment.NewLine +
                                   "`Wysokość:` " + PlayerCharacter.heigth + System.Environment.NewLine +
                                   "`Waga:` " + PlayerCharacter.weight,
                        Color = DiscordColor.IndianRed
                    };
                    var fluffEmbed = new DiscordEmbedBuilder
                    {
                        Title = "Historia twojej postaci: " + Charactername,
                        Description = PlayerCharacter.fluff
                    };
                    DirectoryInfo di = Directory.CreateDirectory(ctx.Member.Id.ToString() + "/warhammer/");
                    string json = JsonConvert.SerializeObject(PlayerCharacter);
                    File.WriteAllText(ctx.Member.Id.ToString() + "/" + "warhammer" + "/" + Charactername + ".json", json);
                    await userChannel.SendMessageAsync(embed: ostatnia_wiadomosc);
                    await userChannel.SendMessageAsync(embed: fluffEmbed);
                    break;
                case ">>":
                    await userChannel.SendMessageAsync("use prefixes `wh` `dnd` `coc` or `ner` to create characters for that system");
                    break;
            }
        }

    }
}
