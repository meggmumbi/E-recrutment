using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class ProfessionalBodiesModel
    {
        [Required]
        [Display(Name = "Professional Body *")]
        public string ProffessionalBody { get; set; }
        [Required]
        [Display(Name = "MemberShip/Registration No *")]
        public string RegistrationNo { get; set; }
        [Required]
        [Display(Name = "Membership Type *")]
        public string MembershipType { get; set; }
        [Required]
        [Display(Name = "Membership Renewal Date *")]
        public string MembershipDateRenewal { get; set; }
        [Required]
        [Display(Name = "License Number *")]
        public string LicensingNumber { get; set; }
        [Required]
        [Display(Name = "License Renewal Date *")]
        public string licensingDateRenewal { get; set; }
        public string EntryNumber { get; set; }
    }
}