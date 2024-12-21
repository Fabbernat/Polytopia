using System.Collections.Generic;
using Polytopia.Models.Tribes;

namespace Polytopia.Models
{
    public class Game
    {
        public string Username { get; set; }
        public int BotCount { get; set; }
        public string Difficulty { get; set; }
        public string SelectedTribe { get; set; }
        public List<string> AllTribes { get; set; } = new List<string>();
        public List<string> BotTribes { get; set; } = new List<string>();
        public string[,] Map { get; set; }


        public Game()
        {
            // Initialize Tribes in the constructor
            AllTribes.AddRange(new HumanTribes().GetAll());
            AllTribes.AddRange(new SpecialTribes().GetAll());
        }

        public string GetRandomTribe()
        {
            var random = new Random();
            int index = random.Next(AllTribes.Count);
            return AllTribes[index];
        }

        public List<string> AvailableTribes { get; set; } = new List<string>
        {
            "Xin-Xi", "Imperius", "Bardur", "Oumaji", "Kickoo", "Luxidoor", "Zebasi"
        };

        private static readonly string[] TerrainTypes = new string[]
        {
            "ocean", "water", "land", "fruit", "farm", "forest",
            "forest_with_animal", "mountain", "mountain_with_metal"
        };

        public void AssignRandomBotTribes()
        {
            var random = new Random();
            var availableTribesCopy = new List<string>(AvailableTribes);

            for (int i = 0; i < BotCount; i++)
            {
                int index = random.Next(availableTribesCopy.Count);
                BotTribes.Add(availableTribesCopy[index]);
                availableTribesCopy.RemoveAt(index);
            }
        }

        public void GenerateMap(int size = 16)
        {
            var random = new Random();
            Map = new string[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Map[x, y] = TerrainTypes[random.Next(TerrainTypes.Length)];
                }
            }
        }
    }
}