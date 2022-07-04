using System;
using System.Linq;
using thegame.Models;

namespace thegame.Services;

public class GameUiEventHandler
{
    private readonly CellDto player;
    public GameUiEventHandler(CellDto player)
    {
        this.player = player;
    }
    
    public enum ArrowKeys
    {
        Up = 38, 
        Down = 37,
        Right = 39,
        Left = 40
    }

    public void HandleKeyPressedEvent(UserInputDto userInput)
    {
        var arrowKey = (ArrowKeys)userInput.KeyPressed;
        switch (arrowKey)
        {
            case ArrowKeys.Up:
                player.Pos.X += 1;
                break;
            case ArrowKeys.Down:
                player.Pos.X -= 1;
                break;
            case ArrowKeys.Right:
                player.Pos.Y += 1;
                break;
            case ArrowKeys.Left:
                player.Pos.Y -= 1;
                break;
            default:
                break;
        }
    }

    public void ChangeGameState(VectorDto clickedPosition)
    {
        if (clickedPosition != null)
            player.Pos = clickedPosition;
    }
}