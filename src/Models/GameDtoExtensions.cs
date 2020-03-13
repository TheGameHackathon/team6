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

        public static CellDto GetPlayer(this GameDto game)
        {
            return game.Cells.FirstOrDefault((CellDto cell) => cell.GetCellType() == CellType.Player);
        }

        public static void MovePlayer(this GameDto game, Vec movement)
        {
            CellDto playerCell = game.GetPlayer();
            if (playerCell != null)
            {
                playerCell.Pos += movement;
            }
        }
    }
}
