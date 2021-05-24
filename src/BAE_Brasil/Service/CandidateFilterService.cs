using System.Collections.Generic;
using System.Linq;
using BAE_Brasil.DataSource;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;
using LinqKit;

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

            if (!string.IsNullOrWhiteSpace(searchCandidateVm.State))
                predicate.And(p => p.Address.State.Contains(searchCandidateVm.State));
           
            
            if (!string.IsNullOrWhiteSpace(searchCandidateVm.City))
                predicate.And(p => p.Address.City.Contains(searchCandidateVm.City));
            
            
            if (!string.IsNullOrWhiteSpace(searchCandidateVm.Level))
                predicate.And(p => p.Resume.Degrees.Any(d => d.Level.Contains(searchCandidateVm.Level)));

            return _context
                .Profiles
                .Where(predicate)
                .ToList();
        }
    }
}