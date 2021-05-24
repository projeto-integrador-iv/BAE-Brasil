using Microsoft.AspNetCore.Http;

namespace BAE_Brasil.Identity.Service
{
    public interface IAuthorizationPolicyEnforcementService
    {
        public AuthorizationPolicyEnforcementService EnsureThatUserProfile(bool exists);
        public AuthorizationPolicyEnforcementService EnsureLoggedIn();
        public AuthorizationPolicyEnforcementService SetCurrentSession(ISession session);
    }
}