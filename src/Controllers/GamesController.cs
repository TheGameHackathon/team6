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
        public IActionResult Index()
        {
            var stringCells = FileGameLoader.Load("GameData\\2.txt");
            var cells = stringCells.ParsingCells();

            Game game = new Game(cells, stringCells[0].Length, stringCells.Length);
            GamesRepo.AddGame(game);

            return new ObjectResult(game.GameField);
        }
    }
}
