using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        private OlympicContext context;
        public FavoritesController(OlympicContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory(),
                Countries = session.GetMyCountry()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Country country)
        {
            country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Category)
                .Where(t => t.CountryId == country.CountryId)
                .FirstOrDefault() ?? new Country();

            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            var countriesss = session.GetMyCountry();
            countriesss.Add(country);
            session.SetMyCountry(countriesss);
            cookies.SetMyCountryIds(countriesss);

            TempData["message"] = $"{country.CountryName} added to your favorites";
            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveGame = session.GetActiveGame() ,
                    ActiveCategory = session.GetActiveCategory()
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Index", "Home",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveCategory = session.GetActiveCategory()
                });
        }
    }
}
