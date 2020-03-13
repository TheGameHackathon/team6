using System;

namespace thegame.Models
{
    public class GameDto
    {
        public GameDto(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score, int level)
        {
            Cells = cells;
            MonitorKeyboard = monitorKeyboard;
            MonitorMouseClicks = monitorMouseClicks;
            Width = width;
            Height = height;
            Id = id;
            IsFinished = isFinished;
            Score = score;
            Level = level;
        }

        public CellDto[] Cells;
        public int Width;
        public int Height;
        public bool MonitorKeyboard;
        public bool MonitorMouseClicks;
        public Guid Id;
        public bool IsFinished;
        public int Score;
        public int Level;
    }
}