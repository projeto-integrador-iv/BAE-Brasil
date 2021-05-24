using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models
{
    public class Language
    {
        [Key]
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public Proficiency Proficiency { get; set; }
        
        public virtual List<ResumeLanguage> ResumeLanguages { get; set; }
    }
}