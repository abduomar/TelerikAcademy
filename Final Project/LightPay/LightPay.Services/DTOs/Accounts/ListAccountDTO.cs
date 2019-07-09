using System;
using System.Collections.Generic;
using System.Text;
using LightPay.Models;

namespace LightPay.Services.DTOs.Accounts
{
    public class ListAccountDTO
    {
        public string AccountNumber { get; set; }

        public string Nickname { get; set; }

        public decimal Balance { get; set; }
    }
}
