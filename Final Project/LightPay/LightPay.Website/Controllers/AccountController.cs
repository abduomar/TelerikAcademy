using LightPay.Services.Interfaces;
using LightPay.Website.Models;
using LightPay.Website.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using LightPay.Models;
using Microsoft.EntityFrameworkCore;
using LightPay.Website.UtilitiesWeb;

namespace LightPay.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ITransactionService transactionService;

        public AccountController(IAccountService accountService, ITransactionService transactionService)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
        }


        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<IActionResult> AllAccounts(string sortOrder, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["A/cNumSortParm"] = String.IsNullOrEmpty(sortOrder) ? "a/c_number_desc" : "";
            ViewData["BalanceSortParm"] = sortOrder == "Balance" ? "balance_desc" : "Balance";


            var accounts = (await this.accountService
                .GetAccountsAsync())
                .Select(a=>new ListAccountViewModel(a))
                .AsQueryable();


            switch (sortOrder)
            {
                case "a/c_number_desc":
                    accounts = accounts.OrderByDescending(a=>a.AccountNumber);
                    break;
                case "Balance":
                    accounts = accounts.OrderBy(a => a.Balance);
                    break;
                case "balance_desc":
                    accounts = accounts.OrderByDescending(a => a.Balance);
                    break;
                default:
                    accounts = accounts.OrderBy(a => a.Balance);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<ListAccountViewModel>.CreateAsync(accounts.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        [HttpGet]
        [Authorize]
        public IActionResult RenameAccount(Guid id, string accountNumber, string nickname,decimal balance,string clientName)
        {
            var account = new RenameAccountViewModel()
            {
                Id = id,
                AccountNumber = accountNumber,
                Nickname = nickname,
                Balance=balance,
                ClientName=clientName
            };

            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        // POST: Rename Data with AJAX
        public async Task<IActionResult> RenameAccount(RenameAccountViewModel accountModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(accountModel);
            }
            try
            {
                var account = await this.accountService.RenameAccountAsync(accountModel.AccountNumber, accountModel.Nickname);



                return RedirectToAction("AllAccounts","Account");
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(accountModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await this.accountService.GetAccountsAsync();

            return Json(accounts.Select(ac => new
            {
                category = ac.Nickname,
                value=ac.Balance
            }).ToList()
            );
        }

        [HttpGet]
        [Authorize]
        public IActionResult AccountTransactions(string accountNickname)
        {
            var accountTransactions = new AccountTransactionsViewModel()
            {
                Nickname = accountNickname
            };

            return View(accountTransactions);
        }


        [HttpGet]
        [Authorize]
        public IActionResult CreateAccountTransaction(string accountNickname)
        {
            var transaction = new MakePaymentViewModel()
            {

                SenderAccountName = accountNickname,
               
            };

            return View(transaction);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccountTransaction([FromBody]MakePaymentViewModel paymentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(paymentModel);
            }
            try
            {
                var transaction = await this.transactionService.MakePayment(paymentModel.SenderAccountName,
                    paymentModel.Ammount, paymentModel.RecieverAccountName, paymentModel.Description, false);

                this.TempData["Success-Message"] = "Successful payment";

                return new JsonResult(paymentModel);
                //return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(paymentModel);
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAccountTransaction([FromBody]MakePaymentViewModel paymentModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(paymentModel);
            }
            try
            {
                var transaction = await this.transactionService.MakePayment(paymentModel.SenderAccountName,
                    paymentModel.Ammount, paymentModel.RecieverAccountName, paymentModel.Description, true);

                this.TempData["Success-Message"] = "Successful payment";

                return new JsonResult(paymentModel);
                //return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(paymentModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetClientName([FromBody]ClientNameViewModel model)
        {
            var account = await this.accountService.GetAccount(model.AccountName);

            return Json(new
            {
                ClientName = account.Client.Name
            });
        }

    }
}