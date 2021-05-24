using System;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models
{
    public class Degree
    {
        public Guid DegreeId { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Level { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Institution { get; set; }
        
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string Subject { get; set; }

        [Required]
        public DateTime StartedAt { get; set; }
        
        [Required]
        public DateTime EndedAt { get; set; }
        
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}