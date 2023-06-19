using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConvert.Utils
{
    internal class ConfigHelper
    {
        public static void DirectoryCheck()
        {
            string[] services =
                { "TikTok", "YouTube", "Instagram", "Facebook", "Reddit", "Twitter", "Snapchat", "Dailymotion" };

            foreach (string service in services)
            {
                if (!Directory.Exists($"Downloads\\{service}"))
                    Directory.CreateDirectory($"Downloads\\{service}");
            }
        }
    }
}
