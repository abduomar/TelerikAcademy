using LightPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightPay.Website.Areas.Admin.Models
{
    public class CreateBannerViewModel
    {

        public CreateBannerViewModel()
        {

        }

        public CreateBannerViewModel(Banner banner)
        {
            this.ImgPath = banner.ImgPath;
            this.ImgUrl = banner.ImgUrl;
        }

        [Required(ErrorMessage = "This field is required")]
        public string ImgPath { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ImgUrl { get; set; }


    }
}
