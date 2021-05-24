using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Models.Base;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models
{
    public class Contact 
    {
        [Key]
        [Column("ContactId")]
        public Guid ContactId { get; set; }
        
        public string Description { get; set; }
        public ContactType ContactType { get; set; }
        
        public Guid UserProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}