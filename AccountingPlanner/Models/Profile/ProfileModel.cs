using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.Models.Profile
{
    public class ProfileModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string name { get; set; }

        [Display(Name = "eMail")]
        [Required(ErrorMessage = "eMail is required")]
        public string email { get; set; }

        [Display(Name = "Phone")]
        public string phone { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Province")]
        public string province { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Postal/Zip Code")]
        public string pin { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string dob { get; set; }
    }

    public class AvatarModel
    {
        public IFormFile image { get; set; }
    }
}
