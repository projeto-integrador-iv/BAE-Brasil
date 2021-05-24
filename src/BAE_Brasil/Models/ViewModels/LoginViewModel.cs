using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ErrorMessage.Required)]
        [EmailAddress(ErrorMessage = ErrorMessage.EmailFormat)]
        public string Email { get; set; }   
        
        [Required(ErrorMessage = ErrorMessage.Required)]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string Password { get; set; }
        
    }
}