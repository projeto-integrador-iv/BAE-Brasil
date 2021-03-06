using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models.ViewModels
{
    public class CreateResumeViewModel
    {
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Nationality { get; set; }
        
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string Goal { get; set; }
    }
}