using System;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Services.DTOs.Transactions
{
    public class MakePaymentDTO
    {
        public Guid SenderAccountId { get; set; }

        public Guid RecieverAccountId { get; set; }

        public string Description { get; set; }

        public decimal Ammount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}
