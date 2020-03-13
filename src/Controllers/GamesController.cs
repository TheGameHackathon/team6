using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    //GAMES CONTROLLER
    [Route("api/games")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index(int level = 1)
        {
            var stringCells = FileGameLoader.Load(level);
            var cells = stringCells.ParsingCells();

            Game game = new Game(cells);
            GamesRepo.AddGame(game);

            return new ObjectResult(game.GameField);
        }

        [Route("levels")]
        [HttpGet]
        public IActionResult Levels()
        {
            return new ObjectResult(FileGameLoader.GetLevelsAmount());
        }
    }
}
