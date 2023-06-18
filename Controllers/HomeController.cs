using Microsoft.AspNetCore.Mvc;
using ProjektZawody.Models;
using ProjektZawody.Services;
using System.Diagnostics;

namespace ProjektZawody.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ThemeService _themeService;
        public HomeController(ILogger<HomeController> logger, ThemeService themeService)
        {
            _logger = logger;
            _themeService = themeService;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Strona wejściowa";


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetTheme(string theme)
        {
            _themeService.SetThemeCookie(theme);

            return RedirectToAction("Index");
        }
    }
}