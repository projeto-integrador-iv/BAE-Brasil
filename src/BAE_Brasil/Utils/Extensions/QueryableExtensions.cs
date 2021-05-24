using System.Linq;
using BAE_Brasil.Models;
using Microsoft.EntityFrameworkCore;

namespace BAE_Brasil.Utils.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<User> LoadUserProfile(this IQueryable<User> query)
        {
            return query
                .Include(u => u.UserProfile)
                .ThenInclude(p => p.Address)
                .Include(u => u.UserProfile)
                .ThenInclude(p => p.Contacts)
                .Include(u => u.UserProfile)
                .ThenInclude(p => p.Documents);
        }
    }
}