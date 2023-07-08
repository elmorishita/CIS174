using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; } = string.Empty;

        public string CountryName { get; set; } = string.Empty;
        public Category Category { get; set; } = null!; // Sport/Type
        public Game Game { get; set; } = null!;  // Winter/Summer/Paralympics/Youth
        public string FlagImage { get; set; } = string.Empty;

    }
}
