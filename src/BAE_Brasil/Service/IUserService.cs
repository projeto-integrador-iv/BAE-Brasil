using BAE_Brasil.Identity.Models;
using BAE_Brasil.Identity.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BAE_Brasil.Identity.Service
{
    public interface IUserService
    {
        public bool InsertUser(CreateUserViewModel userVm, ModelStateDictionary modelState);
        public bool Login(LoginViewModel loginVm, ModelStateDictionary modelState, ISession session);
        public void Logout(ISession session);
    }
}