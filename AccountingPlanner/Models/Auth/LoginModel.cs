using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Auth
{
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required.")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is  required.")]
        public string password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
