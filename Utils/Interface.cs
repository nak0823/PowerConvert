using System;
using Console = Colorful.Console;
using System.Drawing;

namespace PowerConvert.Utils
{
    internal class Interface
    {

        /// <summary>
        /// Prints the main interface logo.
        /// </summary>
        private static readonly string ArtString1 = "    ____                          ______                           __ ";
        private static readonly string ArtString2 = "   / __ \\____ _      _____  _____/ ____/___  ____ _   _____  _____/ /_";
        private static readonly string ArtString3 = "  / /_/ / __ \\ | /| / / _ \\/ ___/ /   / __ \\/ __ \\ | / / _ \\/ ___/ __/";
        private static readonly string ArtString4 = " / ____/ /_/ / |/ |/ /  __/ /  / /___/ /_/ / / / / |/ /  __/ /  / /_  ";
        private static readonly string ArtString5 = "/_/    \\____/|__/|__/\\___/_/   \\____/\\____/_/ /_/|___/\\___/_/   \\__/  ";

        private static readonly string CreditsString =
            $"{Globals.ToolName} by {Globals.Author} ~ Version {Globals.Version}";

        public static void PrintArt()
        {
            Console.CursorVisible = false;
            int WidthSum = (Console.WindowWidth - ArtString1.Length) / 2;
            int CredisWidthSum = (Console.WindowWidth - CreditsString.Length) / 2;
            int TopSum = Console.CursorTop;

            Console.SetCursorPosition(WidthSum, TopSum++);
            Console.WriteLine(ArtString1, Color.OrangeRed);
            Console.SetCursorPosition(WidthSum, TopSum++);
            Console.WriteLine(ArtString2, Color.OrangeRed);
            Console.SetCursorPosition(WidthSum, TopSum++);
            Console.WriteLine(ArtString3, Color.OrangeRed);
            Console.SetCursorPosition(WidthSum, TopSum++);
            Console.WriteLine(ArtString4, Color.OrangeRed);
            Console.SetCursorPosition(WidthSum, TopSum++);
            Console.WriteLine(ArtString5, Color.OrangeRed);

            Console.SetCursorPosition(CredisWidthSum, TopSum);
            Console.Write(Globals.ToolName, Color.OrangeRed);
            Console.Write(" by ", Color.White);
            Console.Write(Globals.Author, Color.OrangeRed);
            Console.Write(" ~", Color.White);
            Console.Write(" Version ", Color.OrangeRed);
            Console.Write(Globals.Version +"\n\n", Color.White);
        }

        public static void Prefix(string prefix, string msg, Color color)
        {
            Console.Write(" {", color);
            Console.Write(prefix, Color.White);
            Console.Write("} ", color);
            Console.Write(msg, color);
        }

    }
}
