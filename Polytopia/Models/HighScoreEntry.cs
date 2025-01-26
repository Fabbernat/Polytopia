using System.ComponentModel.DataAnnotations;

namespace Polytopia.Models
{
    public class HighScoreEntry
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
    }

}
