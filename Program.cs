using PowerConvert.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PowerConvert
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = $"{Globals.ToolName} by {Globals.Author} ~ Version {Globals.Version}";
            Interface.PrintArt();
            Menu.MainMenu();

            Console.ReadKey();
        }

        private static async Task UpdateCheck()
        {
            WebClient wc = new WebClient();
            wc.DownloadData("")
        }
    }
}