using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class EmploymentDetailsModel
    {
        [Required]
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }
        [Required]
        [Display(Name = "Job Title/Designation")]
        public string Designation { get; set; }
        [Required]
        [Display(Name = "Employment Start Date")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "Employment End Date")]
        public string EndDate { get; set; }
        [Required]
        [Display(Name = "Terms of Service")]
        public string TermsofService { get; set; }
        [Required]
        [Display(Name = "Total Number of Years of relevant work experience for this job")]
        public string TotalYears { get; set; }
        [Required]
        [Display(Name = "Summary of Duties And Responsibilities(Not more than 250 words)")]
        public string SummaryDetails { get; set; }
        public string EntryNumber { get; set; }

        
    }
}