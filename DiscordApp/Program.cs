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
            bot.RunAsync().GetAwaiter().GetResult();
            //string JsonFromFile = string.Empty;
            //using (var reader = new StreamReader("C:\\Users\\ufus0\\source\\repos\\DiscordApp\\DiscordApp\\bin\\Debug\\netcoreapp3.1\\358599651710074880\\DnD\\123\\123_inv.json"))
            //{
            //    JsonFromFile = reader.ReadToEnd();
            //}
            //DnDInventory character = Newtonsoft.Json.JsonConvert.DeserializeObject<DnDInventory>(JsonFromFile);
            //character.remove("gold", 111);
            //Console.WriteLine(character.inventoryList[0].name+Environment.NewLine+ character.inventoryList[0].amount);
        }
    }
}
