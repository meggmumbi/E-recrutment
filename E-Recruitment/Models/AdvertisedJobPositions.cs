using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Recruitment.Models
{
    public class AdvertisedJobPositions
    {
        public string Document_No { get; set; }
        public string ApplicationClosingDateTime { get; set; }
        public string Document_Date { get; set; }
        public string Recruitment_Plan_ID { get; set; }
        public string Position_ID { get; set; }
        public string Requester_ID { get; set; }
        public string Requester_Staff_No { get; set; }
        public string Requester_Name { get; set; }
        public string Department { get; set; }
        public string Directorate { get; set; }
        public string Region { get; set; }
        public string Finacial_Year_Code { get; set; }
        public string Created_By { get; set; }
        public string Created_On { get; set; }
        public string No_of_Openings { get; set; }
        public string Staff_Establishment { get; set; }
        public string Approval_Status { get; set; }
        public string Created_Time { get; set; }
        public string Recruitment_Justification { get; set; }
        public string Current_Headcount { get; set; }
        public string Target_Candidate_Source { get; set; }
        public string Planned_Recruitment_Start_Date { get; set; }
        public string Recruitment_Lead_Time { get; set; }
        public string Job_No { get; set; }
        public string Vacancy_Status { get; set; }
        public string Vacancy_Announcement_ID { get; set; }
        public string Vacancy_No { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public string Date_Published { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public string Application_Closing_Date { get; set; }

        public string Application_Closing_Time { get; set; }
        public string No_of_Applications { get; set; }
        public string No_of_Filled_Posts { get; set; }
        public string Job_Title_Designation { get; set; }
        public string Duty_Station_ID { get; set; }
        public string Work_Location_Details { get; set; }
        public string Document_Type { get; set; }
        public string Job_Grade_ID { get; set; }
        public string Employment_Type { get; set; }
        public string Default_Terms_of_Service_Code { get; set; }
        public string Seniority_Level { get; set; }
        public string Functionally_Reports_To { get; set; }
        public string Hierarchically_Reports_To { get; set; }
        public string Estimate_Annual_Salary { get; set; }
    }
}