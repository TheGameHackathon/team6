using System;
using System.Linq;
using thegame.Models;
using thegame.Models.Dto;

namespace thegame.Services;

public class GameUiEventHandler
{
    private readonly CellDto player;
    private readonly GameState stateService;
    public GameUiEventHandler(GameState stateService)
    {
        this.stateService = stateService;
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
                if (CanMove(new VectorDto(player.Pos.X, player.Pos.Y - 1))) 
                    player.Pos.Y -= 1;
                break;
            case ArrowKeys.Down:
                if (CanMove(new VectorDto(player.Pos.X - 1, player.Pos.Y))) 
                    player.Pos.X -= 1;
                break;
            case ArrowKeys.Right:
                if (CanMove(new VectorDto(player.Pos.X + 1, player.Pos.Y))) 
                    player.Pos.X += 1;
                break;
            case ArrowKeys.Left:
                if (CanMove(new VectorDto(player.Pos.X, player.Pos.Y + 1))) 
                    player.Pos.Y += 1;
                break;
            default:
                break;
        }

        return player.Pos;
    }

    private bool CanMove(VectorDto potentialPos)
    {
        var map = stateService.map;

        if (map.ContainsKey(potentialPos))
        {
            return map[potentialPos].Type != "wall";   
        }

        return true;
    }

    public VectorDto ChangeGameState(VectorDto clickedPosition)
    {
        if (clickedPosition != null && CanMove(clickedPosition))
            player.Pos = clickedPosition;

        return player.Pos;
    }
}