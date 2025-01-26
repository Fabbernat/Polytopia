using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Polytopia.Models;

namespace Polytopia.Controllers
{
    public class HomeController : Controller
    {
        private const string SessionGamesList = "GamesList"; // Session key

        private static readonly string[] Adjectives = {
    "Majestic", "Noble", "Grand", "Sovereign", "Sacred", "Eldritch", "Immortal", "Daring",
    "Brave", "Fearless", "Vigilant", "Swift", "Ferocious", "Tenacious", "Mighty", "Enchanted", "Radiant",
    "Legendary", "Mysterious", "Enigmatic", "Mythical", "Cosmic", "Ruthless", "Hidden",
    "Luminous", "Arcane", "Cursed", "Of", "The", "And", "Eternal", "Galactic", "Heroic", "Valiant",
    "Fierce", "Colossal", "Serene", "Vast",
};

        private static readonly string[] Nouns = {
    "Kingdom", "Realm", "Empire", "Odyssey", "Quest", "Legends", "Adventures", "Heroes",
    "Warriors", "Guardians", "Titans", "Conquest", "Destiny", "Prophecy", "Infinity", "Rebellion",
    "Revolution", "Frontier", "Dominion", "Legacy", "Valor", "Mysteries", "Ascension", "Chronicles",
    "Myths", "Enigma", "Lore", "Epic", "Saga", "Pinnacle",
};

        private static readonly string[] FunnyNouns = {
    "Spaghetti", "Eggs", "Cheese", "Dragons", "Moonies", "Knights",
    "Unicorns", "Penguins", "Robots", "Bananas", "Clouds", "Stars",
    "Dinosaurs", "Zombies", "Pirates", "Ninjas", "Fairies", "Squirrels",
    "Jellyfish", "Octopi", "Aliens", "Mushrooms", "Butterflies", "Rainbows"
};

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Retrieve games list from session or initialize if empty
            var gamesList = HttpContext.Session.GetObjectFromJson<List<string>>(SessionGamesList) ?? new List<string>();

            // Pass games list to ViewData
            ViewData["GamesList"] = gamesList;
            return View();
        }

        [HttpPost]
        public IActionResult CreateGame()
        {
            var gamesList = HttpContext.Session.GetObjectFromJson<List<string>>(SessionGamesList) ?? new List<string>();

            // Generate a unique game name (Example: "Game #1", "Game #2", etc.)
            int newGameNumber = gamesList.Count + 1;
            gamesList.Add($"Game #{newGameNumber}");

            // Save updated list to session
            HttpContext.Session.SetObjectAsJson(SessionGamesList, gamesList);

            // Redirect back to index
            return RedirectToAction("Index");
        }
        

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult HallOfFame()
        {
            return View();
        }

        public IActionResult ThroneRoom()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult GetUserGames()
        {
            var games = HttpContext.Session.GetString("UserGames")?.Split(",") ?? new string[0];
            return Json(games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
