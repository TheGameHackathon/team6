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
        /*var testCells = new[]
{
            new CellDto("1", new VectorDto {X = 3, Y = 0}, "wall", "", 0),
            new CellDto("2", new VectorDto {X = 4, Y = 0}, "wall", "", 0),
            new CellDto("3", new VectorDto {X = 5, Y = 0}, "wall", "", 0),
            new CellDto("4", new VectorDto {X = 6, Y = 0}, "wall", "", 0),
            new CellDto("5", new VectorDto {X = 7, Y = 0}, "wall", "", 0),
            new CellDto("6", new VectorDto {X = 8, Y = 0}, "wall", "", 0),
            new CellDto("7", new VectorDto {X = 1, Y = 1}, "wall", "", 0),
            new CellDto("8", new VectorDto {X = 2, Y = 1}, "wall", "", 0),
            new CellDto("9", new VectorDto {X = 3, Y = 1}, "wall", "", 0),
            new CellDto("10", new VectorDto {X = 8, Y = 1}, "wall", "", 0),
            new CellDto("11", new VectorDto {X = 1, Y = 2}, "wall", "", 0),
            new CellDto("12", new VectorDto {X = 3, Y = 2}, "player", "", 10),
            new CellDto("13", new VectorDto {X = 1, Y = 3}, "wall", "", 0),
            new CellDto("14", new VectorDto {X = 1, Y = 4}, "wall", "", 0),
            new CellDto("15", new VectorDto {X = 1, Y = 5}, "wall", "", 0),
            new CellDto("16", new VectorDto {X = 1, Y = 6}, "wall", "", 0),
            new CellDto("17", new VectorDto {X = 1, Y = 7}, "wall", "", 0),
            new CellDto("18", new VectorDto {X = 1, Y = 8}, "wall", "", 0),
            new CellDto("19", new VectorDto {X = 2, Y = 8}, "wall", "", 0),
            new CellDto("20", new VectorDto {X = 3, Y = 8}, "wall", "", 0),
            new CellDto("21", new VectorDto {X = 4, Y = 8}, "wall", "", 0),
            new CellDto("22", new VectorDto {X = 5, Y = 8}, "wall", "", 0),
            new CellDto("23", new VectorDto {X = 6, Y = 8}, "wall", "", 0),
            new CellDto("24", new VectorDto {X = 7, Y = 8}, "wall", "", 0),
            new CellDto("25", new VectorDto {X = 8, Y = 8}, "wall", "", 0),
            new CellDto("26", new VectorDto {X = 8, Y = 1}, "wall", "", 0),
            new CellDto("27", new VectorDto {X = 8, Y = 2}, "wall", "", 0),
            new CellDto("28", new VectorDto {X = 8, Y = 3}, "wall", "", 0),
            new CellDto("29", new VectorDto {X = 8, Y = 4}, "wall", "", 0),
            new CellDto("30", new VectorDto {X = 8, Y = 5}, "wall", "", 0),
            new CellDto("31", new VectorDto {X = 8, Y = 6}, "wall", "", 0),
            new CellDto("32", new VectorDto {X = 8, Y = 7}, "wall", "", 0),
            new CellDto("33", new VectorDto {X = 2, Y = 2}, "target", "", -1),
            new CellDto("34", new VectorDto {X = 6, Y = 3}, "target", "", -1),
            new CellDto("35", new VectorDto {X = 2, Y = 4}, "target", "", -1),
            new CellDto("36", new VectorDto {X = 5, Y = 5}, "target", "", -1),
            new CellDto("37", new VectorDto {X = 2, Y = 3}, "wall", "", 0),
            new CellDto("38", new VectorDto {X = 3, Y = 3}, "wall", "", 0),
            new CellDto("39", new VectorDto {X = 3, Y = 4}, "wall", "", 0),
            new CellDto("40", new VectorDto {X = 3, Y = 5}, "wall", "", 0),
            new CellDto("41", new VectorDto {X = 4, Y = 4}, "wall", "", 0),
            new CellDto("42", new VectorDto {X = 4, Y = 2}, "box", "", 0),
            new CellDto("43", new VectorDto {X = 5, Y = 3}, "box", "", 0),
            new CellDto("44", new VectorDto {X = 5, Y = 4}, "box", "", 0),
            new CellDto("45", new VectorDto {X = 2, Y = 6}, "box", "", 0),
            new CellDto("46", new VectorDto {X = 4, Y = 6}, "box", "", 0),
            new CellDto("47", new VectorDto {X = 5, Y = 6}, "box", "", 0),
            new CellDto("48", new VectorDto {X = 6, Y = 6}, "box", "", 0),
            new CellDto("49", new VectorDto {X = 7, Y = 6}, "target", "", -1),
            new CellDto("50", new VectorDto {X = 5, Y = 7}, "target", "", -1),
        };*/
        var testCells = GameField.MakeFieldFromString(GameField.TestGameString, out var playerPos);
        state.LoadMap(testCells);
        return Ok(state.AGameDto(playerPos));
    }
}