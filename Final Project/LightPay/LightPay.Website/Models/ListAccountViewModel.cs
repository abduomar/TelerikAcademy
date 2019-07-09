using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Models
{
    public class ListAccountViewModel
    {
        public ListAccountViewModel()
        {

        }

        public ListAccountViewModel(Account account)
        {
            this.Id = account.Id;
            this.AccountNumber = account.AccountNumber;
            this.Nickname = account.Nickname;
            this.Balance = account.Balance;
            //this.ClientName = account.Client.Name;
            this.OutgoingTransactions = account.OutgoingTransactions;
            this.IncomingTransactions = account.IncomingTransactions;

        }

        public Guid Id { get; set; }

        public string AccountNumber { get; set; }

        public string Nickname { get; set; }

        public decimal Balance { get; set; }

        public string ClientName { get; set; }

        public ICollection<Transaction> OutgoingTransactions { get; set; }

        public ICollection<Transaction> IncomingTransactions { get; set; }

    }
}
