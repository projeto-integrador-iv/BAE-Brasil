using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Models.Base;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models
{
    public class UserProfile 
    {
        [Key] 
        public Guid UserProfileId{ get; set; }
        
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        
        public Guid UserId { get; set; }
        
        public virtual Address Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual User User { get; set; }
        public virtual List<Document> Documents { get; set; }
        public virtual Resume Resume { get; set; }
    }
}