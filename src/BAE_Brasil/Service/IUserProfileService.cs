using System;
using BAE_Brasil.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BAE_Brasil.Service
{
    public interface IUserProfileService
    {
        public bool CreateProfile(
            CreateProfileViewModel createProfileVm, ModelStateDictionary modelState, ISession session);

        public bool CreateAddress(
            UserProfileViewModel userProfileVm, ModelStateDictionary modelState, ISession session);
        public UserProfileViewModel BuildUserProfileViewModel(Guid userId);

    }
}