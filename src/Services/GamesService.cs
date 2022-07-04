using System;
using System.Collections.Generic;
using thegame.Models.Dto;

namespace thegame.Services;

public class GamesService
{
    public Dictionary<Guid, GameState> games = new Dictionary<Guid, GameState>();

    public GameState GetOrCreate(Guid gameId)
    {
        if (games.ContainsKey(gameId))
        {
            return games[gameId];
        } else
        {
            var newGame = new GameState(gameId);
            newGame.LoadMap(GameField.MakeFieldFromString(GameField.TestGameString, out var playerPos));
            games.Add(gameId, newGame);

            return newGame;
        }
    }
}