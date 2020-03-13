using System;
using thegame.Models;

namespace thegame.Services
{
    public class Game
    {
        public GameDto GameField { get; }

        public Game(CellDto[] cells, int width, int height, int level)
        {
            GameField = new GameDto(cells, true, true, width, height, Guid.NewGuid(), false, 0, level);
        }

        public void MovePlayer(Vec movement)
        {
            GameField.MovePlayer(movement);
            GameField.IsFinished = GameField.IsFinished();
            GameField.Score++;
            if(GameField.IsFinished)
                GamesRepo.AddResults(GameField.Level, GameField.Score);
        }
    }
}