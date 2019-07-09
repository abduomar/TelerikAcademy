using LightPay.Models;
using System;
using System.Collections.Generic;

namespace LightPay.Services.DTOs.Accounts
{
    public class CreateAccountDTO
    {
        public string AccountNumber { get; set; }

        public string Nickname { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public User User { get; set; }

    }
}
