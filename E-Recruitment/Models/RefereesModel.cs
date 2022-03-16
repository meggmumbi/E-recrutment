using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class RefereesModel
    {
        [Required]
        [Display(Name = "Referee Type")]
        public string Refereetype { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "SurName")]
        public string SurName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }
        [Required]
        [Display(Name = "Other Names")]
        public string OtherNames { get; set; }
        [Required]
        [Display(Name = "Contact Person Designation/Title")]
        public string Designations { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Relationship")]
        public string Relationship { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "The Period from which the Referee have Known You")]
        public string knownyears { get; set; }
        [Required]
        [Display(Name = "Institution/Organization")]
        public string institution { get; set; }
        public string EntryNumber { get; set; }
        public string FullName { get; set; }
    }
}