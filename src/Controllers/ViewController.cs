using Microsoft.AspNetCore.Mvc;
using System;
using thegame.Models;
using thegame.Models.Dto;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/view")]
public class ViewController : Controller
{
    private GamesService games;

    public ViewController(GamesService games)
    {
        this.games = games;
    }

    [HttpGet("{gameId}")]
    public IActionResult View([FromRoute] Guid gameId)
    {
        var game = games.GetOrNull(gameId);

        if (game == null)
        {
            return NotFound();
        }

        return Ok(game.AGameDto());

    }
}