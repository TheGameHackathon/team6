using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.wwwroot.Enums;

namespace thegame.Models
{
    public static class Extensions
    {
        public static CellType GetCellType(this CellDto cell)
        {
            if (Enum.TryParse(typeof(CellType), cell.Type, ignoreCase: true, out object result))
            {
                return (CellType)result;
            }
            return CellType.Field;
        }

        public static void MovePlayer(this GameDto game, Vec destination)
        {

            CellDto playerCell = game.Cells.FirstOrDefault((CellDto cell) => cell.GetCellType() == CellType.Player);
            if (playerCell != null)
            {
                playerCell.Pos += destination;
            }
        }
    }
}
