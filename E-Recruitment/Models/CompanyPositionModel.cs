using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class CompanyPositionModel
    {
        public string Position_ID { get; set; }
        public string Job_Title { get; set; }
        public string Directly_Reports_To { get; set; }
        public string Indirectly_Reports_To { get; set; }
        public string Designation_Group { get; set; }
        public string Job_Grade_ID { get; set; }
        public string Overall_Appointment_Authority { get; set; }
        public string Seniority_Level { get; set; }
        public string Directorate { get; set; }
        public string Department { get; set; }
        public string Minimum_Academic_Qualification { get; set; }
        public string Minimum_Mngmnt_Experience { get; set; }
        public string Default_Probation_Period { get; set; }
        public string Default_Duty_Station { get; set; }
        public string Effective_Date { get; set; }
        public string Travel_Frequency { get; set; }
        public string Work_Shift_Description { get; set; }
        public string Additional_Responsibilities { get; set; }
        public string No_of_Active_Contracts { get; set; }
        public string Loc_Relocation_Transfers { get; set; }
        public string Int_Relocation_Transfers { get; set; }
        public string Qualifies_for_Overtime { get; set; }
        public string Direct_Hire_Unit_Cost { get; set; }
        public string Average_Monthly_Salary_LCY { get; set; }
        public string Academic_Hierarchy_Code { get; set; }
        public string Executive_Summary_Job_Purpose { get; set; }
        public string Approved_Establishment { get; set; }
    }
}