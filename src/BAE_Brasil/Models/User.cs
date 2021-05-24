using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Utils.Constants;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public UserType UserType { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
    }
}
