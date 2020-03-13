using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Providers;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private IMoveProvider moveProvider;
        private IGameDataLoader gameDataLoader;
        private IParsingCellsService parsingService;

        public MovesController(IMoveProvider provider, IGameDataLoader gameDataLoader, IParsingCellsService parsingService)
        {
            this.gameDataLoader = gameDataLoader;
            this.parsingService = parsingService;
            moveProvider = provider;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = GamesRepo.GetGame(gameId);
            game.MovePlayer(moveProvider.GetMovement(userInput));

            if (game.GameField.IsFinished)
            {
                GameDto gameField = game.GameField;
                try
                {
                    var stringCells = gameDataLoader.Load(game.GameField.Level + 1);
                    var cells = parsingService.Parse(stringCells);
                    game.GameField = new GameDto(cells, true, true, game.GameField.Width, game.GameField.Height, gameId,
                        false, 0, game.GameField.Level + 1);
                }
                catch
                {
                    game.GameField = gameField;
                }
            }
            return new ObjectResult(game.GameField);
        }
    }
}