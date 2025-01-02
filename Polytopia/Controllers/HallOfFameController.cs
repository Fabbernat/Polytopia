using Microsoft.AspNetCore.Mvc;
using Polytopia.Models;

namespace Polytopia.Controllers
{
    public class HallOfFameController : Controller
    {
        public IActionResult Index()
        {
            // Mock data for demonstration
            var highScores = new List<HighScoreEntry>
        {
            new HighScoreEntry { Username = "Midjiwan", Score = 252578 },
            new HighScoreEntry { Username = "Zoy", Score = 195069 },
            new HighScoreEntry { Username = "Innofunni", Score = 195069 },
            new HighScoreEntry { Username = "GullYY", Score = 172330 }
        };

            // Pass the list to the view
            return View(highScores);
        }
    }
}
