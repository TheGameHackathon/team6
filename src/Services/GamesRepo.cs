using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace thegame.Services
{
    /// <summary>
    /// GamesRepo
    /// </summary>
    public static class GamesRepo
    {
        private static Dictionary<Guid, TestData> activeGames = new Dictionary<Guid, TestData>();

        public static void AddGame(TestData game)
        {
            activeGames.Add(game.GameField.Id, game);
        }

        public static TestData GetGame(Guid id)
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
    }
}