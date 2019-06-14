using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlassesShop.Areas.GlassesAdmin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập User Name:")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Mời nhập PassWord:")]
        public string password { set; get; }
        public bool RememberMe { set; get; }
    }
}