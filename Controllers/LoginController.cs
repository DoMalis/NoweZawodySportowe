﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjektZawody.Models;
using ProjektZawody.Services;

namespace ProjektZawody.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var cookies = Request.Cookies.Keys;
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }
            UserModel user = new UserModel();

            return View(user);
        }

        public IActionResult ProcessLogin(UserModel userModel) 
        {
            ViewBag.PageTitle = "Logowanie";
            SecurityService securityService = new SecurityService();
            if(securityService.IsValid(userModel))
            {
            userModel.Role=securityService.getRole(userModel);
                Response.Cookies.Append("UserRole", userModel.Role);

                return View("LoginSuccess", userModel);
            }
            else
            {
                return View("LoginFailure", userModel);

            }
            
        }
        public IActionResult Logout()
        {
            ViewBag.PageTitle = "Wylogowanie";

            var cookies = Request.Cookies.Keys;
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return View("Logout");
        }
    }
}
