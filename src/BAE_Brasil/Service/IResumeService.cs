using System;
using BAE_Brasil.Identity.Models.ViewModels;

namespace BAE_Brasil.Identity.Service
{
    public interface IResumeService
    {
        public ResumeViewModel BuildResumeViewModel(Guid userId);
    }
}