using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarbucksStore.Models
{
    public class Register
    {   
        [Display(Name = "Store name")]
        public string StoreName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email-address")]
        public string PersonEmail { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string PersonFirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string PersonLastName { get; set; }
    }
}
