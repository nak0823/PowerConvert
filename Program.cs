using PowerConvert.Utils;
using System;
using System.Drawing;
using System.Net;

namespace PowerConvert
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = $"{Globals.ToolName} by {Globals.Author} ~ Version {Globals.Version}";
            Interface.PrintArt();
            switch (IsNewestVersion())
            {
                case true:
                    //Interface.Prefix("!", "Program Is Up To Date!\n", Color.Green);
                    break;
                case false:
                    Interface.Prefix("!", "Program Is Outdated. Please Download The Newest Version!\n", Color.Red);
                    break;
            }

            ConfigHelper.DirectoryCheck();
            Menu.MainMenu();


            Console.ReadKey();
        }

        private static bool IsNewestVersion()
        {
            WebClient wc = new WebClient();
            var getVersion = wc.DownloadString("https://raw.githubusercontent.com/nak0823/PowerConvert/master/Version.txt");
            wc.Dispose();
            if (getVersion == Utils.Globals.Version)
                return true;

            return false;
        }
    }
}