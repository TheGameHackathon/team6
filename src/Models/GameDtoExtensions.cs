using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Enums;
using thegame.wwwroot.Enums;

namespace thegame.Models
{
    public static class Extensions
    {
        public static CellDto GetPlayer(this GameDto game)
        {
            return game.Cells.FirstOrDefault(cell => cell.BlockType == BlockType.Player);
        }

        public static void MovePlayer(this GameDto game, Vec movement)
        {
            CellDto playerCell = game.GetPlayer();
            if (playerCell != null)
            {
                playerCell.Pos += movement;
            }
        }

        public static bool IsFinished(this GameDto game)
        {
            if(game == null)
                throw new ArgumentNullException("Wrong game parameter.");

            return CellsWithType(game, CellType.Target).All(cell => cell.BlockType == BlockType.Box);
        }

        public static IEnumerable<CellDto> EmptyCells(this GameDto game)
        {
            return CellsWithBlock(game, BlockType.Empty);
        }

        public static IEnumerable<CellDto> CellsWithBlock(this GameDto game, BlockType blockType)
        {
            return game.Cells.Where(cell => cell.BlockType == blockType);
        }

        public static IEnumerable<CellDto> CellsWithType(this GameDto game, CellType cellType)
        {
            return game.Cells.Where(cell => cell.CellType == cellType);
        }
    }
}
