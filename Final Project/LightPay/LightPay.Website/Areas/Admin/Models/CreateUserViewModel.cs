using LightPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LightPay.Website.Models
{
    public class CreateUserViewModel
    {

        public CreateUserViewModel()
        {

        }

        public CreateUserViewModel(User user)
        {
            this.Name = user.Name;
            this.Username = user.Username;
            this.Password = user.Password;
        }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(35, ErrorMessage = "Name mustn't be more than 35 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(16, ErrorMessage = "Client name mustn't be more than 16 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [MaxLength(32, ErrorMessage = "Client name mustn't be more than 32 characters")]
        public string Password { get; set; }


        //трябва да може да приема и акаунти

        //public ICollection<Account> Accounts { get; set; }

    }
}
