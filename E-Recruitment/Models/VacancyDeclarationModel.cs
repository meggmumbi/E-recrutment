using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class VacancyDeclarationModel
    {
         public string VacancyNo { get; set; }
         public string DeclarationDecsription { get; set; }
        public string DeclarationResponse { get; set; }

        [Required]
        [Display(Name = "I agree with the Terms and Conditions.")]
        public bool accespted { get; set; }
    }
}