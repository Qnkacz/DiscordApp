using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordApp
{
    public class ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
        [JsonProperty("prefix_wh")]
        public string Prefix_wh { get; private set; }
        [JsonProperty("prefix_dnd")]
        public string Prefix_dnd { get; private set; }
    }

}
