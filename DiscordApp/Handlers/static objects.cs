﻿using DiscordApp.RPGSystems.DnD;
using DiscordApp.RPGSystems.WarhammerFantasy;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordApp.Handlers
{
    public static class static_objects
    {
        public static WHF_Infotables WHF_template = new WHF_Infotables();
        public static dnd_infotables dnd_template = new dnd_infotables();
    }
}
