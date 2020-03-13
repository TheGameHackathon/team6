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
            var stringCells = FileGameLoader.Load("GameData\\1.txt");
            var cells = stringCells.ParsingCells();

            GamesRepo.CurrentGame = new TestData(cells);

            return new ObjectResult(GamesRepo.CurrentGame.GameField);
        }
    }
}
