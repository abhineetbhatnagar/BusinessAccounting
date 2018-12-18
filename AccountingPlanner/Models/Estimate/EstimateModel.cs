using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Estimate
{
    public class EstimateModel
    {
        [Required(ErrorMessage = "Customer is required")]
        [Display(Name = "Customer")]
        public string cutomer { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [Display(Name = "Currency")]
        public string currency { get; set; }
        
        [Required(ErrorMessage = "Label is required")]
        [Display(Name = "Title")]
        public string header { get; set; }

        [Required(ErrorMessage = "Version is required")]
        [Display(Name = "Version")]
        public string version { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        public string date { get; set; }

        [Required(ErrorMessage = "Subhead is required")]
        [Display(Name = "Subhead")]
        public string subhead { get; set; }

        [Required(ErrorMessage = "Footer is required")]
        [Display(Name = "Footer")]
        public string footer { get; set; }

        [Required(ErrorMessage = "Expirey is required")]
        [Display(Name = "Expires On")]
        public string expires { get; set; }

        [Required(ErrorMessage = "PO/SO is required")]
        [Display(Name = "P.O/S.O")]
        public string po_so { get; set; }

        [Required(ErrorMessage = "Memo is required")]
        [Display(Name = "Memo")]
        public string memo { get; set; }

        [Required]
        public List<EstimateDetailModel> estimateDetailList { get; set; }
    }

    public class EstimateDetailModel
    {
        [Required]
        public string tax { get; set; }
        [Required]
        public string product { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string quantity { get; set; }
        [Required]
        public string price { get; set; }
        [Required]
        public string amount { get; set; }
    }
}
