using System;
using System.Linq;
using BAE_Brasil.DataSource;
using BAE_Brasil.Exceptions;
using BAE_Brasil.Models;
using BAE_Brasil.Utils.Enums;
using BAE_Brasil.Utils.Extensions;
using Microsoft.AspNetCore.Http;

namespace BAE_Brasil.Service
{
    public class AuthorizationPolicyEnforcementService : IAuthorizationPolicyEnforcementService
    {
        private readonly AppDbContext _context;
        private ISession _session;
        
        public AuthorizationPolicyEnforcementService(AppDbContext context)
        {
            _context = context;
        }

        public AuthorizationPolicyEnforcementService SetCurrentSession(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            return this;
        }
        
        public AuthorizationPolicyEnforcementService EnsureLoggedIn()
        {
            if (!_session.IsLoggedIn())
                throw new AuthenticationNeededException();
            return this;
        }

        public AuthorizationPolicyEnforcementService EnsureUserType(UserType authorizedType)
        {
            var currentUserType = _session.GetUserType();
            if (currentUserType != authorizedType)
                throw new ForbiddenUserTypeException(currentUserType);

            return this;
        }

        public AuthorizationPolicyEnforcementService EnsureThatUserProfile(bool exists)
        {
            var userId = _session.GetUserId();
            var userProfileId = _context.Profiles
                .Where(p => p.UserId == userId)
                .Select(p => p.UserProfileId)
                .FirstOrDefault();

            var profileShouldExistButItDoesnt = exists && userProfileId == default;
            var profileShoundtExistButitDoes = !exists && userProfileId != default;
            
            if (profileShouldExistButItDoesnt|| profileShoundtExistButitDoes)
                throw new UserProfileException(profileExists: !exists, userId: userId);

            if (userProfileId != default)
                _session.SetProfileId(userProfileId);
            
            return this;
        }
        
    }
}