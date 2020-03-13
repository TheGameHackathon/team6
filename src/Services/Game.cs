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
            CellDto player = GameField.GetPlayer();
            //Vec newPosition = player.Pos + movement;
            //if (newPosition.X >= WIDTH ||
            //    newPosition.Y >= HEIGHT ||
            //    newPosition.X < 0 ||
            //    newPosition.Y < 0)
            //{
            //    return;
            //}
            GameField.MovePlayer(movement);

        }
    }
}