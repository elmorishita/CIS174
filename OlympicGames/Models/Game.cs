using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Models
{
    public class Game
    {
        [Key]
        public string GameId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
