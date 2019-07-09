using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LightPay.Models
{
    public class Account : BaseClass
    {
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string Nickname { get; set; }

        public decimal Balance { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<UsersAccounts> UsersAccounts { get; set; }

        public ICollection<Transaction> OutgoingTransactions { get; set; }

        public ICollection<Transaction> IncomingTransactions { get; set; }

    }
}
