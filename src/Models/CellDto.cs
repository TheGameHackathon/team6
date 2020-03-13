using System;
using thegame.Enums;
using thegame.wwwroot.Enums;

namespace thegame.Models
{
    public class CellDto
    {
        /// <summary>
        /// Frontend animate transition of the cell from old to new state.
        /// </summary>
        /// <param name="id">Id is used to identificate cell to apply right animation</param>
        /// <param name="pos">Logical position of the cell in the game grid. Upper left corner is `new Vec(0, 0)`</param>
        /// <param name="type">Frontend apply images and other styling to the cell according to this type</param>
        /// <param name="content">Frontend can put this text in the cell</param>
        /// <param name="zIndex">Frontend render cells with higher zIndex above cells with lower zIndex</param>
        public CellDto(string id, Vec pos, string content, int zIndex)
        {
            Id = id;
            Pos = pos;
            Content = content;
            ZIndex = zIndex;
        }

        public CellDto(string id, Vec pos, string content, int zIndex, char cell) : this(id, pos, content, zIndex)
        {
            switch (cell)
            {
                case '.':
                    CellType = CellType.Field;
                    BlockType = BlockType.Empty;
                    Type = "field";
                    break;
                case '#':
                    CellType = CellType.Field;
                    BlockType = BlockType.Wall;
                    Type = "wall";
                    break;
                case 'o':
                    CellType = CellType.Field;
                    BlockType = BlockType.Player;
                    Type = "player";
                    break;
                case '*':
                    CellType = CellType.Field;
                    BlockType = BlockType.Box;
                    Type = "box";
                    break;
                case 'x':
                    CellType = CellType.Target;
                    BlockType = BlockType.Empty;
                    Type = "target";
                    break;
                case '@':
                    CellType = CellType.Target;
                    BlockType = BlockType.Box;
                    Type = "boxOnTarget";
                    break;
                default:
                    throw new ArgumentException("invalid cell");
            }
        }

        public string Id;
        public Vec Pos;
        public int ZIndex;
        public string Type;
        public string Content;
        public BlockType BlockType;
        public CellType CellType;
    }
}