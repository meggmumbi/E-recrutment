using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace E_Recruitment.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        //[AllowFileSize(FileSize = 90 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 5 MB")]
        public HttpPostedFileBase[] statutory { get; set; }
        public HttpPostedFileBase[] applicationletter { get; set; }
        public HttpPostedFileBase[] qualifications { get; set; }
        public HttpPostedFileBase[] proposals { get; set; }
        public HttpPostedFileBase[] files { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string EaccClearence { get; set; }
        public string PoliceClearance { get; set; }
        public string KRApin { get; set; }
        public string HelbClearance { get; set; }
        public string CRBClearance { get; set; }
        public string ApplicationLetter { get; set; }
        public string Resume { get; set; }
        public string AcademicQualification { get; set; }
        public string ProfessionalQualification { get; set; }
        public string Journals { get; set; }
        public string Testimonials { get; set; }

    }
}