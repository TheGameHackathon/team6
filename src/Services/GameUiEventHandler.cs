using System;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public static class GameUiEventHandler
{
    enum ArrowKeys
    {
        Up = 38, 
        Down = 37,
        Right = 39,
        Left = 40
    }

    public static void HandleKeyPressedEvent(UserInputDto userInput)
    {
        userInput.ClickedPos = new VectorDto {X = 1, Y = 1};
        var arrowKey = (ArrowKeys)userInput.KeyPressed;
        switch (arrowKey)
        {
            case ArrowKeys.Up:
                userInput.ClickedPos.Y += 1;
                break;
            case ArrowKeys.Down:
                userInput.ClickedPos.Y -= 1;
                break;
            case ArrowKeys.Right:
                userInput.ClickedPos.X += 1;
                break;
            case ArrowKeys.Left:
                userInput.ClickedPos.X -= 1;
                break;
            default:
                break;
        }
    }

    public static GameDto CreateGame(VectorDto clickedPosition)
    {
        var game = TestData.AGameDto(clickedPosition ?? new VectorDto {X = 1, Y = 1});
        
        if (clickedPosition != null)
            game.Cells.First(c => c.Type == "color4").Pos = clickedPosition;

        return game;
    }
}