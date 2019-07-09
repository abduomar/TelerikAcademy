using LightPay.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class MakePaymentViewModel
    {
        public MakePaymentViewModel()
        {

        }

        public MakePaymentViewModel(Transaction payment)
        {
            this.SenderAccountName = payment.SenderAccount.Nickname;
            this.RecieverAccountName = payment.RecieverAccount.Nickname;

            this.PayerClientName = payment.SenderAccount.Client.Name;
            this.PayeeClientName = payment.RecieverAccount.Client.Name;

            this.Ammount = payment.Ammount;
            this.Description = payment.Description;
            this.CreatedOn = DateTime.Now;
        }

        [Required]
        public string SenderAccountName { get; set; }

        [Required]
        public string RecieverAccountName { get; set; }

        public string PayerClientName { get; set; }

        public string PayeeClientName { get; set; }

        [Required]
        [MaxLength(35)]
        public string Description { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}