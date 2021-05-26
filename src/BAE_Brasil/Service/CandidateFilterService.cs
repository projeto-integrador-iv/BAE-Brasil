using System;
using System.Collections.Generic;
using System.Linq;
using BAE_Brasil.DataSource;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.Service
{
    public class CandidateFilterService : ICandidateFilterService
    {
        private readonly AppDbContext _context;
        
        public CandidateFilterService(AppDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> Filter(SearchCandidateViewModel searchCandidateVm)
        {
            var predicate = PredicateBuilder.New<UserProfile>(true);

            if (!string.IsNullOrWhiteSpace(searchCandidateVm.Language))
                predicate.And(p => 
                    p.Resume.ResumeLanguages.Any(l => 
                        l.Language.Name == searchCandidateVm.Language && 
                        l.Language.Proficiency == searchCandidateVm.Proficiency));

            if (!string.IsNullOrWhiteSpace(searchCandidateVm.State))
                predicate.And(p => p.Address.State.Contains(searchCandidateVm.State));

            if (!string.IsNullOrWhiteSpace(searchCandidateVm.City))
                predicate.And(p => p.Address.City.Contains(searchCandidateVm.City));  
            
            if (searchCandidateVm.EndedAt != null && searchCandidateVm.EndedAt > new DateTime(1930))
                predicate.And(p => p.Resume.Degrees.Any(d => d.EndedAt<= searchCandidateVm.EndedAt));

            if (!string.IsNullOrWhiteSpace(searchCandidateVm.Level))
                predicate.And(p => p.Resume.Degrees.Any(d => d.Level.Contains(searchCandidateVm.Level)));

            return _context
                .Profiles
                .Where(predicate)
                .Include(p => p.Address)
                .Include(p => p.Resume)
                .ToList();
        }
    }
}