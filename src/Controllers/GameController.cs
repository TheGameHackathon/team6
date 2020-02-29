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
        
        [HttpGet("init")]
        public IActionResult GetInitialField()
        {
            return Ok(new { });
        }
    }
}
