using System;
using System.IO;

namespace thegame.Controllers
{
    class FileGameLoader
    {
        public static string[] Load(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException();

            if(!File.Exists(filename))
                throw new FileNotFoundException();

            return File.ReadAllLines(filename);
        }
    }
}
