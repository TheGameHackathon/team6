using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }

        [HttpGet("initialField")]
        public IActionResult GetInitialField()
        {
            return Ok("NOPE (");
        }
    }
}
