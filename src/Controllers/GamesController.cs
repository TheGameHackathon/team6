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
            GamesRepo.CurrentGame = new TestData();
            return new ObjectResult(GamesRepo.CurrentGame.GameField);
        }
    }
}
