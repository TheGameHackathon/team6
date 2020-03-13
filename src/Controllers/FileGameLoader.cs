using System;
using System.IO;
using thegame.Providers;

namespace thegame.Controllers
{
    class FileGameLoader : IGameDataLoader
    {
        private const string GAME_DATA_PATH = @"GameData";

        private string GameDataPathFormat => GAME_DATA_PATH + @"\{0}.txt";

        public string[] Load(int level)
        {
            var filename = GetFileNameByLevel(level);

            if (string.IsNullOrEmpty(filename))
                throw new ArgumentException();

            if(!File.Exists(filename))
                throw new FileNotFoundException();

            return File.ReadAllLines(filename);
        }

        public int GetLevelsAmount()
        {
            return Directory.GetFiles(string.Format(GAME_DATA_PATH)).Length;
        }

        private string GetFileNameByLevel(int level)
        {
            return string.Format(GameDataPathFormat, level);
        }
    }
}
