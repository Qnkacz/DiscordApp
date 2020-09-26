using DiscordApp.RPGSystems.DnD;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace DiscordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bot = new Bot();
            //bot.RunAsync().GetAwaiter().GetResult();
            //string JsonFromFile = string.Empty;
            //using (var reader = new StreamReader("C:\\Users\\ufus0\\source\\repos\\DiscordApp\\DiscordApp\\bin\\Debug\\netcoreapp3.1\\358599651710074880\\DnD\\123\\123_inv.json"))
            //{
            //    JsonFromFile = reader.ReadToEnd();
            //}
            //DnDInventory character = Newtonsoft.Json.JsonConvert.DeserializeObject<DnDInventory>(JsonFromFile);
            //character.remove("gold", 111);
            //Console.WriteLine(character.inventoryList[0].name+Environment.NewLine+ character.inventoryList[0].amount);
            string jsonFromFile = string.Empty;
            using (var reader = new StreamReader("C:\\Users\\ufus0\\source\\repos\\DiscordApp\\DiscordApp\\bin\\Debug\\netcoreapp3.1\\db_items.json"))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            DnDItemList Character = JsonConvert.DeserializeObject<DnDItemList>(jsonFromFile);
            Console.WriteLine(Character.allitems.Count.ToString());
            Character.allitems.AddRange(Character.SimpleMeleeWeapons);
            Character.allitems.AddRange(Character.SimpleRangedWeapons);
            Character.allitems.AddRange(Character.MartialMeleeWeapons);
            Character.allitems.AddRange(Character.MartialRangedWeapons);
            Character.allitems.AddRange(Character.LightArmor);
            Character.allitems.AddRange(Character.MediumArmor);
            Character.allitems.AddRange(Character.HeavyArmor);
            Character.allitems.AddRange(Character.Ammunition);
            Character.allitems.AddRange(Character.Misc);
            Console.WriteLine(Character.allitems.Count.ToString());
        }
    }
}
