using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Services
{
    /// <summary>
    /// GamesRepo
    /// </summary>
    public static class GamesRepo
    {
        private static Dictionary<Guid, Game> activeGames = new Dictionary<Guid, Game>();
        private static Dictionary<int, int> table = new Dictionary<int, int>();

        public static void AddGame(Game game)
        {
            activeGames.Add(game.GameField.Id, game);
        }

        public static Game GetGame(Guid id)
        {
            if (!activeGames.ContainsKey(id))
            {
                return null;
            }
            return activeGames[id];
        }

        public static void RemoveGame(Guid id)
        {
            activeGames.Remove(id);
        }

        public static void AddResults(int level, int score)
        {
            if (table.ContainsKey(level))
            {
                if (table[level] > score)
                    table[level] = score;
            }
            else
            {
                table.Add(level, score);
            }
        }

        public static Dictionary<int, int> GetTable()
        {
            return table;
        }
    }
}