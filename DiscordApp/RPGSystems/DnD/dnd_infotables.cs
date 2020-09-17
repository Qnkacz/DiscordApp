﻿using DiscordApp.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordApp.RPGSystems.DnD
{
    public class dnd_infotables
    {
        public List<int> statRollpool = new List<int>();
        public List<int> predetermineRools = new List<int>
        {
            15,14,13,12,10,8
        };
        public List<int> chosenpool;
        public enum backgrounds
        {
            acolyte,criminal,folkHero,noble,sage,soldier 
        }

        public enum Races { human, dwarf, Welf, Helf, halfling, half_elf, hhalf_orc, gnome };
        public enum Classes { barbarian, bard, cleric, druid, fighter, monk, palading, ranger, rouge, warlock, sourcerer, wizard };
        #region traits ideals bonds and flaws
        #region acolyte
        public string[] trait_acolyte = new string[]
        {
            "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.",
            "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.",
            "I see omens in every event and action. The gods try to speak to us, we just need to listen.",
            "Nothing can shake my optimistic attitude.",
            "I quote (or misquote) sacred texts and proverbs in almost every situation",
            "I am tolerant (or intolerant) of other faiths and respect (or condemn) the worship of other gods",
            "I’ve enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me.",
            "I’ve spent so long in the temple that I have little practical experience dealing with people in the outside world."
        };
        public string[] ideal_acolyte = new string[]
        {
            "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)",
            "Charity. I always try to help those in need, no matter what the personal cost. (Good)",
            "Change. We must help bring about the changes the gods are constantly working in the world. (Chaotic)",
            "Power. I hope to one day rise to the top of my faith’s religious hierarchy. (Lawful)",
            "Faith. I trust that my deity will guide my actions. I have faith that if I work hard, things will go well. (Lawful)",
            "Aspiration. I seek to prove myself worthy of my god’s favor by matching my actions against his or her teachings. (Any)"
        };
        public string[] bond_acolyte = new string[]
        {
            "I would die to recover an ancient relic of my faith that was lost long ago.",
            "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",
            "I owe my life to the priest who took me in when my parents died.",
            "Everything I do is for the common people.",
            "I will do anything to protect the temple where I served",
            "I seek to preserve a sacred text that my enemies consider heretical and seek to destroy."
        };
        public string[] flaw_acolyte = new string[]
        {
            "I judge others harshly, and myself even more severely.",
            "I put too much trust in those who wield power within my temple’s hierarchy.",
            "My piety sometimes leads me to blindly trust those that profess faith in my god.",
            "I am inflexible in my thinking.",
            "I am suspicious of strangers and expect the worst of them.",
            "Once I pick a goal, I become obsessed with it to the detriment of everything else in my life."
        };
        #endregion
        #region criminal
        public string[] trait_criminal = new string[]
        {
            "I always have a plan for what to do when things go wrong.",
            "I am always calm, no matter what the situation. I never raise my voice or let my emotions control me.",
            "The first thing I do in a new place is note the locations of everything valuable—or where such things could be hidden.",
            "I would rather make a new friend than a new enemy.",
            "I am incredibly slow to trust. Those who seem the fairest often have the most to hide.",
            "I don’t pay attention to the risks in a situation. Never tell me the odds.",
            "The best way to get me to do something is to tell me I can’t do it.",
            "I blow up at the slightest insult."
        };
        public string[] ideal_criminal = new string[]
        {
            "Honor. I don’t steal from others in the trade. (Lawful)",
            "Freedom. Chains are meant to be broken, as are those who would forge them. (Chaotic)",
            "Charity. I steal from the wealthy so that I can help people in need. (Good)",
            "Greed. I will do whatever it takes to become wealthy. (Evil)",
            "People. I’m loyal to my friends, not to any ideals, and everyone else can take a trip down the Styx for all I care. (Neutral)",
            "Redemption. There’s a spark of good in everyone. (Good"
        };
        public string[] bond_criminal = new string[]
        {
            "I’m trying to pay off an old debt I owe to a generous benefactor",
            "My ill-gotten gains go to support my family.",
            "Something important was taken from me, and I aim to steal it back.",
            "I will become the greatest thief that ever lived.",
            "I’m guilty of a terrible crime. I hope I can redeem myself for it.",
            "Someone I loved died because of I mistake I made. That will never happen again"
        };
        public string[] flaw_criminal = new string[]
        {
            "When I see something valuable, I can’t think about anything but how to steal it.",
            "When faced with a choice between money and my friends, I usually choose the money.",
            "If there’s a plan, I’ll forget it. If I don’t forget it, I’ll ignore it.",
            "I have a “tell” that reveals when I’m lying.",
            "I turn tail and run when things look bad.",
            "An innocent person is in prison for a crime that I committed. I’m okay with that."
        };
        #endregion
        #region folk hero
        public string[] trait_folkHero = new string[]
        {
            "I judge people by their actions, not their words.",
            "If someone is in trouble, I’m always ready to lend help.",
            "When I set my mind to something, I follow through no matter what gets in my way.",
            "I have a strong sense of fair play and always try to find the most equitable solution to arguments.",
            "I’m confident in my own abilities and do what I can to instill confidence in others.",
            "Thinking is for other people. I prefer action.",
            "I misuse long words in an attempt to sound smarter.",
            "I get bored easily. When am I going to get on with my destiny?"
        };
        public string[] ideal_folkHero = new string[]
        {
            "Respect. People deserve to be treated with dignity and respect. (Good)",
            "Fairness. No one should get preferential treatment before the law, and no one is above the law. (Lawful)",
            "Freedom. Tyrants must not be allowed to oppress the people. (Chaotic)",
            "Might. If I become strong, I can take what I want—what I deserve. (Evil)",
            "Sincerity. There’s no good in pretending to be something I’m not. (Neutral)",
            "Destiny. Nothing and no one can steer me away from my higher calling. (Any)"
        };
        public string[] bond_folkHero = new string[]
        {
            "I have a family, but I have no idea where they are. One day, I hope to see them again.",
            "I worked the land, I love the land, and I will protect the land",
            "A proud noble once gave me a horrible beating, and I will take my revenge on any bully I encounter.",
            "My tools are symbols of my past life, and I carry them so that I will never forget my roots",
            "I protect those who cannot protect themselves.",
            "I wish my childhood sweetheart had come with me to pursue my destiny."
        };
        public string[] flaw_folkhero = new string[]
        {
            "The tyrant who rules my land will stop at nothing to see me killed.",
            "I’m convinced of the significance of my destiny, and blind to my shortcomings and the risk of failure.",
            "The people who knew me when I was young know my shameful secret, so I can never go home again.",
            "I have a weakness for the vices of the city, especially hard drink",
            "Secretly, I believe that things would be better if I were a tyrant lording over the land",
            "I have trouble trusting in my allies."
        };
        #endregion
        #region noble
        public string[] trait_noble = new string[]
        {
            "My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world",
            "The common folk love me for my kindness and generosity.",
            "No one could doubt by looking at my regal bearing that I am a cut above the unwashed masses.",
            "I take great pains to always look my best and follow the latest fashions.",
            "I don’t like to get my hands dirty, and I won’t be caught dead in unsuitable accommodations.",
            "Despite my noble birth, I do not place myself above other folk. We all have the same blood.",
            "My favor, once lost, is lost forever.",
            "If you do me an injury, I will crush you, ruin your name, and salt your fields."
        };
        public string[] ideal_noble = new string[]
        {
            "Respect. Respect is due to me because of my position, but all people regardless of station deserve to be treated with dignity. (Good)",
            "Responsibility. It is my duty to respect the authority of those above me, just as those below me must respect mine. (Lawful)",
            "Independence. I must prove that I can handle myself without the coddling of my family. (Chaotic)",
            "Power. If I can attain more power, no one will tell me what to do. (Evil)",
            "Family. Blood runs thicker than water. (Any)",
            "Noble Obligation. It is my duty to protect and care for the people beneath me. (Good)"
        };
        public string[] bond_noble = new string[]
        {
            "I will face any challenge to win the approval of my family.",
            "My house’s alliance with another noble family must be sustained at all costs.",
            "Nothing is more important than the other members of my family.","" +
            "I am in love with the heir of a family that my family despises.",
            "My loyalty to my sovereign is unwavering.",
            "The common folk must see me as a hero of the people."
        };
        public string[] flaw_noble = new string[]
        {
            "I secretly believe that everyone is beneath me.",
            "I hide a truly scandalous secret that could ruin my family forever",
            "I too often hear veiled insults and threats in every word addressed to me, and I’m quick to anger.",
            "I have an insatiable desire for carnal pleasures.",
            "In fact, the world does revolve around me.",
            "By my words and actions, I often bring shame to my family."
        };
        #endregion
        #region sage
        public string[] trait_sage = new string[]
        {
            "I use polysyllabic words that convey the impression of great erudition.",
            "I’ve read every book in the world’s greatest libraries—or I like to boast that I have",
            "I’m used to helping out those who aren’t as smart as I am, and I patiently explain anything and everything to others",
            "There’s nothing I like more than a good mystery.",
            "I’m willing to listen to every side of an argument before I make my own judgment",
            "I . . . speak . . . slowly . . . when talking . . . to idiots, . . . which . . . almost . . . everyone . . . is . . . compared . . . to me",
            "I am horribly, horribly awkward in social situations.",
            "I’m convinced that people are always trying to steal my secrets."
        };
        public string[] ideal_sage = new string[]
        {
            "Knowledge. The path to power and self-improvement is through knowledge. (Neutral)",
            "Beauty. What is beautiful points us beyond itself toward what is true. (Good)",
            "Logic. Emotions must not cloud our logical thinking. (Lawful)",
            "No Limits. Nothing should fetter the infinite possibility inherent in all existence. (Chaotic)",
            "Power. Knowledge is the path to power and domination. (Evil)",
            "Self-Improvement. The goal of a life of study is the betterment of oneself. (Any)"
        };
        public string[] bond_sage = new string[]
        {
            "It is my duty to protect my students.",
            "I have an ancient text that holds terrible secrets that must not fall into the wrong hands.",
            "I work to preserve a library, university, scriptorium, or monastery",
            "My life’s work is a series of tomes related to a specific field of lore.",
            "I’ve been searching my whole life for the answer to a certain question.",
            "I sold my soul for knowledge. I hope to do great deeds and win it back"
        };
        public string[] flaw_sage = new string[]
        {
            "I am easily distracted by the promise of information",
            "Most people scream and run when they see a demon. I stop and take notes on its anatomy.",
            "Unlocking an ancient mystery is worth the price of a civilization.",
            "I overlook obvious solutions in favor of complicated ones.",
            "I speak without really thinking through my words, invariably insulting others",
            "I can’t keep a secret to save my life, or anyone else’s."
        };
        #endregion
        #region soldier
        public string[] trait_soldier = new string[]
        {
            "I’m always polite and respectful.",
            "I’m haunted by memories of war. I can’t get the images of violence out of my mind.",
            "I’ve lost too many friends, and I’m slow to make new ones.",
            "I’m full of inspiring and cautionary tales from my military experience relevant to almost every combat situation.",
            "I can stare down a hell hound without flinching",
            "I enjoy being strong and like breaking things.",
            "I have a crude sense of humor.",
            "I face problems head-on. A simple, direct solution is the best path to success"
        };
        public string[] ideal_soldier = new string[]
        {
            "Greater Good. Our lot is to lay down our lives in defense of others. (Good)",
            "Responsibility. I do what I must and obey just authority. (Lawful)",
            "Independence. When people follow orders blindly, they embrace a kind of tyranny. (Chaotic)",
            "Might. In life as in war, the stronger force wins. (Evil)",
            "Live and Let Live. Ideals aren’t worth killing over or going to war for. (Neutral)",
            "Nation. My city, nation, or people are all that matter. (Any)"
        };
        public string[] bond_soldier = new string[]
        {
            "I would still lay down my life for the people I served with.",
            "Someone saved my life on the battlefield. To this day, I will never leave a friend behind.",
            "My honor is my life.",
            "I’ll never forget the crushing defeat my company suffered or the enemies who dealt it.",
            "Those who fight beside me are those worth dying for.",
            "I fight for those who cannot fight for themselves."
        };
        public string[] flaw_soldier = new string[]
        {
            "The monstrous enemy we faced in battle still leaves me quivering with fear.",
            "I have little respect for anyone who is not a proven warrior.",
            "I made a terrible mistake in battle that cost many lives—and I would do anything to keep that mistake secret.",
            "My hatred of my enemies is blind and unreasoning.",
            "I obey the law, even if the law causes misery.",
            "I’d rather eat my armor than admit when I’m wrong."
        };

        #endregion
        #endregion
        public async Task CreateCharacter(CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
            List<int> customRolls = new List<int>();
            Random random = new Random();
            DnD character = new DnD();
            var QuestionEmbed = new DiscordEmbedBuilder
            {
                Title = "Welcome to the DnD Character creation menu",
                Description = "What is your name?"
            };

            var msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            var response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(110);
            character.name = response.Result.Content;
            QuestionEmbed.Title = "What is your race, react acordingly";
            QuestionEmbed.Description = emojis.human + "- for `human`" + System.Environment.NewLine +
                emojis.elf + "- for `Woodelf`" + System.Environment.NewLine +
                emojis.Helf + "- for `HighElf`" + System.Environment.NewLine +
                emojis.half_elf + "- for `half-elf`" + System.Environment.NewLine +
                emojis.krasnoludy + "- for `Dwarf`" + System.Environment.NewLine +
                emojis.gnome + "- for `Gnome`" + System.Environment.NewLine +
                emojis.half_orc + "- for `Half-Orc`" + System.Environment.NewLine +
                emojis.niziolki + "- for `Halfling`" + System.Environment.NewLine;
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            foreach (var item in emojis.DnDRaceEmojiArr)
            {
                await msg.CreateReactionAsync(item);
            }
            Thread.Sleep(150);
            var interactivity = ctx.Client.GetInteractivity();
            var emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (emojis.DnDRaceEmojiArr.Contains(x.Emoji)));
            Thread.Sleep(200);
            #region racePicker
            if (emojiResult.Result.Emoji == emojis.human)
            {
                character.race = "human";
            }
            if (emojiResult.Result.Emoji == emojis.elf)
            {
                character.race = "wood Elf";
            }
            if (emojiResult.Result.Emoji == emojis.Helf)
            {
                character.race = "high elf";
            }
            if (emojiResult.Result.Emoji == emojis.half_elf)
            {
                character.race = "half elf";
            }
            if (emojiResult.Result.Emoji == emojis.krasnoludy)
            {
                character.race = "dwarf";
            }
            if (emojiResult.Result.Emoji == emojis.gnome)
            {
                character.race = "gnome";
            }
            if (emojiResult.Result.Emoji == emojis.half_orc)
            {
                character.race = "half orc";
            }
            if (emojiResult.Result.Emoji == emojis.niziolki)
            {
                character.race = "halfling";
            }
            #endregion

            QuestionEmbed.Title = "What `Gender` are you";
            QuestionEmbed.Description = emojis.kobieta + "- For Female" + Environment.NewLine + emojis.mezczyzna + "- For Male";
            var gender = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            await gender.CreateReactionAsync(emojis.kobieta);
            await gender.CreateReactionAsync(emojis.mezczyzna);
            Thread.Sleep(200);
            var genderResult = await interactivity.WaitForReactionAsync(x => x.Message == gender
           &&
           (x.Emoji == emojis.kobieta || x.Emoji == emojis.mezczyzna));
            if (genderResult.Result.Emoji == emojis.kobieta)
            {
                character.gender = "Female";
            }
            if (genderResult.Result.Emoji == emojis.mezczyzna)
            {
                character.gender = "Male";
            }

            QuestionEmbed.Title = emojis.yes + " - You roll your stats" + emojis.no + "- use the premade one?";
            QuestionEmbed.Description = "react acordingly";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            await msg.CreateReactionAsync(emojis.yes);
            await msg.CreateReactionAsync(emojis.no);
            Thread.Sleep(150);
            emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (x.Emoji == emojis.yes || x.Emoji == emojis.no));
            if (emojiResult.Result.Emoji == emojis.yes)
            {
                int numbah = -1;
                for (int i = 0; i <= 5; i++)
                {
                    numbah = getDndStatRolls();
                    customRolls.Add(numbah);
                }
                chosenpool = customRolls;
            }
            if (emojiResult.Result.Emoji == emojis.no)
            {
                chosenpool = predetermineRools;
            }
            QuestionEmbed.Title = "Here are your rolls";
            QuestionEmbed.Description = string.Join(" `:` ", chosenpool);
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            string[] statTitles = new string[]
            {
                "What will be your `Strenght`",
                "What will be your `Desxterity`",
                "What will be your `Constitution`",
                "What will be your `Inteligence`",
                "What will be your `Wisdom`",
                "What will be your `Charizma`"
            };
            int[] liczby = new int[6];
            string WszystkieCechyString = string.Empty;
            for (int i = 0; i <= 5; i++) //przydzielanie liczb to statystyk
            {
                WszystkieCechyString = string.Join("` : `", chosenpool);
                QuestionEmbed.Title = statTitles[i];
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < chosenpool.Count; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    liczby[i] = chosenpool[0];
                    chosenpool.RemoveAt(0);
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    liczby[i] = chosenpool[1];
                    chosenpool.RemoveAt(1);
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    liczby[i] = chosenpool[2];
                    chosenpool.RemoveAt(2);
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    liczby[i] = chosenpool[3];
                    chosenpool.RemoveAt(3);
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    liczby[i] = chosenpool[4];
                    chosenpool.RemoveAt(4);
                }
                if (emojiResult.Result.Emoji == emojis.six)
                {
                    liczby[i] = chosenpool[5];
                    chosenpool.RemoveAt(5);
                }
                await userChannel.DeleteMessageAsync(msg);
            }
            character.BaseStats.Add("Strength", liczby[0]);
            character.BaseStats.Add("Dexterity", liczby[1]);
            character.BaseStats.Add("Constitution", liczby[2]);
            character.BaseStats.Add("Intelligence", liczby[3]);
            character.BaseStats.Add("Wisdom", liczby[4]);
            character.BaseStats.Add("Charisma", liczby[5]);
            if (character.race == "wood elf" || character.race == "high elf")
            {
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Accustom ed to twilit forests and the night sky, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if itw ere bright light, and in darkness as if it were dim light.You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Keen Senses.", "You have proficiency in the Perception skill."));
                character.Traits.Add(new DnDTrait("Fey Encestry", "You have advantage on saving throws against being charm ed, and m agic can’t put you to sleep."));
                character.Traits.Add(new DnDTrait("Trance", "Elves don’t need to sleep. Instead, they meditate deeply, remaining sem iconscious, for 4 hours a day. (The Com m on w ord for such meditation is “trance.”) W hile meditating, you can dream after a fashion; such dream s are actually mental exercises that have becom e reflexive through years of practice. After resting in this way, you gain the sam e benefit that a human does from 8 hours of sleep."));
                character.Traits.Add(new DnDTrait("Leanguage", "elfish"));
                character.Traits.Add(new DnDTrait("Elf Weapon Training.", "You have proficiency with the longsword, shortsword, shortbow, and longbow."));
            }
            if (character.race == "high elf")
            {

                character.BaseStats["Intelligence"] += 1;
                QuestionEmbed.Title = "Cantrip";
                QuestionEmbed.Description = "Write one cantrip of your choice from wizard spell list";
                await userChannel.SendMessageAsync(embed: QuestionEmbed);
                var magic = await userChannel.GetNextMessageAsync();
                Thread.Sleep(110);
                var spellname = magic.Result.Content;
                QuestionEmbed.Title = spellname;
                QuestionEmbed.Description = "write the spell description";
                response = await userChannel.GetNextMessageAsync();
                var spellDescr = response.Result.Content;
                DnDSpells spell = new DnDSpells();
                spell.spellName = spellname;
                spell.description = spellDescr;
                character.spells.Add(spell);
            }
            if (character.race == "wood elf")
            {
                character.BaseStats["Wisdom"] += 1;
                character.speed = 35;
                character.Traits.Add(new DnDTrait("Mask of the wild", "You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, falling snow, mist, and other natural phenomena."));
            }
            if (character.race == "halfling")
            {
                character.BaseStats["Dexterity"] += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Lucky", "W hen you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll."));
                character.Traits.Add(new DnDTrait("Brave", "You have advantage on saving throws against being frightened."));
                character.Traits.Add(new DnDTrait("Halfling Nimbleness.", "You can move through the space of any creature that is of a size larger than yours."));
                character.Traits.Add(new DnDTrait("leanguage", "halfling"));
                QuestionEmbed.Title = "Are you a lightfoot or a stout?";
                QuestionEmbed.Description = emojis.yes + "- for lightfoot" + System.Environment.NewLine + emojis.no + " - for stout";
                var stout = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await stout.CreateReactionAsync(emojis.yes); await stout.CreateReactionAsync(emojis.no);
                Thread.Sleep(110);
                var stoutresult = await interactivity.WaitForReactionAsync(x => x.Message == stout
                &&
                (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                if (stoutresult.Result.Emoji == emojis.yes)
                {
                    character.BaseStats["Charisma"] += 1;
                    character.Traits.Add(new DnDTrait("Naturally Stealthy", "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you."));
                    character.race += "- L i g h t f o o t";
                }
                if (stoutresult.Result.Emoji == emojis.no)
                {
                    character.BaseStats["Constitution"] += 1;
                    character.Traits.Add(new DnDTrait("Stout Resilience", "You have advantage on saving throws against poison, and you have resistance against poison damage."));
                    character.race += "- S t o u t";
                }
            }
            if (character.race == "human")
            {
                character.BaseStats["Strength"] += 1;
                character.BaseStats["Dexterity"] += 1;
                character.BaseStats["Constitution"] += 1;
                character.BaseStats["Intelligence"] += 1;
                character.BaseStats["Wisdom"] += 1;
                character.BaseStats["Charisma"] += 1;
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Leanguage: ", "human"));
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add(new DnDTrait("Leanguage: ", response.Result.Content));
            }
            if (character.race == "gnome")
            {
                character.BaseStats["Intelligence"] += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Darkvision", "Accustom ed to life underground, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it were dim light.You can't discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Gnome Cunning", "You have advantage on all Intelligence, W isdom, and Charisma saving throws against magic."));
                character.Traits.Add(new DnDTrait("Leanguage: ", "Gnomish"));

                QuestionEmbed.Title = "Are you a Forest or a Rock gnome?";
                QuestionEmbed.Description = emojis.yes + "- for Forest" + System.Environment.NewLine + emojis.no + " - for Rtout";
                var gnome = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await gnome.CreateReactionAsync(emojis.yes); await gnome.CreateReactionAsync(emojis.no);
                var gnomeResult = await interactivity.WaitForReactionAsync(x => x.Message == gnome
                &&
                (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                if (gnomeResult.Result.Emoji == emojis.yes)
                {
                    character.BaseStats["Dexterity"] += 1;
                    character.Traits.Add(new DnDTrait("Natural ilusionist", "You know the minor illusion cantrip.Intelligence is your spellcasting ability for it."));
                    character.Traits.Add(new DnDTrait(" Speak with Small Beasts", "Through sounds and gestures, you can com m unicate simple ideas with Small or sm aller beasts.Forest gnom es love animals and often keep squirrels, badgers, rabbits, m oles, w oodpeckers, and other creatures as beloved pets."));
                    character.race += "- F o r e s t";
                }
                if (gnomeResult.Result.Emoji == emojis.no)
                {
                    character.BaseStats["Constitution"] += 1;
                    character.Traits.Add(new DnDTrait("Artificer’s Lore", "W henever you make an Intelligence (History) check related to m agic items, alchemical objects, or technological devices, you can add tw ice your proficiency bonus, instead of any proficiency bonus you normally apply."));
                    character.Traits.Add(new DnDTrait("Tinker", "You have proficiency with artisan’s tools (tinker’s tools).Using those tools, you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockw ork device(AC 5, 1 hp).The device ceases to function after 24 hours(unless you spend 1 hour repairing it to keep the device functioning), or when you use your action to dismantle it; at that time, you can reclaim the materials used to create it.You can have up to three such devices active at a time."));
                    character.race += "- R o c k";
                }
            }
            if (character.race == "half elf")
            {
                character.BaseStats["Charisma"] += 2;
                WszystkieCechyString = string.Join("`:`" + Environment.NewLine, statTitles);



                QuestionEmbed.Title = QuestionEmbed.Title = "Choose 1st of two of your stats that you want to increase by 1"; ;
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < 6; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.BaseStats["Strength"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.BaseStats["Dexterity"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.BaseStats["Constitution"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    character.BaseStats["Intelligence"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    character.BaseStats["Wisdom"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.six)
                {
                    character.BaseStats["Charisma"] += 1;
                }
                await userChannel.DeleteMessageAsync(msg);

                QuestionEmbed.Title = QuestionEmbed.Title = "Choose 2nd of two of your stats that you want to increase by 1"; ;
                QuestionEmbed.Description = WszystkieCechyString;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j < 5; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.BaseStats["Strength"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.BaseStats["Dexterity"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.BaseStats["Constitution"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.four)
                {
                    character.BaseStats["Intelligence"] += 1;
                }
                if (emojiResult.Result.Emoji == emojis.five)
                {
                    character.BaseStats["Wisdom"] += 1;
                }
                await userChannel.DeleteMessageAsync(msg);
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Thanks to your elf blood, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it were dim light.You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Fey Ancestry", "You have advantage on saving throws against being charm ed, and m agic can’t put you to sleep."));
                QuestionEmbed.Title = "Choose nother leanguage you know";
                QuestionEmbed.Description = "write the leanguage below";
                msg = msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                character.Traits.Add(new DnDTrait("Leanguage: ", response.Result.Content));
            }
            if (character.race == "half orc")
            {
                character.BaseStats["Sstrength"] = +2;
                character.BaseStats["Constitution"] += 1;
                character.speed = 30;
                character.Traits.Add(new DnDTrait("Darkvision", "Thanks to your orc blood, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it w ere bright light, and in darkness as if it w ere dim light. You can't discern color in darkness, only shades o f gray."));
                character.Traits.Add(new DnDTrait("Menacing", "You gain proficiency in the Intimidation skill."));
                character.Traits.Add(new DnDTrait("Relentless Endurance", "W hen you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead.You can’t use this feature again until you finish a long rest."));
                character.Traits.Add(new DnDTrait("Savage Attacks", "W hen you score a critical hit with a melee weapon attack, you can roll one of the w eapon’s damage dice one additional time and add it to the extra damage of the critical hit."));
                character.Traits.Add(new DnDTrait("Leanguage", "Common"));
                character.Traits.Add(new DnDTrait("Leanguage", "Orcish"));
                character.Intimidation += 1;

            }
            if (character.race == "dwarf")
            {
                character.BaseStats["Constitution"] += 2;
                character.speed = 25;
                character.Traits.Add(new DnDTrait("Darkvision", "A ccustom ed to life underground, you have superior vision in dark and dim conditions.You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it w ere dim light. You can’t discern color in darkness, only shades of gray."));
                character.Traits.Add(new DnDTrait("Dwarven Resilience", "You have advantage on saving throws against poison, and you have resistance against poison damage"));
                character.Traits.Add(new DnDTrait("Dwarven Combat Training", "You have proficiency with the battleaxe, handaxe, throwing hammer, and warhammer."));
                QuestionEmbed.Title = "Choose tool proficiency"; ;
                QuestionEmbed.Description = emojis.one + " - for Smith's tools" + System.Environment.NewLine +
                    emojis.two + " - for brewers supplies" + System.Environment.NewLine +
                    emojis.three + " - for Mason's tools";
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                for (int j = 0; j <= 2; j++)
                {
                    await msg.CreateReactionAsync(emojis.onetototen[j]);
                }
                Thread.Sleep(110);
                emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                &&
                (emojis.onetototen.Contains(x.Emoji)));
                if (emojiResult.Result.Emoji == emojis.one)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency:", " Smith's tools"));
                }
                if (emojiResult.Result.Emoji == emojis.two)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency", " brewers supplies"));
                }
                if (emojiResult.Result.Emoji == emojis.three)
                {
                    character.Traits.Add(new DnDTrait("Tool Proficiency", " Mason's tools"));
                }
                QuestionEmbed.Title = "Choose Your subrace"; ;
                QuestionEmbed.Description = emojis.yes + " - for Hill Darf" + System.Environment.NewLine + emojis.no + " - for Mountain Dwarf";
                var dwarf = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                await dwarf.CreateReactionAsync(emojis.yes);
                await dwarf.CreateReactionAsync(emojis.no);
                Thread.Sleep(100);
                var dwarfResult = await interactivity.WaitForReactionAsync(x => x.Message == dwarf
                &&
                (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                if (dwarfResult.Result.Emoji == emojis.yes)
                {
                    character.BaseStats["Wisdom"] += 1;
                    character.Traits.Add(new DnDTrait("Dwarven Toughness", "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level."));
                }
                if (dwarfResult.Result.Emoji == emojis.no)
                {
                    character.BaseStats["Strength"] += 2;
                    character.Traits.Add(new DnDTrait("Dwarven Armor Training", "You have proficiency with light and medium armor."));
                }
            }
            QuestionEmbed.Title = "How tall are you";
            QuestionEmbed.Description = "`lore friendly` propositions:" + System.Environment.NewLine +
                "`dwarf` -> 120 - 152 cm" + System.Environment.NewLine +
                "`elf` -> 152 - 190 cm" + System.Environment.NewLine +
                "`halfling` -> around 90 cm" + System.Environment.NewLine +
                "`human` -> 150 - 200 cm" + System.Environment.NewLine +
                "`gnome` -> 90 - 120 cm" + System.Environment.NewLine +
                "`half-elf` -> 150 - 200 cm" + System.Environment.NewLine +
                "`half-orc` -> 160 - 200+ cm" + System.Environment.NewLine +
                "** Write only the number below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            Thread.Sleep(230);
            response = await userChannel.GetNextMessageAsync();
            character.height = Int32.Parse(response.Result.Content);
            Thread.Sleep(230);
            QuestionEmbed.Title = "How old are you";
            QuestionEmbed.Description = "`lore friendly` propositions:" + System.Environment.NewLine +
                "`dwarf` -> 5 - 350 Years" + System.Environment.NewLine +
                "`elf` -> 5 - 750 Years" + System.Environment.NewLine +
                "`halfling` -> 5 - 65 years" + System.Environment.NewLine +
                "`human` -> 5 - 80 Years" + System.Environment.NewLine +
                "`gnome` -> 5 - 500 Years" + System.Environment.NewLine +
                "`half-elf` -> 5 - 200 Years" + System.Environment.NewLine +
                "`half-orc` -> 5 - 75 Years" + System.Environment.NewLine +
                "** Write only the number below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            Thread.Sleep(230);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(230);

            QuestionEmbed.Title = "What is your Aligment?";
            QuestionEmbed.Description =
             "Lawful good    |.|  Neutral Good  |.| Chaotic Good" + System.Environment.NewLine +
             "Lawful Neutral |.|  True Neutral  |.| Chaotic Neutral" + System.Environment.NewLine +
             "Lawful evil    |.|  Neutral evil  |.| Chaotic evil";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            for (int i = 0; i < 9; i++)
            {
                await msg.CreateReactionAsync(emojis.onetototen[i]);
            }
            Thread.Sleep(200);
            emojiResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
           &&
           (emojis.onetototen.Contains(x.Emoji)));
            if (emojiResult.Result.Emoji == emojis.one)
            {
                character.aligment = "Lawful good";
            }
            if (emojiResult.Result.Emoji == emojis.two)
            {
                character.aligment = "Neutral Good";
            }
            if (emojiResult.Result.Emoji == emojis.three)
            {
                character.aligment = "Chaotic Good";
            }
            if (emojiResult.Result.Emoji == emojis.four)
            {
                character.aligment = "Lawful Neutral";
            }
            if (emojiResult.Result.Emoji == emojis.five)
            {
                character.aligment = "True Neutral";
            }
            if (emojiResult.Result.Emoji == emojis.six)
            {
                character.aligment = "Chaotic Neutral";
            }
            if (emojiResult.Result.Emoji == emojis.seven)
            {
                character.aligment = "Lawful evi";
            }
            if (emojiResult.Result.Emoji == emojis.eight)
            {
                character.aligment = "Neutral Evil";
            }
            if (emojiResult.Result.Emoji == emojis.nine)
            {
                character.aligment = "Chaotic evil";
            }
            await userChannel.SendMessageAsync("You chose: **" + character.aligment + "**");
            string[] avaibleClasses = new string[]
            {
                "barbarian",
                "bard" ,
                "cleric" ,
                "druid" ,
                "fighter" ,
                "monk" ,
                "paladin" ,
                "ranger" ,
                "rogue" ,
                "sorcerer" ,
                "warlock" ,
                "wizard"
            };
            string description = string.Join(" ", avaibleClasses) + Environment.NewLine + "Write down the class you want to be";
            string input = string.Empty;
            do
            {
                QuestionEmbed.Title = "Choose your class";
                QuestionEmbed.Description = description;
                msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
                response = await userChannel.GetNextMessageAsync();
                input = response.Result.Content.Trim().ToLower();
            } while (!avaibleClasses.Contains(input));
            switch (input)
            {
                case "barbarian":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Barbarian));
                    break;
                case "bard":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Bard));
                    break;
                case "cleric":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Cleric));
                    break;
                case "druid":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Druid));
                    break;
                case "fighter":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Fighter));
                    break;
                case "monk":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Monk));
                    break;
                case "paladin":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Paladin));
                    break;
                case "ranger":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Ranger));
                    break;
                case "rogue":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Rogue));
                    break;
                case "sorcerer":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Sorcerer));
                    break;
                case "warlock":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Warlock));
                    break;
                case "wizard":
                    character.CharacterClass.Add(new CharacterClass(CharacterClass.avaibleClasses.Wizard));
                    break;
            }
            await userChannel.SendMessageAsync("You chose: `" + character.CharacterClass[0].classname + "`");
            character.abilityProficiencies = character.CharacterClass[0].primary_Ability;
            character.SavingThrowProficiencies = character.CharacterClass[0].SavingTHrowproficiencies;
            character.ArmorNWeaponProficiencies = character.CharacterClass[0].armorNweaponproficiencies;
            character.maxHP = character.CharacterClass[0].baseHitPoints + character.BaseStats["Constitution"];
            character.inventory.Add(new DnDitem("gold", "currency in game"), character.CharacterClass[0].startMoney);


            Thread.Sleep(200);
            QuestionEmbed.Title = "What is your `Weight`";
            QuestionEmbed.Description = "** Write only the number below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(200);
            character.weight = Int32.Parse(response.Result.Content);

            QuestionEmbed.Title = "Describe your `Eyes`";
            QuestionEmbed.Description = "** Write the answer below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(200);
            character.eyes = response.Result.Content;

            QuestionEmbed.Title = "Describe your `Hair`";
            QuestionEmbed.Description = "** Write the answer below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(200);
            character.hair = response.Result.Content;

            QuestionEmbed.Title = "Describe your `skin`";
            QuestionEmbed.Description = "** Write the answer below **";
            msg = await userChannel.SendMessageAsync(embed: QuestionEmbed);
            response = await userChannel.GetNextMessageAsync();
            Thread.Sleep(200);
            character.skin = response.Result.Content;



            QuestionEmbed.Title = "Your character:";
            QuestionEmbed.Description =
                "`Name:` **" + character.name + "**" + Environment.NewLine +
                "`Gender:` **" + character.gender + "**" + Environment.NewLine +
                "`Age:` **" + character.age + "**" + Environment.NewLine +
                "`Height:` **" + character.height + "**" + Environment.NewLine +
                "`Weight:` **" + character.weight + "**" + Environment.NewLine +
                "`Eyes:` **" + character.eyes + "**" + Environment.NewLine +
                "`Hair:` **" + character.hair + "**" + Environment.NewLine +
                "`Class:` **" + character.CharacterClass[0].classname + "**" + Environment.NewLine +
                "`EXP:` **" + character.exp + "**" + Environment.NewLine +
                "`Strength:` **" + character.BaseStats["Strength"] + "**" + Environment.NewLine +
                "`Dexterity:` **" + character.BaseStats["Dexterity"] + "**" + Environment.NewLine +
                "`Constitution:` **" + character.BaseStats["Constitution"] + "**" + Environment.NewLine +
                "`Intelligence:` **" + character.BaseStats["Intelligence"] + "**" + Environment.NewLine +
                "`Wisdom:` **" + character.BaseStats["Wisdom"] + "**" + Environment.NewLine +
                "`Charisma:` **" + character.BaseStats["Charisma"] + "**" + Environment.NewLine +
                "`Max HP:` **" + character.maxHP + "**" + Environment.NewLine +
                "`Speed` **" + character.speed + "**" + Environment.NewLine +
                "`initiative` **" + character.initiative + "**" + Environment.NewLine;
            await userChannel.SendMessageAsync(embed: QuestionEmbed);
            GC.Collect();

            //itemki//
            await additemsFromClass(character, ctx, userChannel, emojis);
        }

        public int getDndStatRolls()
        {
            Random r = new Random();
            int output = 0;
            List<int> threes = new List<int>();
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Add(r.Next(1, 6));
            threes.Sort();
            threes.RemoveAt(0);
            foreach (var item in threes)
            {
                output += item;
            }
            return output;
        }

        public async Task additemsFromClass(DnD character, CommandContext ctx, DiscordChannel userChannel, EmojiBase emojis)
        {
            var questionEmbed = new DiscordEmbedBuilder { };
            var interactivity = ctx.Client.GetInteractivity();
            switch (character.CharacterClass[0].classname)
            {
                case "Barbarian":
                    #region barbarian
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.yes + "- for greataxe" + Environment.NewLine + emojis.no + "- for any martial melee weapon";
                    var msg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await msg.CreateReactionAsync(emojis.yes);
                    await msg.CreateReactionAsync(emojis.no);
                    Thread.Sleep(110);
                    var weaponResult = await interactivity.WaitForReactionAsync(x => x.Message == msg
                    &&
                    (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                    if (weaponResult.Result.Emoji == emojis.yes)
                    {
                        character.inventory.Add(new DnDitem("Greataxe", "An axe that is great!"), 1);
                    }
                    if (weaponResult.Result.Emoji == emojis.no)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.yes + "- for 2 handaxes" + Environment.NewLine + emojis.no + "- for any martial simple weapon";
                    var msg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await msg1.CreateReactionAsync(emojis.yes);
                    await msg1.CreateReactionAsync(emojis.no);
                    var secondResult = await interactivity.WaitForReactionAsync(x => x.Message == msg1
                    &&
                    (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                    if (weaponResult.Result.Emoji == emojis.yes)
                    {
                        character.inventory.Add(new DnDitem("handaxe", "a handy axe!"), 2);
                    }
                    if (weaponResult.Result.Emoji == emojis.no)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    character.inventory.Add(new DnDitem("explorer back", "It's huge!"), 1);
                    character.inventory.Add(new DnDitem("Javeline", "haha, jabeline goes brrr"), 4);
                    #endregion
                    break;
                case "Bard":
                    #region bard
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.one + "- for a rapier" + Environment.NewLine + emojis.two + "- for a longsword" + Environment.NewLine + emojis.three + "- For a simple weapon";
                    var bardmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await bardmsg.CreateReactionAsync(emojis.one);
                    await bardmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var bardweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == bardmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (bardweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Rapier", "A fast overgorwn toothpick"), 1);
                    }
                    if (bardweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("Longsword", "kitchen knife on steroids"), 1);
                    }
                    if (bardweaponResult.Result.Emoji == emojis.three)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    character.inventory.Add(new DnDitem("leather armor", "An animal died for this!"), 1);
                    character.inventory.Add(new DnDitem("dagger", "a kitchen knife, but for people"), 1);
                    #endregion
                    break;
                case "Cleric":
                    #region cleric
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.one + "- for a mace" + Environment.NewLine + emojis.two + "- for a warhammer";
                    var clericmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await clericmsg.CreateReactionAsync(emojis.one);
                    await clericmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var clericweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == clericmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (clericweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Rapier", "A fast overgorwn toothpick"), 1);
                    }
                    if (clericweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("Longsword", "kitchen knife on steroids"), 1);
                    }
                    questionEmbed.Title = "Choose your armor";
                    questionEmbed.Description = emojis.one + "- for a mace" + Environment.NewLine + emojis.two + "- for a warhammer" + Environment.NewLine + "- for a chain mail";
                    var clericmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await clericmsg1.CreateReactionAsync(emojis.one);
                    await clericmsg1.CreateReactionAsync(emojis.two);
                    await clericmsg1.CreateReactionAsync(emojis.three);
                    var clericweaponResul1t = await interactivity.WaitForReactionAsync(x => x.Message == clericmsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (clericweaponResul1t.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Scale mail", "Seems rather heavy!"), 1);
                    }
                    if (clericweaponResul1t.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("Leather armor", "An animal died for this!"), 1);
                    }
                    if (clericweaponResul1t.Result.Emoji == emojis.three)
                    {
                        character.inventory.Add(new DnDitem("Chainmail", "Does it shine in blue?"), 1);
                    }

                    questionEmbed.Title = "Choose your another weapon!";
                    questionEmbed.Description = emojis.one + "- for a light crossbow and 20 bolts" + Environment.NewLine + emojis.two + "- for a simple weapon";
                    var clericmsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await clericmsg2.CreateReactionAsync(emojis.one);
                    await clericmsg2.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var clericweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == clericmsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (clericweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("light crossbow", "a fitness crossbow"), 1);
                        character.inventory.Add(new DnDitem("bolt", "crossbow amunition"), 20);
                    }
                    if (clericweaponResult.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your simple weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    #endregion
                    break;
                case "Druid":
                    #region druid
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a wooden sheield" + Environment.NewLine + emojis.two + "- for any simple weapon";
                    var druidmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await druidmsg.CreateReactionAsync(emojis.one);
                    await druidmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var druidweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == druidmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (druidweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Wooden shield", "Seems sturdy"), 1);
                    }
                    if (druidweaponResult.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a scimitar" + Environment.NewLine + emojis.two + "- for any simple melee weapon";
                    var druidmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await druidmsg1.CreateReactionAsync(emojis.one);
                    await druidmsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var druidweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == druidmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (druidweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("scimitar", "Ouch! sharp!"), 1);
                    }
                    if (druidweaponResult1.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    character.inventory.Add(new DnDitem("leather armor", "An animal died for this!"), 1);
                    character.inventory.Add(new DnDitem("explorer's pack", "looks helpful"), 1);
                    character.inventory.Add(new DnDitem("druididic focus", "whu is focus even an item?"), 1);
                    #endregion
                    break;
                case "Fighter":
                    #region fighter
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a chain mail" + Environment.NewLine + emojis.two + "- for leather, longbow and 20 arrows";
                    var fightermsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await fightermsg.CreateReactionAsync(emojis.one);
                    await fightermsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var fighterweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == fightermsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (fighterweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Chain mail", "does it shine blue?"), 1);
                    }
                    if (fighterweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("leather", "smells fresh"), 1);
                        character.inventory.Add(new DnDitem("Longbow", "The size of a human!"), 1);
                        character.inventory.Add(new DnDitem("Arrow", "make it rain"), 20);
                    }


                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a martial weapon and shield" + Environment.NewLine + emojis.two + "- for two martial weapons";
                    var fightermsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await fightermsg1.CreateReactionAsync(emojis.one);
                    await fightermsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var fighterweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == fightermsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (fighterweaponResult1.Result.Emoji == emojis.one)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                        character.inventory.Add(new DnDitem("shield", "he protecc, he atacc"), 1);
                    }
                    if (fighterweaponResult1.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);

                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result1 = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result1.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a light crossbow and 20 bolts" + Environment.NewLine + emojis.two + "- for two handaxes";
                    var fightermsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await fightermsg2.CreateReactionAsync(emojis.one);
                    await fightermsg2.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var fighterweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == fightermsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (fighterweaponResult2.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("light crossbow", "lighter, as the name suggest"), 1);
                        character.inventory.Add(new DnDitem("bolt", "ammunition"), 20);
                    }
                    if (fighterweaponResult2.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("handaxe", "looks handy"), 2);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a dungeoneer's pack" + Environment.NewLine + emojis.two + "- for an explorerer's pack";
                    var fightermsg3 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await fightermsg3.CreateReactionAsync(emojis.one);
                    await fightermsg3.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var fighterweaponResult3 = await interactivity.WaitForReactionAsync(x => x.Message == fightermsg3
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (fighterweaponResult3.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("dungeoneer's pack", "readable in low light conditions!"), 1);
                    }
                    if (fighterweaponResult3.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("explorerer's pack", "looks handy"), 2);
                    }
                    #endregion
                    break;
                case "Monk":
                    #region monk
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.one + "- for a shortsword" + Environment.NewLine + emojis.two + "- for a simple weapon";
                    var monkmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await monkmsg.CreateReactionAsync(emojis.one);
                    await monkmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var monkweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == monkmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (monkweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Shortsword", "a shorter longsword"), 1);
                    }
                    if (monkweaponResult.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.one + "- for a dungeon pack" + Environment.NewLine + emojis.two + "- for a explorer pack";
                    var monkmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await monkmsg1.CreateReactionAsync(emojis.one);
                    await monkmsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var monkweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == monkmsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (monkweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("dungen pack", "usable in low light conditions!"), 1);
                    }
                    if (monkweaponResult1.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("explorer pack", "looks handy!"), 1);
                    }

                    character.inventory.Add(new DnDitem("dart", "for fun and enemies"), 10);
                    #endregion
                    break;
                case "Paladin":
                    #region paladin
                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.yes + "- for a martial weapon and a shield" + Environment.NewLine + emojis.no + "- for two martial weapons";
                    var paladinmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await paladinmsg.CreateReactionAsync(emojis.yes);
                    await paladinmsg.CreateReactionAsync(emojis.no);
                    Thread.Sleep(110);
                    var paladinweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == paladinmsg
                    &&
                    (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                    if (paladinweaponResult.Result.Emoji == emojis.yes)
                    {
                        character.inventory.Add(new DnDitem("Shield", "Looks sturdy"), 1);
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    if (paladinweaponResult.Result.Emoji == emojis.no)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);

                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result1 = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result1.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose your weapon";
                    questionEmbed.Description = emojis.yes + "- for five javelins" + Environment.NewLine + emojis.no + "- for a simple weapon";
                    var paladinmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await paladinmsg1.CreateReactionAsync(emojis.yes);
                    await paladinmsg1.CreateReactionAsync(emojis.no);
                    Thread.Sleep(110);
                    var paladinweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == paladinmsg1
                    &&
                    (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                    if (paladinweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("javbeling", "nice and pointy"), 5);
                    }
                    if (paladinweaponResult1.Result.Emoji == emojis.one)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose ";
                    questionEmbed.Description = emojis.yes + "- for a priest's pack" + Environment.NewLine + emojis.no + "- for an explorer pack";
                    var paladinmsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await paladinmsg2.CreateReactionAsync(emojis.yes);
                    await paladinmsg2.CreateReactionAsync(emojis.no);
                    Thread.Sleep(110);
                    var paladinweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == paladinmsg2
                    &&
                    (x.Emoji == emojis.yes || x.Emoji == emojis.no));
                    if (paladinweaponResult2.Result.Emoji == emojis.yes)
                    {
                        character.inventory.Add(new DnDitem("Priest's pack", "Don't drink the wine!"), 1);
                    }
                    if (paladinweaponResult2.Result.Emoji == emojis.no)
                    {
                        character.inventory.Add(new DnDitem("explorer pack", "looks handy"), 1);
                    }
                    character.inventory.Add(new DnDitem("chain mail", "does it shine blue?"), 1);
                    character.inventory.Add(new DnDitem("Holy symbol", "You feel good when looking at it"), 1);
                    #endregion
                    break;
                case "Ranger":
                    #region ranger
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for scale mail" + Environment.NewLine + emojis.two + "- for leather armor";
                    var rangermsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await rangermsg.CreateReactionAsync(emojis.one);
                    await rangermsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var rangerweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == rangermsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rangerweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Scale mail", "Looks heavy"), 1);
                    }
                    if (rangerweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("Leather armor", "an animal died for this!"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for two shortswords" + Environment.NewLine + emojis.two + "- for two simple melee weapons";
                    var rangermsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await rangermsg1.CreateReactionAsync(emojis.one);
                    await rangermsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var rangerweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == rangermsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rangerweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Shortsword", "Longsword but shorter"), 2);
                    }
                    if (rangerweaponResult1.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for scale mail" + Environment.NewLine + emojis.two + "- for leather armor";
                    var rangermsg3 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await rangermsg3.CreateReactionAsync(emojis.one);
                    await rangermsg3.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var rangerweaponResult3 = await interactivity.WaitForReactionAsync(x => x.Message == rangermsg3
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rangerweaponResult3.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("Dungeon pack", "Looks good in low light conditions!"), 1);
                    }
                    if (rangerweaponResult3.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("explorer pack", "looks handfy!"), 1);
                    }
                    character.inventory.Add(new DnDitem("longbow", "shoots accurately"), 1);
                    character.inventory.Add(new DnDitem("arrow", "make it rain!"), 20);

                    #endregion
                    break;
                case "Rogue":
                    #region rogue
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a rapier " + Environment.NewLine + emojis.two + "- for a shortsword";
                    var roguemsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await roguemsg.CreateReactionAsync(emojis.one);
                    await roguemsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var rogueweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == roguemsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rogueweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("rapier", "Pointy!"), 1);
                    }
                    if (rogueweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("shortsword", "A smaller longsword!"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a shortbow and 20 arrows " + Environment.NewLine + emojis.two + "- for a shortsword";
                    var roguemsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await roguemsg1.CreateReactionAsync(emojis.one);
                    await roguemsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var rogueweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == roguemsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rogueweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("shortbow", "a smaller bow, quick on draw"), 1);
                        character.inventory.Add(new DnDitem("Arrow", "Make it rain!"), 20);
                    }
                    if (rogueweaponResult1.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("shortsword", "A smaller longsword!"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a burglar pack " + Environment.NewLine + emojis.two + "- for a dungeon pack" + Environment.NewLine + emojis.three + "- for an explorer pack";
                    var roguemsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await roguemsg2.CreateReactionAsync(emojis.one);
                    await roguemsg2.CreateReactionAsync(emojis.two);
                    await roguemsg2.CreateReactionAsync(emojis.three);
                    Thread.Sleep(190);
                    var rogueweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == roguemsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (rogueweaponResult2.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("burglar pack", "you can do so much with it"), 1);
                    }
                    if (rogueweaponResult2.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("dungeon pack", "good in low light conditions"), 1);
                    }
                    if (rogueweaponResult2.Result.Emoji == emojis.three)
                    {
                        character.inventory.Add(new DnDitem("explorer pack", "looks handy"), 1);
                    }
                    character.inventory.Add(new DnDitem("leather armor", "an animal died for this!"), 1);
                    character.inventory.Add(new DnDitem("dagger", "a kitchen knife but for enemies"), 2);
                    character.inventory.Add(new DnDitem("thieves tools", "now you see me now you not"), 1);
                    #endregion
                    break;
                case "Sorcerer":
                    #region sorcerer
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a light crossbow and 20 bolts " + Environment.NewLine + emojis.two + "- for a simple weapon";
                    var sorcmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sorcmsg.CreateReactionAsync(emojis.one);
                    await sorcmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sorcweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == sorcmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sorcweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("light crossbow", "Light and quick!"), 1);
                        character.inventory.Add(new DnDitem("bolt", "solid ammunition!"), 20);
                    }
                    if (sorcweaponResult.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a component pouch " + Environment.NewLine + emojis.two + "- for a arcane focus";
                    var sorcmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sorcmsg1.CreateReactionAsync(emojis.one);
                    await sorcmsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sorcweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == sorcmsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sorcweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("component pouch", "for much needed components"), 1);
                    }
                    if (sorcweaponResult1.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("arcane focus", "why is focus even an item"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a dungeon pack" + Environment.NewLine + emojis.two + "- for an explorer pack";
                    var sorcmsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sorcmsg2.CreateReactionAsync(emojis.one);
                    await sorcmsg2.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sorcweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == sorcmsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sorcweaponResult2.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("dungeon pack", "Good in low light"), 1);
                    }
                    if (sorcweaponResult2.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("explorer pack", "seems handy"), 1);
                    }
                    character.inventory.Add(new DnDitem("dagger", "a kitchen knife for enemies"), 2);
                    #endregion
                    break;
                case "Warlock":
                    #region warlock
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a light crossbow and 20 bolts " + Environment.NewLine + emojis.two + "- for a simple weapon";
                    var sawrlockmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sawrlockmsg.CreateReactionAsync(emojis.one);
                    await sawrlockmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sawrcweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == sawrlockmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sawrcweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("light crossbow", "Light and quick!"), 1);
                        character.inventory.Add(new DnDitem("bolt", "solid ammunition!"), 20);
                    }
                    if (sawrcweaponResult.Result.Emoji == emojis.two)
                    {
                        questionEmbed.Title = "Name your weapon";
                        questionEmbed.Description = "write down the answer below";
                        await userChannel.SendMessageAsync(embed: questionEmbed);
                        Thread.Sleep(110);
                        var result = await userChannel.GetNextMessageAsync();
                        character.inventory.Add(new DnDitem(result.Result.Content, ""), 1);
                    }
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a component pouch " + Environment.NewLine + emojis.two + "- for a arcane focus";
                    var sawrlockmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sawrlockmsg1.CreateReactionAsync(emojis.one);
                    await sawrlockmsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sawrcweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == sawrlockmsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sawrcweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("component pouch", "for much needed components"), 1);
                    }
                    if (sawrcweaponResult1.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("arcane focus", "why is focus even an item"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a dungeon pack" + Environment.NewLine + emojis.two + "- for a schoolar's pack";
                    var sawrlockmsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await sawrlockmsg2.CreateReactionAsync(emojis.one);
                    await sawrlockmsg2.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var sawrcweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == sawrlockmsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (sawrcweaponResult2.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("dungeon pack", "Good in low light"), 1);
                    }
                    if (sawrcweaponResult2.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("schoolar's pack", "so many books"), 1);
                    }
                    character.inventory.Add(new DnDitem("leather armor", "Ana nimal died for this!"), 1);
                    character.inventory.Add(new DnDitem("dagger", "a kitchen knife but for enemies"), 2);

                    questionEmbed.Title = "Name your weapon";
                    questionEmbed.Description = "write down the answer below";
                    await userChannel.SendMessageAsync(embed: questionEmbed);
                    Thread.Sleep(110);
                    var warcresult = await userChannel.GetNextMessageAsync();
                    Thread.Sleep(110);
                    character.inventory.Add(new DnDitem(warcresult.Result.Content, ""), 1);
                    #endregion
                    break;
                case "Wizard":
                    #region wizard
                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a quarterstaff" + Environment.NewLine + emojis.two + "- for a dagger";
                    var wizkmsg = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await wizkmsg.CreateReactionAsync(emojis.one);
                    await wizkmsg.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var wizweaponResult = await interactivity.WaitForReactionAsync(x => x.Message == wizkmsg
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (wizweaponResult.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("quarterstaff", "light and hight range!"), 1);
                    }
                    if (wizweaponResult.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("dagger", "a kitchen knife but for enemies"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a component pouch " + Environment.NewLine + emojis.two + "- for a arcane focus";
                    var wizlockmsg1 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await wizlockmsg1.CreateReactionAsync(emojis.one);
                    await wizlockmsg1.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var wizweaponResult1 = await interactivity.WaitForReactionAsync(x => x.Message == wizlockmsg1
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (wizweaponResult1.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("component pouch", "for much needed components"), 1);
                    }
                    if (wizweaponResult1.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("arcane focus", "why is focus even an item"), 1);
                    }

                    questionEmbed.Title = "Choose";
                    questionEmbed.Description = emojis.one + "- for a dungeon pack" + Environment.NewLine + emojis.two + "- for a schoolar's pack";
                    var wizkmsg2 = await userChannel.SendMessageAsync(embed: questionEmbed);
                    await wizkmsg2.CreateReactionAsync(emojis.one);
                    await wizkmsg2.CreateReactionAsync(emojis.two);
                    Thread.Sleep(190);
                    var wizweaponResult2 = await interactivity.WaitForReactionAsync(x => x.Message == wizkmsg2
                    &&
                    (emojis.onetototen.Contains(x.Emoji)));
                    if (wizweaponResult2.Result.Emoji == emojis.one)
                    {
                        character.inventory.Add(new DnDitem("dungeon pack", "Good in low light"), 1);
                    }
                    if (wizweaponResult2.Result.Emoji == emojis.two)
                    {
                        character.inventory.Add(new DnDitem("schoolar's pack", "so many books"), 1);
                    }
                    character.inventory.Add(new DnDitem("spellbook", "so many spells!"), 1);
                    #endregion
                    break;
            }
        }
    }
}
