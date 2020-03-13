using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        private const int HEIGHT = 8;
        private const int WIDTH = 10;

        public GameDto GameField { get; }

        public TestData(CellDto[] cells)
        {
            GameField = new GameDto(cells, true, true, WIDTH, HEIGHT, Guid.NewGuid(), false, 0);
        }

        public void MovePlayer(Vec movement)
        {
            CellDto player = GameField.GetPlayer();
            Vec newPosition = player.Pos + movement;
            if (newPosition.X >= WIDTH ||
                newPosition.Y >= HEIGHT ||
                newPosition.X < 0 ||
                newPosition.Y < 0)
            {
                return;
            }
            GameField.MovePlayer(movement);
            
        }
    }
}