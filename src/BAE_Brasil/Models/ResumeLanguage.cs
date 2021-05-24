using System;

namespace BAE_Brasil.Identity.Models
{
    public class ResumeLanguage
    {
        public Guid ResumeLanguageId { get; set; }
        
        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; }
        
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}