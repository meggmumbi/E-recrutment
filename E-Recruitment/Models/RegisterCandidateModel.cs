using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class RegisterCandidateModel
    {
        [Required(ErrorMessage  = "Enter a Valid ID No/Passport No.")]
        [Display(Name ="ID No/Passport No.")]
        public string IdNumber { get; set; }

    
        [Required(ErrorMessage= "Enter a Valid SurName")]
        [Display(Name = "SurName")]
        public string SurName { get; set; }

        
        [Required(ErrorMessage = "Enter a Valid First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        public string OtherNames { get; set; }

        [Required(ErrorMessage = "Enter a Valid Email Address")]
        [Display(Name = "Primar Email Address")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

       
        [Display(Name = "Agree to terms and conditions")]
        [Required(ErrorMessage= "Please Agree to our terms and conditions")]
        public bool TermsandConditions { get; set; }
    }
}