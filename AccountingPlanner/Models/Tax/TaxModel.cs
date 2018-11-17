using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Tax
{
    public class TaxModel
    {
        [Required(ErrorMessage = "Tax header is required")]
        [Display(Name = "Tax Label")]
        public string header { get; set; }

        [Required(ErrorMessage = "Tax type is required")]
        [Display(Name = "Type")]
        public string type { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Display(Name = "Value of Tax")]
        public int value { get; set; }

        [Required(ErrorMessage = "Tax applicability is required")]
        [Display(Name = "Applicability")]
        public string applicability { get; set; }

    }
}
