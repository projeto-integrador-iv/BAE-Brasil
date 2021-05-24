using System;
using System.Linq;
using AutoMapper;
using BAE_Brasil.DataSource;
using BAE_Brasil.Exceptions;
using BAE_Brasil.Utils.Extensions;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserProfileService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserProfileViewModel BuildUserProfileViewModel(Guid userId)
        {
            var user = _context.Users
                .Where(u => u.UserId == userId)
                .LoadUserProfile()
                .Single();
            
            return new UserProfileViewModel
            {
                Email = user.Email,
                UserType = user.UserType,
                ProfileData = user.UserProfile
            };
        }

        public bool CreateAddress(
            UserProfileViewModel userProfileVm, ModelStateDictionary modelState, ISession session)
        {
            if (!modelState.IsValid) 
                return false;
            
            var address = _mapper.Map<Address>(userProfileVm);
            var userId = session.GetUserId();
            address.UserProfileId = _context.Profiles
                .Where(p => p.UserId == userId)
                .Select(p => p.UserProfileId)
                .Single();
            
            _context.Add(address);
            _context.SaveChanges();
            return true;
        }
        
        public bool CreateProfile(
            CreateProfileViewModel createProfileVm, ModelStateDictionary modelState, ISession session)
        {
            if (!modelState.IsValid)
                return false;
            
            var userProfile = _mapper.Map<UserProfile>(createProfileVm);

            var userId = session.GetUserId();
            if (!userId.HasValue)
            {
                throw new AuthenticationNeededException();
            }
            userProfile.UserId = userId.Value;
            
            _context.Profiles.Add(userProfile);
            _context.SaveChanges();
            return true;
        }
    }
}