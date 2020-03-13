using System;
using thegame.Models;

namespace thegame.Services
{
    public class Game
    {
        public GameDto GameField { get; set; }

        public Game(CellDto[] cells, int width, int height)
        {
            GameField = new GameDto(cells, true, true, width, height, Guid.NewGuid(), false, 0);
        }

        public void MovePlayer(Vec movement)
        {
            GameField.MovePlayer(movement);
            if (GameField.IsFinished())
            {

            }
            GameField.Score++;
        }
    }
}