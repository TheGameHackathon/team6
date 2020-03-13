using System;
using System.Linq;
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
            this.moveProvider = provider;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = TestData.AGameDto(moveProvider.GetMovement(userInput));
            game.MovePlayer(moveProvider.GetMovement(userInput));
            return new ObjectResult(game);
        }
    }
}