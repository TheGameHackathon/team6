using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using thegame.Enums;
using thegame.wwwroot.Enums;

namespace thegame.Models
{
    public static class Extensions
    {
        private static int next = 10000;
        public static CellDto GetPlayer(this GameDto game)
        {
            return game.Cells.FirstOrDefault(cell => cell.BlockType == BlockType.Player);
        }

        public static CellDto GetCellByPosition(this GameDto game, Vec position)
        {
            return game.Cells.FirstOrDefault((CellDto cell) => cell.Pos == position);
        }

        public static void UpdateBlockType(this CellDto cell, BlockType newType)
        {
            cell.BlockType = newType;
            cell.Type = newType == BlockType.Empty ? 
                cell.CellType.ToString().ToLower() :
                cell.BlockType.ToString().ToLower();
            if (cell.CellType == CellType.Target && cell.BlockType == BlockType.Box)
            {
                cell.Type = "boxOnTarget";
            }
        }

        public static void MovePlayer(this GameDto game, Vec movement)
        {
            CellDto fromCell = game.GetPlayer();
            if (fromCell != null)
            {
                Vec newPosition = fromCell.Pos + movement;
                CellDto toCell = game.GetCellByPosition(newPosition);
                if (toCell != null)
                {
                    switch (toCell.BlockType)
                    {
                        case BlockType.Empty:
                            toCell.UpdateBlockType(BlockType.Player);
                            fromCell.UpdateBlockType(BlockType.Empty);
                            toCell.Id = fromCell.Id;
                            fromCell.Id = (next++).ToString();
                            break;
                        case BlockType.Box:
                            Vec nextPosition = newPosition + movement;
                            CellDto nextCell = game.GetCellByPosition(nextPosition);
                            if (nextCell != null && nextCell.BlockType == BlockType.Empty)
                            {
                                nextCell.UpdateBlockType(BlockType.Box);
                                toCell.UpdateBlockType(BlockType.Player);
                                fromCell.UpdateBlockType(BlockType.Empty);
                                nextCell.Id = toCell.Id;
                                toCell.Id = fromCell.Id;
                                fromCell.Id = (next++).ToString();
                            }
                            break;
                    }
                }
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
