using System;
using BAE_Brasil.Models.ViewModels;

namespace BAE_Brasil.Service
{
    public interface IResumeService
    {
        public ResumeViewModel BuildResumeViewModel(Guid userId);
    }
}