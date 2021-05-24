using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models
{
    public class Resume
    {
        [Key]
        public Guid ResumeId { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Nationality { get; set; }
        
        [Column(TypeName = "TEXT")]
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string Goal { get; set; }
        
        public Guid UserProfileId { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<ResumeLanguage> ResumeLanguages { get; set; }
        public virtual List<Degree> Degrees { get; set; }
        public virtual List<ProfessionalExperience> ProfessionalExperiences { get; set; }
    }
}