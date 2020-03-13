using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        private const int HEIGHT = 8;
        private const int WIDTH = 10;

        public GameDto GameField { get; private set; }

        public TestData()
        {
            var testCells = new[]
            {
                new CellDto("1", new Vec(2, 4), "color1", "", 0),
                new CellDto("2", new Vec(5, 4), "color1", "", 0),
                new CellDto("3", new Vec(3, 1), "color2", "", 20),
                new CellDto("4", new Vec(1, 0), "color2", "", 20),
                new CellDto("5", new Vec(1, 1), "player", "☺", 10),
            };
            GameField = new GameDto(testCells, true, true, WIDTH, HEIGHT, Guid.Empty, false, 0);
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