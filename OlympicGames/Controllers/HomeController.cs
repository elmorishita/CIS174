using OlympicGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private OlympicContext context;

        public HomeController(OlympicContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(CountryViewModel model)
        {

            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveCategory(model.ActiveCategory);
            session.SetActiveGame(model.ActiveGame);

            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OlympicCookies(Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                    mycountries = context.Countries.Include(t => t.Game)
                        .Include(t => t.Category)
                        .Where(t => ids.Contains(t.CountryId)).ToList();
                session.SetMyCountry(mycountries);
            }

            model.Games = context.Games.ToList();
            model.Categories = context.Categories.ToList();

            IQueryable<Country> query = context.Countries.OrderBy(t => t.CountryName);
            if (model.ActiveGame != "all")
                query = query.Where(
                    t => t.Game.GameId.ToLower() == model.ActiveGame.ToLower());
            if (model.ActiveCategory != "all")
                query = query.Where(
                    t => t.Category.CategoryId.ToLower() == model.ActiveCategory.ToLower());
            model.Countries = query.ToList();

            return View(model);
        }

        public ViewResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryId == id) ?? new Country(),
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory()
            };
            return View(model);
        }



    }
}