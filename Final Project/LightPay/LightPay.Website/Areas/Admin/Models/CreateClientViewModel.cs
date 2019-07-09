using LightPay.Models;
using LightPay.Services.DTOs.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Areas.Admin.Models
{
    public class CreateClientViewModel
    {
        public CreateClientViewModel()
        {

        }

        public CreateClientViewModel(Client client)
        {
            this.ClientName = client.Name;
        }

        [Required(ErrorMessage ="This field is required")]
        [MaxLength(35,ErrorMessage ="Client name mustn't be more than 35 characters")]
        public string ClientName { get; set; }
    }
}
