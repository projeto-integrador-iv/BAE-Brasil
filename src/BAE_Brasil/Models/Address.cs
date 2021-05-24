using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAE_Brasil.Models.Base;
using BAE_Brasil.Utils.Constants;

namespace BAE_Brasil.Models
{
    public class Address 
    {
        [Key]
        public Guid AddressId { get; set; }
        
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        
        public Guid UserProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}