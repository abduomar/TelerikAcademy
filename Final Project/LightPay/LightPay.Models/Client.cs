using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LightPay.Models
{
    public class Client : BaseClass
    {
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
