using System;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Exceptions
{
    public class ForbiddenUserTypeException : Exception
    {
        public UserType UserType { get; set; }

        public ForbiddenUserTypeException(UserType userType)
        {
            UserType = userType;
        }
    }
}