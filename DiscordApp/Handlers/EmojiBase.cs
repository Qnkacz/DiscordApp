﻿using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp.Handlers
{
    public class EmojiBase
    {

        public DiscordEmoji human;
        public DiscordEmoji elf;
        public DiscordEmoji krasnoludy;
        public DiscordEmoji niziolki;

        public DiscordEmoji kobieta;
        public DiscordEmoji mezczyzna;

        public DiscordEmoji one;
        public DiscordEmoji two;
        public DiscordEmoji three;
        public DiscordEmoji four;
        public DiscordEmoji five;
        public DiscordEmoji six;
        public DiscordEmoji seven;
        public DiscordEmoji eight;
        public DiscordEmoji nine;
        public DiscordEmoji ten;
        public DiscordEmoji[] onetototen = new DiscordEmoji[10];

        public EmojiBase(CommandContext ctx)
        {
            human = DiscordEmoji.FromName(ctx.Client, ":thinking:");
            elf = DiscordEmoji.FromName(ctx.Client, ":elf:");
            krasnoludy = DiscordEmoji.FromName(ctx.Client, ":tools:");
            niziolki = DiscordEmoji.FromName(ctx.Client, ":baby:");

            kobieta = DiscordEmoji.FromName(ctx.Client, ":female_sign:");
            mezczyzna = DiscordEmoji.FromName(ctx.Client, ":male_sign:");

            one = DiscordEmoji.FromName(ctx.Client, ":one:");
            two = DiscordEmoji.FromName(ctx.Client, ":two:");
            three = DiscordEmoji.FromName(ctx.Client, ":three:");
            four = DiscordEmoji.FromName(ctx.Client, ":four:");
            five = DiscordEmoji.FromName(ctx.Client, ":five:");
            six = DiscordEmoji.FromName(ctx.Client, ":six:");
            seven = DiscordEmoji.FromName(ctx.Client, ":seven:");
            eight = DiscordEmoji.FromName(ctx.Client, ":eight:");
            nine = DiscordEmoji.FromName(ctx.Client, ":nine:");
            ten = DiscordEmoji.FromName(ctx.Client, ":zero:");
            onetototen[0] = one;
            onetototen[1] = two;
            onetototen[2] = three;
            onetototen[3] = four;
            onetototen[4] = five;
            onetototen[5] = six;
            onetototen[6] = seven;
            onetototen[7] = eight;
            onetototen[8] = nine;
            onetototen[9] = ten;
        }
    }
}
