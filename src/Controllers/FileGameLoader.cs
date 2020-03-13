using System;
using System.IO;

namespace thegame.Controllers
{
    class FileGameLoader
    {
        private const string GAME_DATA_PATH = @"GameData";

        private static string GameDataPathFormat => GAME_DATA_PATH + @"\{0}.txt";

        public static string[] Load(int level)
        {
            var filename = GetFileNameByLevel(level);

            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException();

            if(!File.Exists(filename))
                throw new FileNotFoundException();

            return File.ReadAllLines(filename);
        }

        public static int GetLevelsAmount()
        {
            return Directory.GetFiles(string.Format(GAME_DATA_PATH)).Length;
        }

        private static string GetFileNameByLevel(int level)
        {
            return string.Format(GameDataPathFormat, level);
        }
    }
}
