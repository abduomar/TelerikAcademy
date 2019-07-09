using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class ClientNameViewModel
    {

        public ClientNameViewModel()
        {

        }

        public ClientNameViewModel(Account account)
        {
            this.AccountName = account.Nickname;
        }

        [Required]
        public string AccountName { get; set; }

    }
}
