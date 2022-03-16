using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please provide a valid Email Address")]
        [Display(Name = "Email Address or Employee Number")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please provide a valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        

    }
}