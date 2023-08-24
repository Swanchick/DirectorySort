using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySort
{
    internal class Utils
    {
        public static string GetFileNameFromPath(string path)
        {
            string[] strings = path.Split('\\');

            string fileName = strings[strings.Length - 1];

            return fileName;
        }

        public static string GetExtension(string fileName)
        {
            string[] fileNameSplited = fileName.Split('.');

            if (fileNameSplited.Length == 1) return "";

            return fileNameSplited.Last();
        }
    }
}
