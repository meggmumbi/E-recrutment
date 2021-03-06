using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class JobRequirementModel
    {
        public string Document_No { get; set; }
        public string Document_Type { get; set; }
        public string Requirement_ID { get; set; }
        public string Qualification_Category { get; set; }
        public string Description { get; set; }
        public string Requirement_Type { get; set; }
        public string Substitute_Qualification_Exist { get; set; }
        public string Line_No { get; set; }
        public string Qualification_Code { get; set; }
    }
}