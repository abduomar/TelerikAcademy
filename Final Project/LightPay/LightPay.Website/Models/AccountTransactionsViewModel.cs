using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Models
{
    public class AccountTransactionsViewModel
    {

        public AccountTransactionsViewModel()
        {

        }

        public AccountTransactionsViewModel(AccountTransactionsDTO accountTransactions)
        {
            this.Nickname = accountTransactions.Nickname;
            this.Transactions = accountTransactions.Transactions.OrderByDescending(t => t.CreatedOn).ToList();
        }

        public string Nickname { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
