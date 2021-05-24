using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BAE_Brasil.DataSource;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.Service
{
    public class ResumeService : IResumeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public ResumeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool ResumeExists(Guid profileId)
        {
            var resumeId = _context.Resumes
                .Where(r => r.UserProfileId == profileId)
                .Select(r => r.ResumeId).FirstOrDefault();
            return resumeId != default;
        }
        
        public ResumeViewModel BuildResumeViewModel(Guid profileId)
        {
            var fullname = _context.Profiles
                .Where(p => p.UserProfileId == profileId)
                .Select(p => p.FullName)
                .Single();
            
            var resume = _context.Resumes
                .Where(r => r.UserProfileId == profileId)
                .Include(r => r.Degrees)
                .Include(r => r.ResumeLanguages)
                .ThenInclude(l => l.Language)
                .Include(r => r.ProfessionalExperiences)
                .FirstOrDefault();

            return new ResumeViewModel
            {
                FullName = fullname,
                Resume = resume 
            };
        }

        public bool AddProfessionalExperience(
            ProfessionalExperience professionalExperience, ModelStateDictionary modelState, Guid profileId)
        {
            if (!modelState.IsValid)
                return false;
            
            var resumeId = _context.Resumes
                .Where(r => r.UserProfileId == profileId)
                .Select(r => r.ResumeId)
                .FirstOrDefault();

            professionalExperience.ResumeId = resumeId;
            _context.ProfessionalExperiences.Add(professionalExperience);
            _context.SaveChanges();
            
            return true;
        }

        public bool AddDegree(Degree degree, ModelStateDictionary modelState, Guid profileId)
        {
            if (!modelState.IsValid)
                return false;
            
            var resumeId = _context.Resumes
                .Where(r => r.UserProfileId == profileId)
                .Select(r => r.ResumeId)
                .FirstOrDefault();

            degree.ResumeId = resumeId;
            _context.Degrees.Add(degree);
            _context.SaveChanges();
            
            return true;
        }
        
        public bool AddLanguage(Language language, ModelStateDictionary modelState, Guid profileId)
        {
            if (!modelState.IsValid)
                return false;
            
            var resumeId = _context.Resumes
                .Where(r => r.UserProfileId == profileId)
                .Select(r => r.ResumeId)
                .FirstOrDefault();

            var resumeLanguage = new ResumeLanguage
            {
                ResumeId = resumeId,
                Language = language
            };

            _context.ResumeLanguages.Add(resumeLanguage);
            _context.SaveChanges();
            
            return true;
        }
        
        public bool CreateResume(CreateResumeViewModel createResumeVm, ModelStateDictionary modelState, Guid profileId)
        {
            if (!modelState.IsValid)
                return false;

            var resume = _mapper.Map<Resume>(createResumeVm);
            resume.UserProfileId = profileId;
            _context.Resumes.Add(resume);
            _context.SaveChanges();
            
            return true;
        }
    }
}