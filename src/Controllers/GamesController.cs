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
        private IParsingCellsService parsingService;

        public GamesController(IGameDataLoader gameDataLoader, IParsingCellsService parsingService)
        {
            this.gameDataLoader = gameDataLoader;
            this.parsingService = parsingService;
        }

        [HttpPost]
        public IActionResult Index([FromBody] int levelNumber = 1)
        {
            var stringCells = gameDataLoader.Load(levelNumber);
            var cells = parsingService.Parse(stringCells);

            Game game = new Game(cells, stringCells[0].Length, stringCells.Length, levelNumber);
            GamesRepo.AddGame(game);

            return new ObjectResult(game.GameField);
        }

        [Route("levels")]
        [HttpGet]
        public IActionResult Levels()
        {
            return new ObjectResult(gameDataLoader.GetLevelsAmount());
        }

        [Route("leaderboard")]
        [HttpGet]
        public IActionResult Leaderboard()
        {
            return new ObjectResult(GamesRepo.GetTable());
        }
    }
}
