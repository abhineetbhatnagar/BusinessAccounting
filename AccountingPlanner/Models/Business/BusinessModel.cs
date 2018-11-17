using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Business
{
    public class BusinessModel
    {
        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Organization name is required")]
        public string name { get; set; }

        [Display(Name = "Organization Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public IFormFile logo { get; set; }

        public string logo_url { get; set; }

        [Display(Name = "Type of business")]
        [Required(ErrorMessage = "Type of business is required")] 
        public string type_of_business { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string address_line_1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string address_line_2 { get; set; }

        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City is required")] 
        public string city { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")] 
        public string state { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string country { get; set; }

        [Display(Name = "Pin")]
        [Required(ErrorMessage = "Pin is required")]
        public string pin { get; set; }

        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Display(Name = "Fax")]
        public string fax { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile is required")]
        public string mobile { get; set; }

        [Display(Name = "Toll Free")]
        public string toll_free { get; set; }

        [Display(Name = "Website")]
        public string website { get; set; }

        [Display(Name = "Currency")]
        [Required(ErrorMessage = "Currency is required")]
        public string currency { get; set; }

        [Display(Name = "Type of Organization Name")]
        [Required(ErrorMessage = "Type of Organization is required")]
        public string type_of_organization { get; set; }
    }
}
