using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProjektZawody.Models;
using ProjektZawody.Data.Services;
using Microsoft.AspNetCore.Authorization;
using ProjektZawody.Services;

namespace ProjektZawody.Controllers
{
    [Authorize]
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
        public IActionResult Create([Bind("UserName,Password, ConfirmPassword, Role")] NewUser newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            if (newUser.Password != newUser.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmedPassword", "Passwords do not match.");
                return View(newUser);
            }
            _service.AddUser(newUser);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Lista użytkowników";
                  var data = _service.GetAllUsers();
            return View(data);
        }
    }
}
