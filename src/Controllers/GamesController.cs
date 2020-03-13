using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Providers;
using thegame.Services;

namespace thegame.Controllers
{
    //GAMES CONTROLLER
    [Route("api/games")]
    public class GamesController : Controller
    {
        private IGameDataLoader gameDataLoader;

        public GamesController(IGameDataLoader gameDataLoader)
        {
            this.gameDataLoader = gameDataLoader;
        }

        [HttpPost]
        public IActionResult Index([FromBody] int levelNumber = 1)
        {
            var stringCells = gameDataLoader.Load(levelNumber);
            var cells = stringCells.ParsingCells();

            Game game = new Game(cells, stringCells[0].Length, stringCells.Length);
            
            GamesRepo.AddGame(game);

            return new ObjectResult(game.GameField);
        }

        [Route("levels")]
        [HttpGet]
        public IActionResult Levels()
        {
            return new ObjectResult(gameDataLoader.GetLevelsAmount());
        }
    }
}
