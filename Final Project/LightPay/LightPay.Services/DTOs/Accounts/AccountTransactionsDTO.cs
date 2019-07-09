using LightPay.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightPay.Services.DTOs.Accounts
{
    public class AccountTransactionsDTO
    {
        public string Nickname { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
