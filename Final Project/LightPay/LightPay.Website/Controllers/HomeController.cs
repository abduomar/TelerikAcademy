using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LightPay.Website.Models;
using LightPay.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using LightPay.Website.AuthenticationServices;
using LightPay.Models;

namespace LightPay.Website.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;
        private readonly ICookieService cookieService;

        public HomeController(IUserService userService, ICookieService cookieService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.cookieService = cookieService ?? throw new ArgumentNullException(nameof(cookieService));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel login)
        {
            if(!this.ModelState.IsValid)
            {
                return View(login);
            }

            var user = await this.userService.FindUserAsync(login.Username, login.Password);

            if(user==null)
            {
                //throw exception stamp data

                return View(login);
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var identity = new ClaimsIdentity(this.cookieService.PrepareUserClaims(user), scheme);


           await this.HttpContext.SignInAsync(scheme, new ClaimsPrincipal(identity), this.cookieService.GetCookieOptions());

            //private area
            return RedirectToAction("AllAccounts", "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
