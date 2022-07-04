using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;


namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    private readonly GameDto game;
    private readonly GameUiEventHandler gameUiEventHandler;
    public MovesController(GameDto game, GameUiEventHandler gameUiEventHandler)
    {
        this.game = game;
        this.gameUiEventHandler = gameUiEventHandler;
    }
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
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