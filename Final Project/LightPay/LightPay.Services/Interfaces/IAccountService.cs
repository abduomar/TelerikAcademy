using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightPay.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> RegisterAccountAsync( decimal balance, Guid clientId);

        Task<Account> RenameAccountAsync(string accountNumber, string accountName);

        Task<Account> GetAccount(string accountName);

        Task<IReadOnlyCollection<Account>> ViewTransactions(string accountNumber);

        Task<decimal> GetAccountBalance(string accountNumber);

        Task<List<Account>> GetUserAccountsAsync(string userId);

        Task<List<Account>> GetAccountsAsync();

        Task<List<Account>> GetAllAccountsAsync();

    }
}
