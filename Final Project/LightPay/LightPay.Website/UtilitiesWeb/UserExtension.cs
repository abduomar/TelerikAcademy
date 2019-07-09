using System;
using System.Security.Claims;

namespace LightPay.Website.UtilitiesWeb
{
    public static class UserExtension
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user));
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier);

            return userId?.Value;
        }
    }
}
