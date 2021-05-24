using BAE_Brasil.Models;
using BAE_Brasil.Utils.Extensions;
using BAE_Brasil.Models.ViewModels;
using BAE_Brasil.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BAE_Brasil.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        private readonly IAuthorizationPolicyEnforcementService _authorizationPolicy;

        public ResumeController(
            IResumeService resumeService, IAuthorizationPolicyEnforcementService authorizationPolicy)
        {
            _resumeService = resumeService;
            _authorizationPolicy = authorizationPolicy;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            _authorizationPolicy.SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);
            
            var profileId = HttpContext.Session.GetProfileId().Value;
            
            if (!_resumeService.ResumeExists(profileId)) 
                return RedirectToAction("Create");
            
            var resumeVm = _resumeService.BuildResumeViewModel(profileId);
            return View(resumeVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _authorizationPolicy.SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);
            
            return View();
        }

        [HttpPost]
        public IActionResult SubmitCreate(CreateResumeViewModel createResumeVm)
        {
            var profileId = HttpContext.Session.GetProfileId().Value;

            if (_resumeService.CreateResume(createResumeVm, ModelState, profileId))
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [HttpGet]
        public IActionResult AddProfessionalExperience()
        {
            _authorizationPolicy.SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);

            return View();
        }
        
        [HttpPost]
        public IActionResult SubmitAddProfessionalExperience(ProfessionalExperience professionalExperience)
        {
            var profileId = HttpContext.Session.GetProfileId().Value;
            if (_resumeService.AddProfessionalExperience(professionalExperience, ModelState, profileId))
            {
                return RedirectToAction("Index");
            }
            return View("AddProfessionalExperience");
        }

        [HttpGet]
        public IActionResult AddDegree()
        {
            _authorizationPolicy.SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAddDegree(Degree degree)
        {
            var profileId = HttpContext.Session.GetProfileId().Value;
            if (_resumeService.AddDegree(degree, ModelState, profileId))
            {
                return RedirectToAction("Index");
            }

            return View("AddDegree");
        }

        [HttpGet]
        public IActionResult AddLanguage()
        {
            _authorizationPolicy.SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);
            return View();   
        }
        
        [HttpPost]
        public IActionResult SubmitAddLanguage(Language language)
        {
            var profileId = HttpContext.Session.GetProfileId().Value;
            if (_resumeService.AddLanguage(language, ModelState, profileId))
            {
                return RedirectToAction("Index");
            }

            return View("AddDegree");
        }
    }
}