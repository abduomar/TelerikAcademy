using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LightPay.Models;
using Microsoft.AspNetCore.Authentication;

namespace LightPay.Website.AuthenticationServices
{
    public class CookieService : ICookieService
    {
        public AuthenticationProperties GetCookieOptions()
        {
            return new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };
        }

        public List<Claim> PrepareAdminClaims(Administrator user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
            };
        }

        public List<Claim> PrepareUserClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
            };
        }
    }
}
