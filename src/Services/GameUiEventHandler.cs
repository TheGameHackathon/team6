using System;
using System.Linq;
using System.Runtime.CompilerServices;
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
                MoveToBox(new VectorDto(player.Pos.X, player.Pos.Y - 1), 0, -1);
                break;
            case ArrowKeys.Down:
                MoveToBox(new VectorDto(player.Pos.X - 1, player.Pos.Y), -1, 0);
                break;
            case ArrowKeys.Right:
                MoveToBox(new VectorDto(player.Pos.X + 1, player.Pos.Y), 1, 0);
                break;
            case ArrowKeys.Left:
                MoveToBox(new VectorDto(player.Pos.X, player.Pos.Y + 1), 0, 1);
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
    
    private bool CanMoveForBox(VectorDto potentialPos)
    {
        var map = stateService.map;

        return !map.ContainsKey(potentialPos);
    }
    
    private void MoveToBox(VectorDto potentialPos, int deltaX, int deltaY)
    {
        var map = stateService.map;

        if (map.ContainsKey(potentialPos) && (map[potentialPos].Type == "box" || map[potentialPos].Type == "boxOnTarget"))
        { 
            if (CanMoveForBox((new VectorDto(potentialPos.X + deltaX, potentialPos.Y + deltaY))))
            {
                var cellBox = map[potentialPos];
                 if (deltaX == 0)
                     cellBox.Pos.Y += deltaY;
                 else 
                     cellBox.Pos.X += deltaX;
                 
                 map.Remove(potentialPos);
                 map.TryAdd(cellBox.Pos, cellBox);

                 player.Pos.X += deltaX;
                 player.Pos.Y += deltaY;
            }
        }
        else if (CanMove(potentialPos))
        {
            player.Pos.X += deltaX;
            player.Pos.Y += deltaY;
        }
    }

    public VectorDto ChangeGameState(VectorDto clickedPosition)
    {
        // if (clickedPosition != null && CanMove(clickedPosition))
        //     player.Pos = clickedPosition;

        return player.Pos;
    }
}