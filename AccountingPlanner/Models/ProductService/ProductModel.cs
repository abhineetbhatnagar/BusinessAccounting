using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.ProductService
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product type is required.")]
        [Display(Name = "Product Type")]
        public string type { get; set; }

        [Required(ErrorMessage = "Product title is required.")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Display(Name = "Price")]
        public string price { get; set; }

        [Display(Name = "Can be sold?")]
        public string is_sold { get; set; }

        [Display(Name = "Can be purchased?")]
        public string is_purchased { get; set; }
    }
}
