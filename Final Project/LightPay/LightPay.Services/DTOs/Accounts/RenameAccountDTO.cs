using LightPay.Models;
using System;

namespace LightPay.Services.DTOs.Accounts
{
    public class RenameAccountDTO
    {
        public Guid Id { get; set; }

        public string AccountNumber { get; set; }

        public string Nickname { get; set; }

        public decimal Balance { get; set; }

        public Client Client { get; set; }

        public string CurrentController { get; set; }

        public string CurrentAction { get; set; }
    }
}
