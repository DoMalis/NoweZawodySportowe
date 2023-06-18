using Microsoft.AspNetCore.Mvc;

namespace ProjektZawody.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetTheme(string theme)
        {
            // Ustawienie ciasteczka o nazwie "ThemeCookie" z wybranym motywem
            Response.Cookies.Append("ThemeCookie", theme, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7) // Ustawienie czasu wygaśnięcia ciasteczka
            });

            return RedirectToAction("Index", "Home"); // Przekierowanie na stronę główną
        }
    }
}
