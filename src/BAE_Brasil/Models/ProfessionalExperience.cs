using System;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models
{
    public class ProfessionalExperience
    {
        [Key]
        public Guid ProfessionalExperienceId { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Job { get; set; }
        
        [MinLength(8, ErrorMessage = ErrorMessage.MinLength8)]
        public string Description { get; set; }
        
        [Required]
        public DateTime StartedAt { get; set; }
        
        [Required]
        public DateTime EndedAt { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string CompanyName { get; set; }
        
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}