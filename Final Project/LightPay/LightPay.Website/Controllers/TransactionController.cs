using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightPay.Services.Interfaces;
using LightPay.Website.Models;
using LightPay.Website.Paging;
using LightPay.Website.UtilitiesWeb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LightPay.Website.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService transactionService;
        private readonly IAccountService accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            this.transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService));
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }


        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<IActionResult> AllTransactions(string sortOrder, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["A/cNumSortParm"] = String.IsNullOrEmpty(sortOrder) ? "a/c_number_desc" : "";
            ViewData["AmmountSortParm"] = sortOrder == "Ammount" ? "ammount_desc" : "Ammount";


            var transactions = (await this.transactionService
                .GetTransactions())
                .Select(a => new ListTransactionViewModel(a))
                .AsQueryable();


            switch (sortOrder)
            {
                case "a/c_number_desc":
                    transactions = transactions.OrderByDescending(a => a.SenderAccountNumber);
                    break;
                case "Ammount":
                    transactions = transactions.OrderBy(a => a.Ammount);
                    break;
                case "ammount_desc":
                    transactions = transactions.OrderByDescending(a => a.Ammount);
                    break;
                default:
                    transactions = transactions.OrderBy(a => a.Ammount);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<ListTransactionViewModel>.CreateAsync(transactions.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        //Ajax get user's account
        [HttpGet]
        public async Task<IActionResult> GetUserAccounts()
        {
            //var userId = this.User.GetId();
            var accounts = await this.accountService.GetUserAccountsAsync(this.User.GetId());

            return Json(accounts.Select(ac => new
            {
                AccountId = ac.Id,
                Name = ac.Nickname,
                Cient = ac.ClientId,
                ClientName = ac.Client.Name
            }).ToList()
            );
        }

        //ajax get all accounts
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await this.accountService.GetAccountsAsync();

            return Json(accounts.Select(ac => new
            {
                value = ac.Nickname
            }).ToList()
            );
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

        [HttpGet]
        [Authorize]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IActionResult CreateTransaction()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction(MakePaymentViewModel paymentModel)
        {

            if (Request.Form["submitbutton1"] != (string)null)
            {


                if (!this.ModelState.IsValid)
                {
                    return View(paymentModel);
                }
                try
                {
                    var transaction = await this.transactionService.MakePayment(paymentModel.SenderAccountName,
                        paymentModel.Ammount, paymentModel.RecieverAccountName, paymentModel.Description, false);

                    return RedirectToAction("AllTransactions", "Transaction");
                }
                catch (ArgumentException ex)
                {
                    this.ModelState.AddModelError("Error", ex.Message);
                    return View(paymentModel);
                }
            }
            else if (Request.Form["submitButton2"] != (string)null)
            {
                if (!this.ModelState.IsValid)
                {
                    return View(paymentModel);
                }
                try
                {
                    var transaction = await this.transactionService.MakePayment(paymentModel.SenderAccountName,
                        paymentModel.Ammount, paymentModel.RecieverAccountName, paymentModel.Description, true);

                    return RedirectToAction("AllTransactions", "Transaction");
                }
                catch (ArgumentException ex)
                {
                    this.ModelState.AddModelError("Error", ex.Message);
                    return View(paymentModel);
                } 
            }

            return View(paymentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTransaction([FromBody]MakePaymentViewModel paymentModel)
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
    }
}