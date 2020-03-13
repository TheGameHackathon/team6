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

        public MovesController(IMoveProvider provider)
        {
            moveProvider = provider;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = GamesRepo.GetGame(gameId);
            game.MovePlayer(moveProvider.GetMovement(userInput));
            return new ObjectResult(game.GameField);
        }
    }
}