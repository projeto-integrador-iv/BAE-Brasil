using System;
using System.Collections.Generic;

namespace BAE_Brasil.Models.ViewModels
{
    public class SearchCandidateViewModel
    {
        #region Filters.Address
        public string State { get; set; }
        public string City { get; set; }
        #endregion
        
        #region Filters.Degree
        public string Level { get; set; }
        public DateTime EndedAt { get; set; }
        public string Subject { get; set; }
        #endregion

        public List<UserProfile> UserProfiles { get; set; }
    }
}