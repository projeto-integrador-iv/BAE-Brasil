using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Identity.Models.Base;
using BAE_Brasil.Identity.Utils.Enums;

namespace BAE_Brasil.Identity.Models
{
    public class Document 
    {
        [Key]
        public Guid DocumentId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Description { get; set; }
      
        public Guid UserProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}