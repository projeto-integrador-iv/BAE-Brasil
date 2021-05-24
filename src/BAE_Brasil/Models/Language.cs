using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models
{
    public class Language
    {
        [Key]
        public Guid LanguageId { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Name { get; set; }
        
        [Required]
        public Proficiency Proficiency { get; set; }
        
        public virtual List<ResumeLanguage> ResumeLanguages { get; set; }
    }
}