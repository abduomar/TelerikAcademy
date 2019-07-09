using LightPay.Data.Context;
using LightPay.Models;
using LightPay.Services.Interfaces;
using LightPay.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightPay.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly LightPayContext context;

        public AccountService(LightPayContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Account> RegisterAccountAsync(decimal balance, Guid clientId)
        {
            var client = await this.context.Clients
                .FirstOrDefaultAsync(cl => cl.Id == clientId);

            var accountNumber = CreateAccountNumber.CreateNumber();

            /*var existAccount = await this.context.Accounts
                .FirstOrDefaultAsync(an => an.AccountNumber == accountNumber);
              
            while (existAccount.AccountNumber == accountNumber)
            {
                accountNumber = CreateAccountNumber.CreateNumber();
            }*/

            var account = new Account()
            {
                AccountNumber = accountNumber,
                Nickname = accountNumber,
                Balance = balance,
                ClientId = clientId,
                CreatedOn = DateTime.Now
            };


            await this.context.Accounts.AddAsync(account);
            await this.context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> RenameAccountAsync(string accountNumber, string accountName)
        {
            var account = await this.context.Accounts
                .SingleOrDefaultAsync(a => a.AccountNumber == accountNumber);
            account.Nickname = accountName;

            await this.context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> GetAccount(string accountName)
        {
            var account = await this.context.Accounts
                .Include(a => a.Client)
                .SingleOrDefaultAsync(a => a.Nickname == accountName);
            return account;
        }

        public async Task<IReadOnlyCollection<Account>> ViewTransactions(string accountNumber)
        {
            return await this.context.Accounts
                .Include(ac => ac.OutgoingTransactions)
                .Include(ac => ac.IncomingTransactions)
                .Where(ac => ac.AccountNumber == accountNumber)
                .ToListAsync();
        }

        public async Task<decimal> GetAccountBalance(string accountNumber)
        {
            var accountBalance = (await this.context.Accounts
                .FirstOrDefaultAsync(ba => ba.AccountNumber == accountNumber)).Balance;

            return accountBalance;
        }

        public async Task<List<Account>> GetUserAccountsAsync(string userId)
        {
            return await this.context.UsersAccounts
               .Include(ac => ac.Account)
               .ThenInclude(a => a.Client)
               .Where(ac => ac.UserId.ToString() == userId)
               .Select(ua => ua.Account).ToListAsync();
            //return await this.context.Accounts
            //    .Include(a => a.UsersAccounts)
            //    .ThenInclude(ua => ua.User)
            //    .Select(a => new UsersAccounts { UserId = Guid.Parse(userId) })
            //    .ToListAsync();
        }


        public async Task<List<Account>> GetAccountsAsync()
        {
            return await this.context.Accounts
                .Include(a => a.OutgoingTransactions)
                .Include(a => a.IncomingTransactions)
                .Include(a => a.Client)
                .ToListAsync();
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await this.context.Accounts
               .ToListAsync();
        }
    }
}
