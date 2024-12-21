using Microsoft.AspNetCore.Mvc;
using Polytopia.Models;

namespace BattleOfPolytopia.Controllers
{
    public class GameController : Controller
    {
        private static Game _currentGame = null;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartGame(string username, int botCount, string difficulty)
        {
            _currentGame = new Game
            {
                Username = username,
                BotCount = botCount,
                Difficulty = difficulty
            };

            _currentGame.AssignRandomBotTribes();
            _currentGame.GenerateMap();

            return RedirectToAction("Play");
        }

        [HttpGet]
        public IActionResult Play()
        {
            if (_currentGame == null)
            {
                return RedirectToAction("Index");
            }

            return View(_currentGame);
        }
    }
}
