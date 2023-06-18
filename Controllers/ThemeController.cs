using Microsoft.AspNetCore.Mvc;

namespace ProjektZawody.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectToAction("Home");
            return View();

        }

        public IActionResult SetTheme(string theme)
        {
            // Ustawienie ciasteczka o nazwie "ThemeCookie" z wybranym motywem
            if (Request.Cookies.ContainsKey("ThemeCookie"))
            {
                Response.Cookies.Delete("ThemeCookie");
            }

            Response.Cookies.Append("ThemeCookie", theme, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });


            return RedirectToAction("Index", "Home");

        }
    }
}
