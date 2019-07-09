using LightPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Models
{
    public class AdminLoginViewModel
    {

        public AdminLoginViewModel()
        {

        }

        public AdminLoginViewModel(Administrator administrator)
        {
            this.Username = administrator.Username;
            this.Password = administrator.Password;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
