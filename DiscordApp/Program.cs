using DiscordApp.RPGSystems.DnD;
using System;
using System.IO;

namespace DiscordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
           // bot.RunAsync().GetAwaiter().GetResult();
            string JsonFromFile = string.Empty;
            using (var reader = new StreamReader("C:\\Users\\ufus0\\source\\repos\\DiscordApp\\DiscordApp\\bin\\Debug\\netcoreapp3.1\\358599651710074880\\DnD\\nigga.json"))
            {

                JsonFromFile = reader.ReadToEnd();
            }
            Console.WriteLine(JsonFromFile);
            DnD character = Newtonsoft.Json.JsonConvert.DeserializeObject<DnD>(JsonFromFile);
        }
    }
}
