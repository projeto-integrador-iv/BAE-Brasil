using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAE_Brasil.Identity.Models
{
    public class Resume
    {
        [Key]
        public Guid ResumeId { get; set; }
        public string Nationality { get; set; }
        public string Goal { get; set; }
        
        public Guid UserProfileId { get; set; }
        
        public virtual UserProfile UserProfile { get; set; }
        public virtual List<ResumeLanguage> ResumeLanguages { get; set; }
        public virtual List<Degree> Degrees { get; set; }
        public virtual List<ProfessionalExperience> ProfessionalExperiences { get; set; }
    }
}