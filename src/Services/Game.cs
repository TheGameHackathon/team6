using System;
using thegame.Models;

namespace thegame.Services
{
    public class Game
    {
        private const int HEIGHT = 9;
        private const int WIDTH = 8;

        public GameDto GameField { get; }

        public Game(CellDto[] cells)
        {
            GameField = new GameDto(cells, true, true, WIDTH, HEIGHT, Guid.NewGuid(), false, 0);
        }

        public void MovePlayer(Vec movement)
        {
            GameField.MovePlayer(movement);
            GameField.IsFinished = GameField.IsFinished();
            GameField.Score++;
        }
    }
}