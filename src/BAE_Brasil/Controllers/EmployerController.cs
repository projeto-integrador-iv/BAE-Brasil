using BAE_Brasil.Models.ViewModels;
using BAE_Brasil.Service;
using BAE_Brasil.Utils.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BAE_Brasil.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ICandidateFilterService _candidateFilterService;
        private readonly IAuthorizationPolicyEnforcementService _policyEnforcementService;
        
        public EmployerController(ICandidateFilterService candidateFilterService, 
            IAuthorizationPolicyEnforcementService policyEnforcementService)
        {
            _candidateFilterService = candidateFilterService;
            _policyEnforcementService = policyEnforcementService;
        }
        
        [HttpGet]
        public IActionResult SearchResumes()
        {
            _policyEnforcementService
                .SetCurrentSession(HttpContext.Session)
                .EnsureLoggedIn()
                .EnsureUserType(UserType.Empregador)
                .EnsureThatUserProfile(exists: true);
            
            return View();
        }

        public IActionResult SubmitSearchResumes(SearchCandidateViewModel searchCandidateVm)
        {
            var result = _candidateFilterService.Filter(searchCandidateVm);
            searchCandidateVm.UserProfiles = result;
            return View("SearchResumes", searchCandidateVm);
        }
    }
}