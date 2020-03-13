using System;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var index = i * width + j;
                    cells[index] = CheckCell(stringCells[i][j], index, j, i);
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
