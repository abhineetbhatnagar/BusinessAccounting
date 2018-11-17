using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Customer
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Customer Name is required")]
        [Display(Name = "Customer Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public int country { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string state { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [Display(Name = "Pincode")]
        public string pin { get; set; }
        
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [Display(Name = "Mobile")]
        public string mobile { get; set; }

        [Required(ErrorMessage = "eMail is required")]
        [Display(Name = "eMail")]
        public string email { get; set; }

    }
}
