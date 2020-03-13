using System;
using thegame.Models;

namespace thegame.Services
{
    public static class Parsing
    {

        public static CellDto[] ParsingCells(this string[] stringCells)
        {
            if(stringCells == null)
                throw  new NullReferenceException(nameof(stringCells));

            if(stringCells.Length == 0)
                throw new ArgumentException("Array of string cells can't be empty");

            var height = stringCells.Length;
            var width = stringCells[0].Length;

            var cells = new CellDto[height * width];
            var index = 0;
            for (var i = 0; i < stringCells.Length; i++)
            {
                for (var j = 0; j < stringCells[i].Length; j++)
                {
                    cells[index] = CheckCell(stringCells[i][j], i + j, j, i);
                    index++;
                }
            }

            return cells;
        }

        private static CellDto CheckCell(char cell, int id, int x, int y)
        {
            switch (cell)
            {
                case '.':
                    return new CellDto(id.ToString(), new Vec(x, y), "field", "", 0);
                case '#':
                    return new CellDto(id.ToString(), new Vec(x, y), "wall", "", 0);
                case 'o':
                    return new CellDto(id.ToString(), new Vec(x, y), "player", "", 0);
                case '*':
                    return new CellDto(id.ToString(), new Vec(x, y), "box", "", 0);
                case 'x':
                    return new CellDto(id.ToString(), new Vec(x, y), "target", "", 0);
                case '@':
                    return new CellDto(id.ToString(), new Vec(x, y), "boxOnTarget", "", 0);
                default:
                    throw  new ArgumentException("invalid cell");
            }
        }

    }
}
