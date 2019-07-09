using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LightPay.Models;
using LightPay.Services.Interfaces;
using LightPay.Services.Utilities;
using LightPay.Website.Areas.Admin.Models;
using LightPay.Website.AuthenticationServices;
using LightPay.Website.Models;
using LightPay.Website.Paging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightPay.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorizeController : Controller
    {

        private readonly IAdministratorService administratorService;
        private readonly ICookieService cookieService;
        private readonly IClientService clientService;
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public AuthorizeController(IAdministratorService administratorService, ICookieService cookieService,
           IClientService clientService, IUserService userService, IAccountService accountService)
        {
            this.administratorService = administratorService ?? throw new ArgumentNullException(nameof(administratorService));
            this.cookieService = cookieService ?? throw new ArgumentNullException(nameof(cookieService));
            this.clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLogin)
        {

            if (!this.ModelState.IsValid)
            {
                return View(adminLogin);
            }

            var administrator = await this.administratorService.GetAdminAsync(adminLogin.Username, adminLogin.Password);

            if (administrator == null)
            {
                //throw exception stamp data

                return View(adminLogin);
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var identity = new ClaimsIdentity(this.cookieService.PrepareAdminClaims(administrator), scheme);



            await this.HttpContext.SignInAsync(scheme, new ClaimsPrincipal(identity), this.cookieService.GetCookieOptions());

            //private admin dashboard
            return RedirectToAction("Dashboard", "Authorize");
        }

        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authorize");
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClient(Models.CreateClientViewModel clientModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(clientModel);
            }
            try
            {
                var client = await this.clientService.RegisterClientAsync(clientModel.ClientName);

                return Json(clientModel);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return BadRequest();
            }
        }


        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult CreateUser()
        {
            return View();
        }
        //ajax get
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await this.accountService.GetAccountsAsync();

            return Json(accounts.Select(ac => new
            {
                AccountId = ac.Id,
                Name = ac.Nickname
            }).ToList()
            );
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserViewModel userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(userModel);
            }
            try
            {
                var user = await this.userService.CreateUserAsync(userModel.Username, userModel.Password, userModel.Name);

                return Json(userModel);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(userModel);
            }
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await this.clientService.GetClientsAsync();

            return Json(clients.Select(x => new
            {
                ClientID = x.Id,
                ClientName = x.Name
            }).ToList()
            );
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(CreateAccounViewModel accountModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(accountModel);
            }
            try
            {
                var account = await this.accountService.RegisterAccountAsync(/*accountModel.AccountNumber,*/
                                                                             /* accountModel.Nickname,*/ accountModel.Balance, accountModel.ClientId);


                return Json(accountModel);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(accountModel);
            }
        }

        //Ajax
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this.userService.GetUsersAsync();

            var test = users;
            return Json(users.Select(u => new
            {
                UserId = u.Id,
                Name = u.Name
            }).ToList()
            );
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult AddUserAccount()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserAccount(AddUserAccountViewModel userAccountModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(userAccountModel);
            }
            try
            {
                var account = await this.userService.AddUserAccountAsync(userAccountModel.UserId, userAccountModel.AccountId);

                return Json(userAccountModel);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(userAccountModel);
            }
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBanner(CreateBannerViewModel bannerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(bannerModel);
            }
            try
            {
                var client = await this.clientService.RegisterClientAsync(bannerModel.ImgPath);

                return Json(bannerModel);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return BadRequest();
            }
        }


    }
}
