using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Polytopia.Models;

namespace Polytopia.Controllers
{
    public class HomeController : Controller
    {

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
            // Simulate user login (replace this with actual login logic)
            HttpContext.Session.SetString("UserId", "12345");

            // Simulate user games from session
            var sessionGames = HttpContext.Session.GetString("UserGames")?.Split(',').ToList() ?? new List<string>();

            if (Adjectives == null || Adjectives.Length == 0)
            {
                return StatusCode(500, "Error: Cannot generate game name, as the array is empty.");
            }
            // Generate 5 new random game names
            var random = new Random();
            var generatedGames = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                _logger.LogInformation($"Adjectives count: {Adjectives?.Length ?? 0}");
                string adjective = Adjectives[random.Next(Adjectives.Length)];
                string noun = (random.Next(2) == 0) ? Nouns[random.Next(Nouns.Length)] : FunnyNouns[random.Next(FunnyNouns.Length)];
                generatedGames.Add($"{adjective} {noun}");
            }

            // Merge session games with generated ones
            var allGames = sessionGames.Concat(generatedGames).Distinct().ToList();

            // Store updated games back in session
            HttpContext.Session.SetString("UserGames", string.Join(",", allGames));

            // Pass data to view
            ViewData["GamesList"] = allGames;
            return View();
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
