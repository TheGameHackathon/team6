using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{gameId}/moves")]
public class MovesController : Controller
{
    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
    {
        if (userInput == null)
        {
            return BadRequest();
        }

        if (userInput.KeyPressed != null)
        {
            GameUiEventHandler.HandleKeyPressedEvent(userInput);
        }
        /*var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
        if (userInput.ClickedPos != null)
            game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;*/
        
        return Ok(GameUiEventHandler.CreateGame(userInput.ClickedPos));
    }
}