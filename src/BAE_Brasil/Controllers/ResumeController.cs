using System.Collections.Generic;
using BAE_Brasil.Identity.Models;
using BAE_Brasil.Identity.Models.ViewModels;
using BAE_Brasil.Identity.Service;
using BAE_Brasil.Identity.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BAE_Brasil.Identity.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        
        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetUserId();
            var resumeVm = _resumeService.BuildResumeViewModel(userId.Value);
            return View(resumeVm);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitCreate(CreateResumeViewModel createResumeVm)
        {
            return View("Create");
        }
    }
}