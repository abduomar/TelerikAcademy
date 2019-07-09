using LightPay.Models;
using LightPay.Services.DTOs.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Areas.Admin.Models
{
    public class ListClientsViewModel
    {


        public ListClientsViewModel()
        {
                
        }


        public ListClientsViewModel(ListClientDTO client)
        {
            this.Clients = client.Clients;
        }

        public ICollection<Client> Clients { get; set; }
    }
}
