using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class CreateAccounViewModel
    {

        public CreateAccounViewModel()
        {

        }

        public CreateAccounViewModel(CreateAccountDTO account)
        {
           
            this.Balance = account.Balance;
            this.ClientId = account.Client.Id;
        }

        [Required(ErrorMessage = "This field is required")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public Guid ClientId { get; set; }


       

    }
}
