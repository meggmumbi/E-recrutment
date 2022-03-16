using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class ApplicantProfileMode
    {
        [Required(ErrorMessage ="Please choose Prefix Value")]
        [Display(Name = "Title *")]
        public string Prefix { get; set; }

        [Required]
        [Display(Name = "Surname *")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "First Name *")]
        public string Candidate_No { get; set; }

        [Required]
        [Display(Name = "Other Names *")]
        public string Othernames { get; set; }

        [Required]
        [Display(Name = "ID Number *")]
        public int? IDNumber { get; set; }

        [Required]
        [Display(Name = "First Name *")]
        public string First_Name { get; set; }

        [Required]
        [Display(Name = "Passport No")]
        public string Passport_No { get; set; }

        [Required]
        [Display(Name = "Date of Birth *")]
        public string DOB { get; set; }
        
        [Required]
        [Display(Name = "County of Residence *")]
        public string County_of_Residence { get; set; }

        [Required]
        [Display(Name = "County of Origin(Home County) *")]
        public string County_of_Birth { get; set; }


        [Display(Name = "N.H.I.F Number *")]
        public string NHIF { get; set; }

        [Display(Name = "N.S.S.F Number *")]
        public string NSSF { get; set; }

        [Required]
        [Display(Name = "KRA Pin *")]
        public string KRA_Pin { get; set; }

        [Required]
        [Display(Name = "Middle Name *")]
        public string Middle_Name { get; set; }

        [Required]
        [Display(Name = "Last Name *")]
        public string Last_Name { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email_Address { get; set; }

        [Required]
        [Display(Name = "Full Names *")]
        public string Full_Names { get; set; }

        [Required]
        [Display(Name = "City/Town *")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string Post_Code { get; set; }

        [Required]
        [Display(Name = "Mobile Phone Number *")]
        public string Phone_No { get; set; }

        [Required]
        [Display(Name = "Mobile Phone Number *")]
        public string Mobile_Phone_No { get; set; }
        
        [Required]
        [Display(Name = "Gender *")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Nationality *")]
        public string Country_Region_Code { get; set; }

        [Required]
        [Display(Name = "Are you a person Living with Disability *")]
        public int Disabled { get; set; }

        [Display(Name = "Address 2 *")]
        public string Address_2 { get; set; }

        [Required]
        [Display(Name = "Marital Status *")]
        public string Marital_Status { get; set; }

        [Required]
        [Display(Name = "Postal Address *")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Religion *")]
        public string Religion { get; set; }


        [Required]
        [Display(Name = "Ethnicity *")]
        public string Ethnic_Group { get; set; }

        [Required]
        [Display(Name = "Nationality *")]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "Highest Academic Qualifications *")]
        public string EducationLevel { get; set; }

        [Display(Name = "Disability Certificate No. *")]
        public string Disability_Code { get; set; }


         [Required]
        [Display(Name = "Description of Disability ")]
        public string Disability_Description { get; set; }
        
        [Display(Name = "Alternative Phone Number")]
        public string AlternativePhoneNumber { get; set; }

        [Display(Name = "Alternative Phone Number")]
        public string AlternativeEmailAddress { get; set; }


        [Required]
        [Display(Name = "Skills and Competencies(Not more than 2048 Characters *")]
        [MaxLength(2048)] 
        public string skillscompetencies { get; set; }

        [Required]
        [Display(Name = "Years of Relevant Work Experience * ")]
        public int workexperienceYears { get; set; }

        [Required]
        [Display(Name = "Years of Experience in Management Position or Leading Teams")]
        public int ManagementYears { get; set; }

        
        public bool areyoudisabled { get; set; }

    }
}