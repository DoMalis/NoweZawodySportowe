using Microsoft.AspNetCore.Mvc;
using ProjektZawody.Models;
using ProjektZawody.Services;

namespace ProjektZawody.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserModel user = new UserModel();
            // Inicjalizuj user.UserName i user.Password

            /* UserDAO userDAO = new UserDAO();
             string userRole = userDAO.GetUserRole(user);

             user.Role = userRole;*/

            return View(user);
        }

        public IActionResult ProcessLogin(UserModel userModel) 
        { 
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(userModel))
            {
                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);

            }
        }
    }
}
