using System;

namespace BAE_Brasil.Models.ViewModels
{
    public class AddProfessionalExperienceViewModel
    {
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string CompanyName { get; set; }
    }
}