using System;
using Microsoft.AspNetCore.Http;

namespace SmartChurch.Services.Core
{
    public class UserResolverService  
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser()
        {
            string user;

            try
            {
                user = _context.HttpContext.User?.Identity?.Name;
            }
            catch
            {
                user = "System Seeder";
            }

            return user;
        }
    }
}