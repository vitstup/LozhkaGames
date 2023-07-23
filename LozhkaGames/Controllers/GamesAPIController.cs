using LozhkaGames.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LozhkaGames.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesAPIController : ControllerBase
    {
        private readonly IGamesRepository gamesRepository;

        public GamesAPIController(IGamesRepository gamesRepository)
        {
            this.gamesRepository = gamesRepository;
        }

        [HttpGet("GetAllGames")]
        public IActionResult GetAllGames() 
        {
            var games = gamesRepository.GetAllGames();

            return Ok(games);
        }

        [HttpGet("GetGameById{id}")]
        public IActionResult GetGameById(int id)
        {
            var game = gamesRepository.GetGameById(id);

            if (game != null) return Ok(game);
            else return NotFound();
        }
    }
}
