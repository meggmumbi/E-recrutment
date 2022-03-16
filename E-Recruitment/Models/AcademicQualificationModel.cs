using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Recruitment.Models
{
    public class AcademicQualificationModel
    {
        
        [Display(Name = "Entry No")]
        public int EntryNo { get; set; }

        [Required]
        [Display(Name = "Educational Level")]
        public string EducationLevel { get; set; }

        [Required]
        [Display(Name = "University/Instituition/College")]
        public string Institution { get; set; }

        [Required]
        [Display(Name = "Academic Qualification Title")]
        public string QualificationTitle { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Specialization Area")]
        public string specializationArea { get; set; }

        [Required]
        [Display(Name = "Attained Score")]
        public string AttainedScore { get; set; }

        [Required]
        [Display(Name = "Graduation Year")]
        public string GraduationYear { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public List<AcademicQualificationModelList> list { get; set; }

    }
    public class AcademicQualificationModelList
    {
        
        public int EntryNo { get; set; }
        public string EducationLevel { get; set; }
        public string Institution { get; set; }
        public string QualificationTitle { get; set; }
        public string Country { get; set; }
        public string specializationArea { get; set; }
        public string AttainedScore { get; set; }
        public string GraduationYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}