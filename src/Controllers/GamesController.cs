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
            //GamesRepo.CurrentGame = new TestData();
            //return new ObjectResult(GamesRepo.CurrentGame.GameField);
            var stringCells = FileGameLoader.Load("GameData\\1.txt");
            var cells = stringCells.ParsingCells();

             var game = new GameDto(cells, true, true, 8, 9, Guid.Empty, false, 0);

            return new ObjectResult(game);
        }
    }
}
