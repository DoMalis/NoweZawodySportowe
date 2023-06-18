using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjektZawody.Models;
using ProjektZawody.Services;
using System.Security.Claims;

namespace ProjektZawody.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Logowanie";

          
            UserModel user = new UserModel();

            return View(user);
        }

        public async Task<IActionResult> ProcessLogin(UserModel userModel)
        {
            ViewBag.PageTitle = "Logowanie";
            SecurityService securityService = new SecurityService();
            if (securityService.IsValid(userModel))
            {
                var role = securityService.getRole(userModel);
                userModel.Role = role.Replace(" ", "");

                 var claims = new List<Claim>();
                claims.Add(new Claim("username", userModel.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.UserName));

                claims.Add(new Claim(ClaimTypes.Role, userModel.Role));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimPrincipal);

                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);

            }

        }
        public async Task<IActionResult> Logout()
        {
            ViewBag.PageTitle = "Wylogowanie";
            await HttpContext.SignOutAsync();

            return View("Logout");
        }
        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View("Denied");
        }
    }
}
