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
            return new CellDto(id.ToString(), new Vec(x, y), "", 0, cell);
        }

    }
}
