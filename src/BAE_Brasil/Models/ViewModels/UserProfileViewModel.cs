using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Identity.Utils.Constants;
using BAE_Brasil.Identity.Utils.Enums;

namespace BAE_Brasil.Identity.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public UserProfile ProfileData { get; set; }

        #region NewAddress
        [MinLength(1, ErrorMessage = ErrorMessage.MinLength1)]
        public string Street { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string City { get; set; }
        
        [StringLength(maximumLength:2, MinimumLength = 2, ErrorMessage = ErrorMessage.Length2)]
        public string State { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Bairro { get; set; }
        
        [StringLength(8, ErrorMessage = ErrorMessage.Length8)]
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        public string Cep { get; set; }
        
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        public string Number { get; set; }
        
        public string Complement { get; set; }
        #endregion
    }
}