using System;
using System.Linq;
using thegame.Models;
using thegame.Models.Dto;

namespace thegame.Services;

public class GameUiEventHandler
{
    private readonly CellDto player;
    //private readonly StateService stateService;
    public GameUiEventHandler(GameState stateService)
    {
        this.player = stateService.player;
    }
    
    public enum ArrowKeys
    {
        Up = 38, 
        Down = 37,
        Right = 39,
        Left = 40
    }

    public VectorDto HandleKeyPressedEvent(UserInputDto userInput)
    {
        var arrowKey = (ArrowKeys)userInput.KeyPressed;
        switch (arrowKey)
        {
            case ArrowKeys.Up:
                player.Pos.Y -= 1;
                break;
            case ArrowKeys.Down:
                player.Pos.X -= 1;
                break;
            case ArrowKeys.Right:
                player.Pos.X += 1;
                break;
            case ArrowKeys.Left:
                player.Pos.Y += 1;
                break;
            default:
                break;
        }

        return player.Pos;
    }

    public VectorDto ChangeGameState(VectorDto clickedPosition)
    {
        if (clickedPosition != null)
            player.Pos = clickedPosition;

        return player.Pos;
    }
}