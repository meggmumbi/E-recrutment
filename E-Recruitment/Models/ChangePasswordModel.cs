using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Please provide a valid Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter Registered Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a valid Old Password")]
        [Display(Name = "Enter Old Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide a valid New Password")]
        [Display(Name = "Enter New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please provide a valid Confirmation Password")]
        [Display(Name = "Confirm New Password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (NewPassword == Password)
                yield return new ValidationResult("New Password and Old Password should not be the same");
        }

    }
}