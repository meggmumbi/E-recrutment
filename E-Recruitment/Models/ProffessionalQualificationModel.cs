using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class ProffessionalQualificationModel
    {
        public int EntryNo { get; set; }
        [Required]
        [Display(Name = "Proffessional Qualification Title")]
        public string ProffessionalQualification { get; set; }
        [Required]
        [Display(Name = "Institution")]
        public string Institution { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Qualification Title")]
        public string QualificationTitle { get; set; }
        [Required]
        [Display(Name = "Speciality")]
        public string Speciality { get; set; }
        [Required]
        [Display(Name = "Attained Score")]
        public string AttainedScore { get; set; }
        [Required]
        [Display(Name = "Completion Year")]
        public string CompletionYear { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        public string EntryNumber { get; set; }
    }
}