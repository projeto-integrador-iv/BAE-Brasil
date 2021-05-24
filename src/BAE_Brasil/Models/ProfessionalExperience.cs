using System;
using System.ComponentModel.DataAnnotations;

namespace BAE_Brasil.Models
{
    public class ProfessionalExperience
    {
        [Key]
        public Guid ProfessionalExperienceId { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string CompanyName { get; set; }
        
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}