using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.Dto;
using thegame.Services;

namespace thegame.Controllers;

[Route("api/games")]
public class GamesController : Controller
{
    private StateService state;

    public GamesController(StateService state)
    {
        this.state = state;
    }

    [HttpPost]
    public IActionResult Index()
    {
        var testCells = new[]
{
            new CellDto("1", new VectorDto {X = 2, Y = 4}, "target", "", 0),
            new CellDto("2", new VectorDto {X = 5, Y = 4}, "wall", "", 0),
            new CellDto("3", new VectorDto {X = 2, Y = 5}, "box", "", 20),
            new CellDto("4", new VectorDto {X = 1, Y = 0}, "wall", "", 20),
            new CellDto("5", new VectorDto {X = 1, Y = 1}, "player", "☺", 10),
        };
        state.LoadMap(testCells);

        return Ok(state.AGameDto(new VectorDto { X = 1, Y = 1 }));
    }
}