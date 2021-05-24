using BAE_Brasil.Utils.Extensions;
using BAE_Brasil.Models.ViewModels;
using BAE_Brasil.Service;
using Microsoft.AspNetCore.Mvc;

namespace BAE_Brasil.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitRegister(CreateUserViewModel createUserVm)
        {
            if (_userService.InsertUser(createUserVm, ModelState))
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Register", createUserVm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData.Add("isLoggedIn", HttpContext.Session.IsLoggedIn());
            return View();
        }

        [HttpPost]
        public IActionResult SubmitLogin(LoginViewModel loginVm)
        {
            if (_userService.Login(loginVm, ModelState, HttpContext.Session))
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Login", loginVm);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _userService.Logout(HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }
    }
}