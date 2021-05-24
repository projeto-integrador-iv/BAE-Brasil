using System;

namespace BAE_Brasil.Identity.Models.Base
{
    public abstract class BaseProfileData
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserProfileId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}