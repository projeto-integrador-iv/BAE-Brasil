using System;
using BAE_Brasil.Models;
using BAE_Brasil.Utils.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace BAE_Brasil.Utils.Extensions
{
    public static class SessionExtensions
    {
        public static bool IsLoggedIn(this ISession session)
        {
            return session.TryGetValue("userId", out _);
        }

        public static Guid? GetUserId(this ISession session)
        {
            var userId = session.GetString("userId");

            return userId == null ? null : Guid.Parse(userId);
        }

        public static UserType GetUserType(this ISession session)
        {
            return (UserType) session.GetInt32("userType");
        }
        
        public static void SetUserData(this ISession session, User user)
        {
            session.SetString("userId", user.UserId.ToString());
            session.SetInt32("userType", (int) user.UserType);
        }

        public static Guid? GetProfileId(this ISession session)
        {
            return Guid.Parse(session.GetString("profileId"));
        }
        
        public static void SetProfileId(this ISession session, Guid profileId)
        {
            if (!session.TryGetValue("profileId", out _))
            {
                session.SetString("profileId", profileId.ToString());
            }
        }
        
        public static void SetCallbackUrl(this ISession session, HttpContext context)
        {
            if (context.GetRouteData().Values.TryGetValue("controller", out var controller) && controller != null)
            {
                session.SetString("controller", controller.ToString());
                session.SetString("action",
                    context.GetRouteData().Values["action"]?.ToString());   
                return;
            }
            session.SetString("controller", "Home");
            session.SetString("action", "Index");
        }
    }
}