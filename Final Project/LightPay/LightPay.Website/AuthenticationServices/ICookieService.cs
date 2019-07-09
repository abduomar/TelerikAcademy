using LightPay.Models;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LightPay.Website.AuthenticationServices
{
    public interface ICookieService
    {
        AuthenticationProperties GetCookieOptions();

        List<Claim> PrepareUserClaims(User user);

        List<Claim> PrepareAdminClaims(Administrator user);
    }
}
