using System;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BAE_Brasil.Service
{
    public interface IResumeService
    {
        public ResumeViewModel BuildResumeViewModel(Guid userId);
        public bool ResumeExists(Guid userId);
        public bool CreateResume(CreateResumeViewModel createResumeVm, ModelStateDictionary modelState, Guid profileId);
        public bool AddDegree(Degree degree, ModelStateDictionary modelState, Guid profileId);
        public bool AddProfessionalExperience(
            ProfessionalExperience professionalExperience, ModelStateDictionary modelState, Guid profileId);

        public bool AddLanguage(Language language, ModelStateDictionary modelState, Guid profileId);


    }
}