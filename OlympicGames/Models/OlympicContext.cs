using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Models
{
    public class OlympicContext : DbContext
    {
        public OlympicContext(DbContextOptions<OlympicContext> options) 
            : base(options) 
        { } 

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "curling", Name = "Curling/Indoor" },
                new Category { CategoryId = "bobsleigh", Name = "Bobsleigh/Outdoor" },
                new Category { CategoryId = "diving", Name = "Diving/Indoor" },
                new Category { CategoryId = "cycling", Name = "Road Cycling/Outdoor" },
                new Category { CategoryId = "archery", Name = "Archery/Indoor" },
                new Category { CategoryId = "canoe", Name = "Canoe Sprint/Outdoor" },
                new Category { CategoryId = "break", Name = "Breakdancing/Indoor" },
                new Category { CategoryId = "skateboard", Name = "Skateboarding/Outdoor" }
            );
            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = "winter", Name = "Winter Olympics" },
                new Game { GameId = "summer", Name = "Summer Olympics" },
                new Game { GameId = "paralympics", Name = "Paralympics" },
                new Game { GameId = "youth", Name = "Youth Olympic Games" }
            );
            modelBuilder.Entity<Country>().HasData(
                new { CountryId = "as", CountryName = "Austria", GameId = "paralympics", CategoryId = "canoe", FlagImage = "tn_as-flag.gif" },
                new { CountryId = "br", CountryName = "Brazil", GameId = "summer", CategoryId = "cycling", FlagImage = "tn_br-flag.gif" },
                new { CountryId = "ca", CountryName = "Canada ", GameId = "winter", CategoryId = "curling", FlagImage = "tn_ca-flag.gif" },
                new { CountryId = "ch", CountryName = "China", GameId = "summer", CategoryId = "diving", FlagImage = "tn_ch-flag.gif" },
                new { CountryId = "ci", CountryName = "Chile", GameId = "paralympics", CategoryId = "skateboard", FlagImage = "tn_ci-flag.gif" },
                new { CountryId = "cy", CountryName = "Cyprus", GameId = "youth", CategoryId = "break", FlagImage = "tn_cy-flag.gif" },
                new { CountryId = "fi", CountryName = "Finland", GameId = "youth", CategoryId = "skateboard", FlagImage = "tn_fi-flag.gif" },
                new { CountryId = "fr", CountryName = "France", GameId = "youth", CategoryId = "break", FlagImage = "tn_fr-flag.gif" },
                new { CountryId = "gm", CountryName = "Germany", GameId = "summer", CategoryId = "diving", FlagImage = "tn_gm-flag.gif" },
                new { CountryId = "it", CountryName = "Italy", GameId = "winter", CategoryId = "bobsleigh", FlagImage = "tn_it-flag.gif" },
                new { CountryId = "ja", CountryName = "Japan", GameId = "winter", CategoryId = "bobsleigh", FlagImage = "tn_ja-flag.gif" },
                new { CountryId = "jm", CountryName = "Jamaica", GameId = "winter", CategoryId = "bobsleigh", FlagImage = "tn_jm-flag.gif" },
                new { CountryId = "lo", CountryName = "Slovakia", GameId = "youth", CategoryId = "skateboard", FlagImage = "tn_lo-flag.gif" },
                new { CountryId = "mx", CountryName = "Mexico", GameId = "summer", CategoryId = "diving", FlagImage = "tn_mx-flag.gif" },
                new { CountryId = "nl", CountryName = "Netherlands", GameId = "summer", CategoryId = "cycling", FlagImage = "tn_nl-flag.gif" },
                new { CountryId = "pk", CountryName = "Pakistan ", GameId = "paralympics", CategoryId = "canoe", FlagImage = "tn_pk-flag.gif" },
                new { CountryId = "po", CountryName = "Portugal", GameId = "youth", CategoryId = "skateboard", FlagImage = "tn_po-flag.gif" },
                new { CountryId = "rs", CountryName = "Russia", GameId = "youth", CategoryId = "break", FlagImage = "tn_rs-flag.gif" },
                new { CountryId = "sw", CountryName = "Sweden ", GameId = "winter", CategoryId = "curling", FlagImage = "tn_sw-flag.gif" },
                new { CountryId = "th", CountryName = "Thailand", GameId = "paralympics", CategoryId = "archery", FlagImage = "tn_th-flag.gif" },
                new { CountryId = "uk", CountryName = "United Kingdom", GameId = "winter", CategoryId = "curling", FlagImage = "tn_uk-flag.gif" },
                new { CountryId = "up", CountryName = "Ukraine", GameId = "paralympics", CategoryId = "archery", FlagImage = "tn_up-flag.gif" },
                new { CountryId = "us", CountryName = "USA", GameId = "summer", CategoryId = "cycling", FlagImage = "tn_us-flag.gif" },
                new { CountryId = "uy", CountryName = "Uruguay", GameId = "paralympics", CategoryId = "archery", FlagImage = "tn_uy-flag.gif" },
                new { CountryId = "zi", CountryName = "Zimbabwe", GameId = "paralympics", CategoryId = "canoe", FlagImage = "tn_zi-flag.gif" }
            );
        }
    }
}
