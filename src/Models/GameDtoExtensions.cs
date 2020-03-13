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
        public static BlockType GetBlockType(this CellDto cell)
        {
            return cell.BlockType;
            //    if (Enum.TryParse(typeof(BlockType), cell.Type, ignoreCase: true, out object result))
            //    {
            //        return (CellType)result;
            //    }
            //    return CellType.Field;
            //}
        }

        public static CellDto GetPlayer(this GameDto game)
        {
            return game.Cells.FirstOrDefault((CellDto cell) => cell.GetBlockType() == BlockType.Player);
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
