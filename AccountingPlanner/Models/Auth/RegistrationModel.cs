using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Auth
{
    public class RegistrationModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string name { get; set; }

        [Display(Name = "eMail")]
        [Required(ErrorMessage = "eMail is required")]
        [EmailAddress(ErrorMessage = "Enter a valid eMail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        public string cpassword { get; set; }
    }
}
