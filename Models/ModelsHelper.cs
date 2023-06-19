using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PowerConvert.Models
{
    internal class ModelsHelper
    {
        public static string ParseToken(string content, string leftString, string rightString)
        {
            var returnThis = content.Split(new string[] { leftString }, StringSplitOptions.None)[1];
            returnThis = returnThis.Split(new string[] { rightString }, StringSplitOptions.None)[0];
            return returnThis;
        }

        public static string DirectoryFound(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            } 

            return path;
        }

        public static string ToValidName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            string validFileName = Regex.Replace(name , invalidReStr, "_");
            return validFileName;
        }
    }
}
