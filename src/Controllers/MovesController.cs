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
    private readonly GamesService gamesService;
    public MovesController(GamesService gamesService)
    {
        this.gamesService = gamesService;
    }
    
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        var gameState = gamesService.GetOrCreate(gameId);
        var gameUiEventHandler = new GameUiEventHandler(gameState);
        
        if (userInput == null)
        {
            return BadRequest();
        }

        var playerVector = new VectorDto() {X = 1, Y = 1};
        if (Enum.IsDefined(typeof(GameUiEventHandler.ArrowKeys), userInput.KeyPressed))
        {
            playerVector = gameUiEventHandler.HandleKeyPressedEvent(userInput);
        }
        else if (userInput.ClickedPos != null)
        { 
            playerVector = gameUiEventHandler.ChangeGameState(userInput.ClickedPos);
        }


        return Ok(gameState.AGameDto(playerVector));
    }
}