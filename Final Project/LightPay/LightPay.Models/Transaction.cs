using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LightPay.Models
{
    public class Transaction : BaseClass
    {
        public Guid SenderAccountId { get; set; }

        public Guid RecieverAccountId { get; set; }

        public Account SenderAccount { get; set; }

        public Account RecieverAccount { get; set; }

        public string Description { get; set; }

        public decimal Ammount { get; set; }

        public bool IsSaved { get; set; }
    }
}
