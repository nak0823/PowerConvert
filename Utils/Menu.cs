using System;
using System.Drawing;

namespace PowerConvert.Utils
{
    internal class Menu
    {
        public static void MainMenu()
        {
            Interface.Prefix("!", "Select Your Desired Option\n\n", Color.OrangeRed);
            Interface.Prefix("1", "TikTok\n", Color.OrangeRed);
            Interface.Prefix("2", "YouTube\n", Color.OrangeRed);
            Interface.Prefix("3", "Instagram\n", Color.OrangeRed);
            Interface.Prefix("4", "Facebook\n", Color.OrangeRed);
            Interface.Prefix("5", "Reddit\n", Color.OrangeRed);
            Interface.Prefix("6", "Twitter\n", Color.OrangeRed);
            Interface.Prefix("7", "Snapchat\n", Color.OrangeRed);
            Interface.Prefix("8", "Dailymotion\n", Color.OrangeRed);
            Interface.Prefix("9", "Settings\n", Color.OrangeRed);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    YouTubeMenu();
                    break;
            } 
        }

        public static void YouTubeMenu()
        {
            Console.Clear();
            Console.Title = $"{Globals.ToolName} by {Globals.Author} ~ Version {Globals.Version} -> YouTube Menu";
            Interface.PrintArt();

            Interface.Prefix("!", "Select Your Desired Option\n\n", Color.OrangeRed);
            Interface.Prefix("1", "Convert to Video [MP4]\n", Color.OrangeRed);
            Interface.Prefix("2", "Convert to Audio [MP3]\n", Color.OrangeRed);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Models.YouTube.Convert.ConvertYoutube("https://www.youtube.com/shorts/HHA1s8LAqVs", "mp4");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Models.YouTube.Convert.ConvertYoutube("https://www.youtube.com/shorts/HHA1s8LAqVs", "mp3");
                    break;
            }
        }
    }
}