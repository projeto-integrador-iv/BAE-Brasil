using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Identity.Utils.Constants;
using BAE_Brasil.Identity.Utils.Enums;

namespace BAE_Brasil.Identity.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = ErrorMessage.Required)]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrorMessage.Required)]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = ErrorMessage.Required)]
        [EmailAddress(ErrorMessage = ErrorMessage.EmailFormat)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessage.Required)]
        public UserType UserType { get; set; }

        public bool PasswordConfirmed => Password == ConfirmPassword;
    }
}