using System.Collections.Generic;
using BAE_Brasil.Models;
using BAE_Brasil.Models.ViewModels;

namespace BAE_Brasil.Service
{
    public interface ICandidateFilterService
    {
        public List<UserProfile> Filter(SearchCandidateViewModel searchCandidateVm);

    }
}