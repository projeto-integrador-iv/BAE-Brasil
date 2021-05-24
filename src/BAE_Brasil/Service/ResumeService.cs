using System;
using System.Collections.Generic;
using System.Linq;
using BAE_Brasil.Identity.DataSource;
using BAE_Brasil.Identity.Models;
using BAE_Brasil.Identity.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.Identity.Service
{
    public class ResumeService : IResumeService
    {
        private readonly AppDbContext _context;

        public ResumeService(AppDbContext context)
        {
            _context = context;
        }

        public ResumeViewModel BuildResumeViewModel(Guid userId)
        {
            var profileData = _context.Profiles
                .Where(p => p.UserId == userId)
                .Select(p => new {p.UserProfileId, p.FullName})
                .Single();
            
            var resume = _context.Resumes
                .Where(r => r.UserProfileId == profileData.UserProfileId)
                .Include(r => r.Degrees)
                .Include(r => r.ResumeLanguages)
                .ThenInclude(l => l.Language)
                .Include(r => r.ProfessionalExperiences)
                .FirstOrDefault();

            return new ResumeViewModel
            {
                FullName = profileData.FullName,
                Resume = resume ?? new Resume
                {
                    Degrees = new List<Degree>(),
                    ResumeLanguages = new List<ResumeLanguage>(),
                    ProfessionalExperiences = new List<ProfessionalExperience>()
                }
            };
        }
        
        public bool CreateResume(ModelStateDictionary modelState, ISession session)
        {
            if (!modelState.IsValid)
                return false;

            return true;
        }
    }
}