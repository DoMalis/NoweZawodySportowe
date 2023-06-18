using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProjektZawody.Models;
using ProjektZawody.Data.Services;
using Microsoft.AspNetCore.Authorization;

namespace ProjektZawody.Controllers
{
    public class NewUserController : Controller
    {
        private readonly INewUserService _service;
        public NewUserController(INewUserService service)
        {
            _service = service;
        }
        //strona dodawania nowego użytkownika
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.PageTitle = "Dodawanie użytkownika";
            return View();
        }
        //wynik dodwania nowego użytkownika
        [HttpPost]
        public IActionResult Create([Bind("UserName,Password")] NewUser newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            _service.Add(newUser);
            return RedirectToAction("Index");
        }
    }
}
