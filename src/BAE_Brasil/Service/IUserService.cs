using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BAE_Brasil.Service
{
    public interface IUserService
    {
        public bool InsertUser(CreateUserViewModel userVm, ModelStateDictionary modelState);
        public bool Login(LoginViewModel loginVm, ModelStateDictionary modelState, ISession session);
        public void Logout(ISession session);
        public void Pop();
    }
}