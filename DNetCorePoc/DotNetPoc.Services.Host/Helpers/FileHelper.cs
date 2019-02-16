using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DotNetPoc.Services.Host.Helpers
{
    public static class FileHelper
    {
        public static void WriteToFile(byte[] file, string fileName)
        {
            File.WriteAllBytes(fileName, file);
        }

        public static string CurrentDirrectory(string location)
        {
            return Path.GetDirectoryName(location);
        }
        public static string GetFileName(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }
    }
}
