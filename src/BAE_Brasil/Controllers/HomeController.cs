using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAE_Brasil.Identity.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BAE_Brasil.Identity.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace BAE_Brasil.Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            return HttpContext.Features.Get<IExceptionHandlerFeature>().Error switch
            {
                AuthenticationNeededException => RedirectToAction("Login", "User"),
                UserProfileException {ProfileExists: true} => RedirectToAction("Index", "Profile"),
                UserProfileException {ProfileExists: false} => RedirectToAction("Create", "Profile"),
                _ => View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier})
            };
        }
    }
}