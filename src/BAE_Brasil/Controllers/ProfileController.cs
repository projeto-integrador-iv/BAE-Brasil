using BAE_Brasil.Identity.Models.ViewModels;
using BAE_Brasil.Identity.Service;
using BAE_Brasil.Identity.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BAE_Brasil.Identity.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IAuthorizationPolicyEnforcementService _authorizationPolicy;
        private readonly IUserProfileService _userProfileService;
        
        public ProfileController(
            IAuthorizationPolicyEnforcementService authorizationPolicy, IUserProfileService userProfileService)
        {
            _authorizationPolicy = authorizationPolicy;
            _userProfileService = userProfileService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            _authorizationPolicy
                .SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: true);

            var userProfileVm = _userProfileService.BuildUserProfileViewModel(HttpContext.Session.GetUserId().Value);
            return View(userProfileVm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _authorizationPolicy
                .SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureThatUserProfile(exists: false);

            return View(new CreateProfileViewModel
            {
                UserType = HttpContext.Session.GetUserType()
            });
        }

        [HttpPost]
        public IActionResult SubmitCreate(CreateProfileViewModel createProfileVm)
        {
            if (_userProfileService.CreateProfile(createProfileVm, ModelState, HttpContext.Session))
                return RedirectToAction("Index", "Home");

            return View("Create");
        }

        [HttpPost]
        public IActionResult SubmitCreateAddress(UserProfileViewModel userProfileVm)
        {
            if(_userProfileService.CreateAddress(userProfileVm, ModelState, HttpContext.Session))
                return RedirectToAction("Index");
            
            return View("Index");
        }
    }
}