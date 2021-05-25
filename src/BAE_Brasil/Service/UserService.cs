using System;
using System.Linq;
using System.Threading;
using AutoMapper;
using BAE_Brasil.DataSource;
using BAE_Brasil.DataSource.SeedData;
using BAE_Brasil.Utils.Extensions;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using BAE_Brasil.Utils.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BAE_Brasil.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool InsertUser(CreateUserViewModel userVm, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                return false;

            if (EmailAlreadyExist(userVm))
            {
                modelState.AddModelError(nameof(userVm.Email), ErrorMessage.EmailExists);
                return false;
            }

            if (!userVm.PasswordConfirmed)
            {
                modelState.AddModelError(nameof(userVm.Password), ErrorMessage.PasswordsMustMatch);
                return false;
            }

            var mappedUser = _mapper.Map<User>(userVm);
            _context.Users.Add(mappedUser);
            _context.SaveChanges();
            return true;
        }

        public bool Login(LoginViewModel loginVm, ModelStateDictionary modelState, ISession session)
        {
            if (!modelState.IsValid)
                return false;

            var user = GetUserByEmail(loginVm.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginVm.Password, user.Password))
            {
                modelState.AddModelError(nameof(loginVm.Email), "Email ou senha incorretos");
                return false;
            }
            session.SetUserData(user);
            return true;
        }

        public void Logout(ISession session)
        {
            if (session.TryGetValue("userId", out _))
            {
                session.Clear();
            }
        }
        
        private User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        
        private bool EmailAlreadyExist(CreateUserViewModel userVm)
        {
            return _context.Users.Any(u => u.Email == userVm.Email);
        }
        
        public void Pop()
        {
            if (_context.Users.Count() < 300)
            {
                for (var i = 0; i < 30; i++)
                {
                    var users = BogusUsers.CreateBogusUsers(10);
                    _context.Users.AddRange(users);
                    _context.SaveChanges();
                    Console.WriteLine($"\nBloco: {i}\n");
                    System.GC.Collect();
                    Thread.Sleep(500);
                }
                Console.WriteLine("Usuários de teste criados");
            }
        }
    }
}