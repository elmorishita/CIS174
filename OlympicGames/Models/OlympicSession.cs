using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class OlympicSession
    {
        private const string CountryKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string CategoryKey = "category";

        private ISession session { get; set; }
        public OlympicSession(ISession session)
            => this.session = session;
        

        public void SetMyCountry(List<Country> countries){
            session.SetObject(CountryKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }
        public List<Country> GetMyCountry() =>
            session.GetObject<List<Country>>(CountryKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetActiveGame(string activeGame) =>
            session.SetString(GameKey, activeGame);
        public string GetActiveGame() => 
            session.GetString(GameKey) ?? string.Empty;

        public void SetActiveCategory(string ActiveCategory) =>
            session.SetString(CategoryKey, ActiveCategory);
        public string GetActiveCategory() => 
            session.GetString(CategoryKey) ?? string.Empty;


        public void RemoveMyCountries()
        {
            session.Remove(CountryKey);
            session.Remove(CountKey);
        }
    }
}
