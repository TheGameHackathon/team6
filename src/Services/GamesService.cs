using System;
using System.Collections.Generic;
using thegame.Models.Dto;

namespace thegame.Services;

public class GamesService
{
    public Dictionary<Guid, GameState> games = new Dictionary<Guid, GameState>();

    public GameState GetOrCreate(Guid gameId, string level = "Level1")
    {
        if (games.ContainsKey(gameId))
        {
            return games[gameId];
        } 
        else
        {
            var newGame = new GameState(gameId);
            var field = level switch
            {
                "Level1" => GameField.TestGameString,
                "Level2" => GameField.GameField1,
                "Level3" => GameField.GameField2,
                "Level4" => GameField.GameField3,
                _ => GameField.TestGameString
            };
            newGame.LoadMap(GameField.MakeFieldFromString(field, out var playerPos));
            games.Add(gameId, newGame);

            return newGame;
        }
    }

    public GameState GetOrNull(Guid gameId)
    {
        if (games.ContainsKey(gameId))
        {
            return games[gameId];
        }

        return null;

    }
}