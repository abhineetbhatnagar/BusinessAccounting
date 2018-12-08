using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingPlanner.Models.SubUser
{
    public class SubUserModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "eMail is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [Display(Name = "Income")]
        public Char income { get; set; }

        [Display(Name = "Expense")]
        public Char expense { get; set; }

        [Display(Name = "Accounting")]
        public Char accounting { get; set; }

        [Display(Name = "Reports")]
        public Char reports { get; set; }

        [Display(Name = "Integration")]
        public Char integration { get; set; }

        [Display(Name = "Customer")]
        public Char customer { get; set; }

        [Display(Name = "Vendor")]
        public Char vendor { get; set; }

        [Display(Name = "Tax")]
        public Char tax { get; set; }

        [Display(Name = "Product")]
        public Char product { get; set; }
    }
}
