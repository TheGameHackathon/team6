using System;
using System.Collections.Generic;
using thegame.Models.Dto;

namespace thegame.Services;

public class GameField
{
    public readonly string TestGameString = @"
  WWWWW
WWW   W
W.Px  W
WWW x.W
W.WWx W
W W . WW
Wx Xxx.W
W   .  W
WWWWWWWW";

    public CellDto[] MakeFieldFromString(string stringField, out VectorDto playerPos)
    {
        playerPos = null;
        var cellsList = new List<CellDto>();
        var id = 0;
        var rows = stringField.Split("\n");
        for (int i = 0; i < stringField.Length; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                var cellChar = rows[i][j];
                if (cellChar == 'W')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "wall", "", 0));
                }
                else if (cellChar == 'x')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "box", "", 0));
                }
                else if (cellChar == 'X')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "boxOnTarget", "", 0));
                }
                else if (cellChar == '.')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "target", "", 0));
                }
                else if (cellChar == 'P')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "player", "", 0));
                    playerPos = new VectorDto { X = j, Y = i };
                }
                id++;
            }
        }

        if (playerPos == null)
            throw new ArgumentException("String doesn't have player position (P)");
        return cellsList.ToArray();
    }
}