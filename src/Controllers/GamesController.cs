using Microsoft.AspNetCore.Mvc;
using System;
using thegame.Models;
using thegame.Models.Dto;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games/{level}")]
public class GamesController : Controller
{
    private GamesService games;

    public GamesController(GamesService games)
    {
        this.games = games;
    }

    [HttpPost]
    public IActionResult Index([FromRoute]string level)
    {
        var game = games.GetOrCreate(Guid.NewGuid(), level);
        return Ok(game.AGameDto());
    }
}