using System;
using System.Collections.Generic;
using thegame.Models.Dto;

namespace thegame.Services;

public class GameField
{
    public static readonly string TestGameString = @"
  WWWWW
WWW   W
W.Px  W
WWW x.W
W.WWx W
W W . WW
Wx Xxx.W
W   .  W
WWWWWWWW";

    public static readonly string GameField1 = @"
  WWWWWWW
  W. ...W
WWW W W WWW
W         W
W    x    W
W xxxPxxx W
W    x    W
W         W
WWW W W WWW
  W... .W
  WWWWWWW";
    
    public static readonly string GameField2 = @"
WWWWWWWW
W   x .W
WPWWx  W
WWW  W W
W      W
W W W WW
W     W
W.WWWWW
WWW";
    public static readonly string GameField3 = @"
WWWWWWWWWWWW
W.W.   x  PW
W W    Wx  W
W WWW      W
W      W   W
W W WWWWWWWW
W W        W
W WWWWWWWW W
W        x W
W WWWWWWWWWW
W.W
WWW";

    public static readonly string AutowinGame = @"
WWWWW
WP  W
W X W
WWWWW";
    

    public  static  CellDto[] MakeFieldFromString(string stringField, out VectorDto playerPos)
    {
        playerPos = null;
        var cellsList = new List<CellDto>();
        
        var id = 0;
        var rows = stringField.Split("\n");
        for (int i = 0; i < rows.Length; i++)
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
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "target", "", -1));
                }
                else if (cellChar == 'P')
                {
                    cellsList.Add(new CellDto(id.ToString(), new VectorDto { X = j, Y = i }, "player", "", 10));
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