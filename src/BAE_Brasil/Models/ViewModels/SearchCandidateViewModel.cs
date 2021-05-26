using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models.ViewModels
{
    public class SearchCandidateViewModel
    {
        #region Filters.Address
        [StringLength(2)]
        public string State { get; set; }
        public string City { get; set; }
        #endregion
        
        #region Filters.Degree
        public string Level { get; set; }
        public DateTime? EndedAt { get; set; }
        public string Subject { get; set; }
        #endregion

        #region Filters.Language
        public string Language { get; set; }
        public Proficiency Proficiency { get; set; }
        #endregion
        
        public List<UserProfile> UserProfiles { get; set; }
    }
}