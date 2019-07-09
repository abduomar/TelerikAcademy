using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class RenameAccountViewModel
    {

        public RenameAccountViewModel()
        {

        }

        public RenameAccountViewModel(Account account)
        {
            this.Id = account.Id;
            this.AccountNumber = account.AccountNumber;
            this.Nickname = account.Nickname;
            this.Balance = account.Balance;
            this.ClientName = account.Client.Name;
        }

        public Guid Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Nickname { get; set; }

        public decimal Balance { get; set; }

        public string ClientName { get; set; }

    }
}
