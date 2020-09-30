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
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
            //DnDInventory inv = new DnDInventory();
            //Console.WriteLine(inv.inventoryList.Count.ToString());
            //inv.Add("gold", 69);
            //inv.Add("pike", 69);


            //Console.WriteLine(inv.inventoryList.Count.ToString());
            //inv.Add("gold", 1);
            //Console.WriteLine(((DnDitem)inv.inventoryList[0]).amount);
            //inv.remove("gold", 1);
            //Console.WriteLine(((DnDitem)inv.inventoryList[0]).amount);
        }
    }
}
