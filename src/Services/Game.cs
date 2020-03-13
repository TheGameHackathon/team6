using System;
using thegame.Models;

namespace thegame.Services
{
    public class Game
    {
        public GameDto GameField { get; }

        public Game(CellDto[] cells, int width, int height)
        {
            GameField = new GameDto(cells, true, true, width, height, Guid.NewGuid(), false, 0);
        }

        public void MovePlayer(Vec movement)
        {
            GameField.MovePlayer(movement);
            GameField.IsFinished = GameField.IsFinished();
            GameField.Score++;
        }
    }
}