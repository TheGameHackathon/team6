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
    private StateService state;

    public MovesController(StateService state)
    {
        this.state = state;
    }


    [HttpPost]
    public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
    {
        var game = state.AGameDto(userInput.ClickedPos ?? new VectorDto() { X = 1, Y = 1});
        if (userInput.ClickedPos != null)
            game.Cells.First(c => c.Type == "player").Pos = userInput.ClickedPos;
        return Ok(game);
    }
}