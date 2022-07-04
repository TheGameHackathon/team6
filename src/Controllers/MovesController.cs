using System;
using System.Linq;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.Dto;
using thegame.Services;


namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{

    private readonly GameDto game;
    private readonly StateService state;
    private readonly GameUiEventHandler gameUiEventHandler;
    public MovesController(GameDto game, GameUiEventHandler gameUiEventHandler, StateService state)
    {
        this.game = game;
        this.gameUiEventHandler = gameUiEventHandler;
        this.state = state;
    }
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        if (userInput == null)
        {
            return BadRequest();
        }

        if (Enum.IsDefined(typeof(GameUiEventHandler.ArrowKeys), userInput.KeyPressed))
        {
            gameUiEventHandler.HandleKeyPressedEvent(userInput);
        }
        else if (userInput.ClickedPos != null)
        {
            gameUiEventHandler.ChangeGameState(userInput.ClickedPos);
        }
        
        return Ok(game);
    }
}