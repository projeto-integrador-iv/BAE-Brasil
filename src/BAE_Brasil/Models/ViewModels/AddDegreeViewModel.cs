using System;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Identity.Utils.Constants;

namespace BAE_Brasil.Identity.Models.ViewModels
{
    public class AddDegreeViewModel
    {
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Level { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Institution { get; set; }
        
        [Required(ErrorMessage = ErrorMessage.Required)]
        public DateTime StartedAt { get; set; }
        
        [Required(ErrorMessage = ErrorMessage.Required)]
        public DateTime EndedAt { get; set; }
              
    }
}