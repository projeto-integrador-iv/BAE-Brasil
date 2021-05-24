using System;

namespace BAE_Brasil.Identity.Exceptions
{
    public class UserProfileException : Exception
    {
        public bool ProfileExists { get; set; }
        public Guid? UserId { get; set; }
        
        public UserProfileException(bool profileExists, Guid? userId)
        {
            ProfileExists = profileExists;
            UserId = userId;
        }
    }
}