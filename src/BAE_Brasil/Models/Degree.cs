using System;

namespace BAE_Brasil.Identity.Models
{
    public class Degree
    {
        public Guid DegreeId { get; set; }
        public string Level { get; set; }
        public string Institution { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Resume Resume { get; set; }
    }
}