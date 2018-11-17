using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Vendor
{
    public class VendorModel
    {
        [Required(ErrorMessage = "Venor name is required")]
        [Display(Name = "Vendor Name")]
        public string vendor_name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address Name")]
        public string address { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country Name")]
        public string country { get; set; }

        [Required(ErrorMessage = "State/Province is required")]
        [Display(Name = "State/Province Name")]
        public string province { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "Pin is required")]
        [Display(Name = "Pin")]
        public string pin { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Fax is required")]
        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Required(ErrorMessage = "eMail is required")]
        [Display(Name = "eMail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mobile is required")]
        [Display(Name = "Mobile")]
        public string mobile { get; set; }
    }
}
