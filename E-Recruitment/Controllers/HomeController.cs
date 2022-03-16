using CaptchaMvc.HtmlHelpers;
using E_Recruitment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Recruitment.Controllers
{
    [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        [HttpGet]
        [HandleError]
        public ActionResult Index()
        {

            dynamic model = new ExpandoObject();
            model.AllOpenJobVacancies = GetOpenJobAvertisements();
            model.AllClosedJobVacancies = GetClosedJobAvertisements();
            model.AllContractJobVacancies = GetOpenContractJobAvertisements();
            model.AllPermanentJobVacancies = GetOpenPermanentJobAvertisements();
            return View(model);
        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpenPermanentJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Employment_Type == "Permanent" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpenContractJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Employment_Type == "Contract" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpeInternshipJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Employment_Type == "Internship" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpenAttachmentJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Employment_Type == "Attachment" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpenJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                    jobs.ApplicationClosingDateTime = jobs.Application_Closing_Date + " " + jobs.Application_Closing_Time;
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetOpenJobAvertisementsforApplications()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff" && x.Employment_Type != "Internship" && x.Employment_Type != "Attachment").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.ApplicationClosingDateTime = jobs.Application_Closing_Date + " " + jobs.Application_Closing_Time;
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetCancelledobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Employment_Type == "Permanent" && x.Vacancy_Status == "Cancelled" && x.Approval_Status == "Released" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AdvertisedJobPositions> GetClosedJobAvertisements()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Closed" && x.Approval_Status == "Released" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<JobRequirementModel> GetJobRequirements()
        {

            List<JobRequirementModel> list = new List<JobRequirementModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobVacancyRequirement.Where(x => x.Document_Type == "Job Vacancy").ToList();
                foreach (var jobRequirements in query)
                {
                    JobRequirementModel requirements = new JobRequirementModel();
                    requirements.Document_Type = jobRequirements.Document_Type;
                    requirements.Document_No = jobRequirements.Document_No;
                    requirements.Requirement_Type = Convert.ToString(jobRequirements.Requirement_Type);
                    requirements.Qualification_Category = jobRequirements.Qualification_Category;
                    requirements.Description = jobRequirements.Description;
                    list.Add(requirements);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = Membership.GetUser(UserName);

            return Json(user == null);
        }
        [HttpGet]
        public ActionResult HowtoApply()
        {

            return View();
        }
        [HttpGet]
        public ActionResult MyReferees()
        {
            dynamic model = new ExpandoObject();
            var ApplicantNumber = Session["ApplicantNo"].ToString();
            model.Referees = GetCandidateReferees(ApplicantNumber);
            return View(model);
        }
        [HttpGet]
        public ActionResult About()
        {

            return View();
        }
        [HttpGet]
        public ActionResult EducationBackground()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.AcademicsQualification = GetAcademicQualifications(ApplicantNumber);
                return View(model);


            }
        }
        [HttpGet]
        public ActionResult ProffessionalQualifications()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.ProffessionalQualification = GetProffessionalQualification(ApplicantNumber);
                return View(model);


            }
        }
        [HttpGet]
        public ActionResult ProffessionalBodies()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.ProffessionalBodies = GetProffessionalBodies(ApplicantNumber);
                return View(model);


            }
        }
        public static class Crypto
        {
            public static string Hash(string value)
            {
                return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(value)));
            }
        }

        [HttpGet]
        public ActionResult PracticingLicence()
        {

            return View();
        }

        [HandleError]
        public ActionResult RedirectonExecption()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return RedirectToAction("Dashboard", "Home");
            }
        }
        public ActionResult Dashboard()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic model = new ExpandoObject();
                model.AllOpenJobVacancies = GetOpenJobAvertisementsforApplications();
                model.AllClosedJobVacancies = GetClosedJobAvertisements();
                model.AllContractJobVacancies = GetOpenContractJobAvertisements();
                model.AllPermanentJobVacancies = GetOpenPermanentJobAvertisements();
                return View(model);
            }
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult AdvertisedInternships()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                if (Session["ApplicantNo"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Employment_Type == "Internship" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                    foreach (var openjobs in query)
                    {
                        AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                        jobs.Job_No = openjobs.Job_No;
                        jobs.Document_No = openjobs.Document_No;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                        jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                        jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                        jobs.Employment_Type = openjobs.Employment_Type;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                        jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                        jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                        jobs.Work_Location_Details = openjobs.Work_Location_Details;
                        jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                        jobs.Vacancy_No = openjobs.Vacancy_No;
                        jobs.Vacancy_Status = openjobs.Vacancy_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                        jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                        jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                        jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                        list.Add(jobs);

                    }
                }
            }

            catch (Exception ex)
            {

                throw;
            }

            return View(list);
        }
        public ActionResult Footer()
        {

            return View();
        }
        public ActionResult NavigationMenu()
        {
            return View();
        }
        [HandleError]
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterCandidateModel signupmodel)
        {
            // Code for validating the Captcha  
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                try
                {
                    if (string.IsNullOrEmpty(signupmodel.IdNumber))
                    {
                        TempData["error"] = "Please enter your Valid ID/Passport Number";
                    }
                    if (string.IsNullOrEmpty(signupmodel.SurName))
                    {
                        TempData["error"] = "Please enter your Surname";
                    }
                    if (string.IsNullOrEmpty(signupmodel.FirstName))
                    {
                        TempData["error"] = "Please enter your FirstName";
                    }
                    if (string.IsNullOrEmpty(signupmodel.OtherNames))
                    {
                        signupmodel.OtherNames = "";
                    }
                    if (string.IsNullOrEmpty(signupmodel.EmailAddress))
                    {
                        TempData["error"] = "Please enter your Valid Email Address";
                    }
                    if (string.IsNullOrEmpty(signupmodel.PhoneNumber))
                    {
                        TempData["error"] = "Please enter your Valid Mobile Phone Number";
                    }
                    if (signupmodel.TermsandConditions == false)
                    {
                        TempData["error"] = "Please Agree to Our Terms and Conditions before your procced";
                    }
                    else
                    {
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnRegistration(signupmodel.IdNumber, signupmodel.SurName, signupmodel.FirstName, signupmodel.OtherNames, signupmodel.EmailAddress.ToLower(), signupmodel.PhoneNumber);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success"] = "Your Account Creation Request have been successfully submitted.Kindly Check your Email Account for More Details!";
                        }
                        else
                        {
                            TempData["error"] = "Your Account Creation Request could not be submitted." + res[1];
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Your Account Creation Request could not be submitted." + ex.Message;
                }
            }
            else
            {
                TempData["error"] = "The reCapture Output is not correct.Kindly ensure you provide correct answer ";

            }
            return View(signupmodel);
        }
        [HandleError]
        public JsonResult JobApplication(string VacancyID)
        {
            try
            {


                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var status = nav.FnJobApplication(ApplicantNumber, VacancyID);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "profileincomplete":
                        return Json("profileincomplete*" + res[1], JsonRequestBehavior.AllowGet);
                    case "success":
                        Session["JobApplicationNumber"] = res[2];
                        MoveAllCandidatefiles(res[2]);
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HandleError]
        public JsonResult SubmitInternshipApplication(string VacancyID)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var status = nav.FnJobApplication(ApplicantNumber, VacancyID);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        Session["JobApplicationNumber"] = res[2];
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HandleError]
        public JsonResult SubmitAttachmentApplication(string VacancyID)
        {
            try
            {

                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var status = nav.FnJobApplication(ApplicantNumber, VacancyID);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        Session["JobApplicationNumber"] = res[2];
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HandleError]
        public ActionResult Countries()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountriesModel> list = new List<CountriesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.countries.ToList();
                    foreach (var countries in query)
                    {
                        CountriesModel country = new CountriesModel();
                        country.CountryId = countries.Code;
                        country.CountryName = countries.Name;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult RefereeCountries()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountriesModel> list = new List<CountriesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.countries.ToList();
                    foreach (var countries in query)
                    {
                        CountriesModel country = new CountriesModel();
                        country.CountryId = countries.Code;
                        country.CountryName = countries.Name;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }

        [HandleError]
        public ActionResult AcademicSpecializationAreas()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<SpecializationAreaModel> list = new List<SpecializationAreaModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.SpecializationAreas.ToList();
                    foreach (var specializations in query)
                    {
                        SpecializationAreaModel specialization = new SpecializationAreaModel();
                        specialization.Code = specializations.Code;
                        specialization.Name = specializations.Description;
                        list.Add(specialization);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult EditSpecializationAreas()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<SpecializationAreaModel> list = new List<SpecializationAreaModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.SpecializationAreas.ToList();
                    foreach (var specializations in query)
                    {
                        SpecializationAreaModel specialization = new SpecializationAreaModel();
                        specialization.Code = specializations.Code;
                        specialization.Name = specializations.Description;
                        list.Add(specialization);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult EducationCountries()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountriesModel> list = new List<CountriesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.countries.ToList();
                    foreach (var countries in query)
                    {
                        CountriesModel country = new CountriesModel();
                        country.CountryId = countries.Code;
                        country.CountryName = countries.Name;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult ProfessionalQualificationCountries()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountriesModel> list = new List<CountriesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.countries.ToList();
                    foreach (var countries in query)
                    {
                        CountriesModel country = new CountriesModel();
                        country.CountryId = countries.Code;
                        country.CountryName = countries.Name;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult PostCodes()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<PostCodesModel> list = new List<PostCodesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.postcodes.ToList();
                    foreach (var postcodes in query)
                    {
                        PostCodesModel country = new PostCodesModel();
                        country.Code = postcodes.Code;
                        country.City = postcodes.Code;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }

        [HandleError]
        public ActionResult Counties()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<PostCodesModel> list = new List<PostCodesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.postcodes.ToList();
                    foreach (var postcodes in query)
                    {
                        PostCodesModel country = new PostCodesModel();
                        country.Code = postcodes.Code;
                        country.City = postcodes.City;
                        list.Add(country);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }
        [HandleError]
        public ActionResult OriginCounty()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountiesModel> list = new List<CountiesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.Counties.ToList();
                    foreach (var counties in query)
                    {
                        CountiesModel county = new CountiesModel();
                        county.Code = counties.Code;
                        county.Name = counties.County_Name;
                        list.Add(county);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return View(list);
            }
        }
        public JsonResult SelectedPosta(string postcode)
        {
            List<DropdownListsModel> postacode = new List<DropdownListsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.postcodes.ToList();
                foreach (var postacodes in query)
                {
                    DropdownListsModel postcodes = new DropdownListsModel();
                    postcodes.Code = postacodes.Code;
                    postcodes.City = postacodes.City;
                    postcodes.CountryName = postacodes.Country_Region_Code;
                    postacode.Add(postcodes);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            var result = (from a in postacode where a.Code == postcode select a.City).FirstOrDefault();

            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json("notfound", JsonRequestBehavior.AllowGet);
        }
        [HandleError]
        public ActionResult Ethnicities()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<EthnicitiesModel> list = new List<EthnicitiesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.EthnicBackground.ToList();
                    foreach (var ethnicities in query)
                    {
                        EthnicitiesModel ethnicity = new EthnicitiesModel();
                        ethnicity.Code = ethnicities.Code;
                        ethnicity.Name = ethnicities.Ethnic_group;
                        list.Add(ethnicity);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }

        [HandleError]
        public ActionResult ResidenceCounties()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<CountiesModel> list = new List<CountiesModel>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.Counties.ToList();
                    foreach (var counties in query)
                    {
                        CountiesModel county = new CountiesModel();
                        county.Code = counties.Code;
                        county.Name = counties.County_Name;
                        list.Add(county);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

                return View(list);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SubmitJobApplication()
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnSubmitApplication(ApplicantNumber, JobApplicationNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SubmitCandidateProfile()
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnSubmitProfileApplication(ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(ChangePasswordModel passwordmodel)
        {
            try
            {
                if (string.IsNullOrEmpty(passwordmodel.Email))
                {
                    return Json("missingfield*" + "Please enter your valid Email Address", JsonRequestBehavior.AllowGet);
                }
                else
                {

                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnResetPassword(passwordmodel.Email);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        TempData["success"] = "Your Password has been reset successfully. Kindly Check your email for more details";
                    }
                    else
                    {
                        TempData["error"] = "Your Password could not been reset successfully" + res[1];

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Your Password could not been reset successfully" + ex.Message;
            }

            return View(passwordmodel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangePassword(ChangePasswordModel passwordmodel)
        {
            try
            {
                if (string.IsNullOrEmpty(passwordmodel.Email))
                {
                    TempData["error"] = "Please enter your valid Email Address";
                }
                if (string.IsNullOrEmpty(passwordmodel.Email))
                {
                    TempData["error"] = "Please enter your valid Old Password";
                }
                if (string.IsNullOrEmpty(passwordmodel.Password))
                {
                    TempData["error"] = "Please enter your valid new Password";
                }
                if (string.IsNullOrEmpty(passwordmodel.ConfirmPassword))
                {
                    TempData["error"] = "Please Confirm your Password";
                }
                if (passwordmodel.ConfirmPassword != passwordmodel.NewPassword)
                {
                    TempData["error"] = "Ensure that your New Password and Confirm Password Match";
                }
                else
                {
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnChangeCandidatePassword(passwordmodel.Email, passwordmodel.Password, passwordmodel.NewPassword, passwordmodel.ConfirmPassword);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        TempData["success"] = "The Password account has been reset successfully";
                    }
                    else
                    {
                        TempData["error"] = "The Password account could not be reset successfully" + res[1];
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Password account could not be reset successfully" + ex.Message;
            }
            return View(passwordmodel);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidatePersonalDetailsRegistration(ApplicantProfileMode profileModel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                if (string.IsNullOrEmpty(profileModel.Email_Address))
                {
                    return Json("missingfield*" + "Please enter your Valid Email Address", JsonRequestBehavior.AllowGet);
                }
                if (profileModel.Ethnic_Group == null)
                {
                    return Json("danger*Please enter a valid  Ethinicity Value", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Religion))
                {
                    return Json("missingfield*" + "Please select the Religion", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Prefix))
                {
                    return Json("missingfield*" + "Please select the Prefix", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.First_Name))
                {
                    return Json("missingfield*" + "Please Enter your First Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Othernames))
                {
                    profileModel.Othernames = "";
                }
                if (string.IsNullOrEmpty(profileModel.Surname))
                {
                    return Json("missingfield*" + "Please Enter your SurName", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Post_Code))
                {
                    return Json("missingfield*" + "Please select Post Codes", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Address))
                {
                    return Json("missingfield*" + "Please Enter Address", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Disability_Code))
                {
                    return Json("missingfield*" + "Please Select Disability", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Mobile_Phone_No))
                {
                    return Json("missingfield*" + "Please Enter Valid Mobile Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.DOB))
                {
                    return Json("missingfield*" + "Please Enter Valid Mobile Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.County_of_Residence))
                {
                    return Json("missingfield*" + "Please select County of Residence", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.County_of_Birth))
                {
                    return Json("missingfield*" + "Please select County of Origin", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Nationality))
                {
                    return Json("missingfield*" + "Please select Nationality", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(profileModel.Phone_No))
                {
                    profileModel.Phone_No = "";
                }
                if (string.IsNullOrEmpty(profileModel.Passport_No))
                {
                    profileModel.Passport_No = "";
                }
                if (string.IsNullOrEmpty(profileModel.Disability_Description))
                {
                    profileModel.Disability_Description = "";
                }
                if (string.IsNullOrEmpty(profileModel.Disability_Code))
                {
                    profileModel.Disability_Code = "";
                }
                if (profileModel.NHIF == null)
                {
                    profileModel.NHIF = "";
                }
                if (profileModel.NSSF == null)
                {
                    profileModel.NSSF = "";
                }

                DateTime dateofbirth;
                CultureInfo usCulture = new CultureInfo("es-ES");
                dateofbirth = DateTime.Parse(profileModel.DOB, usCulture.DateTimeFormat);
                var CandidateNo = Session["ApplicantNo"].ToString();
                var status = nav.FnApplicantProfileRegistration(Convert.ToInt32(profileModel.Prefix), CandidateNo, profileModel.Surname, profileModel.First_Name,
                    profileModel.Othernames, Convert.ToInt32(profileModel.Gender), Convert.ToInt32(profileModel.IDNumber), profileModel.Passport_No, profileModel.Nationality, Convert.ToInt32(profileModel.Religion), dateofbirth, profileModel.County_of_Birth,
                     profileModel.County_of_Residence, profileModel.Ethnic_Group, profileModel.NHIF, profileModel.NSSF, profileModel.Mobile_Phone_No, profileModel.KRA_Pin, Convert.ToInt32(profileModel.Marital_Status), profileModel.Address, profileModel.Disability_Code, profileModel.Disability_Description, profileModel.Phone_No, profileModel.areyoudisabled, profileModel.Post_Code, profileModel.skillscompetencies, profileModel.ManagementYears, profileModel.workexperienceYears,Convert.ToInt32(profileModel.EducationLevel));
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteCandidateFile(string FileName)
        {
            var CandidateNo = Session["ApplicantNo"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/Candidates/" + CandidateNo);
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);

            }
            return Json("success*The file has been deleted", JsonRequestBehavior.AllowGet);
        }
        public JsonResult JobDeleteCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber);
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);

            }
            return Json("success*The file has been deleted", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCandidateJobApplicationFile(string FileName)
        {
            var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/Candidates/" + JobApplplicationNo);
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);

            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ResetPassword()
        {

            return View();
        }
        public JsonResult GetApplicantAcademicQualifications()
        {

            List<AcademicQualificationModel> Qualifications = new List<AcademicQualificationModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Academic").ToList();
                foreach (var academics in query)
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    academic.Institution = academics.Institution_Company;
                    academic.Country = Convert.ToString(academics.Country);
                    academic.QualificationTitle = academics.Qualification_Category;
                    academic.specializationArea = academics.Specialized_Domain_Area;
                    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    academic.GraduationYear = academics.Graduation_Year;
                    academic.StartDate = Convert.ToString(academics.From_Date);
                    academic.EndDate = Convert.ToString(academics.To_Date);
                    Qualifications.Add(academic);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(Qualifications, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAdvertisedJobVacancies()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff" && x.Employment_Type != "Internship" && x.Employment_Type != "Attachment").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.ApplicationClosingDateTime = jobs.Application_Closing_Date + " " + jobs.Application_Closing_Time;
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetApplicantProffessionalQualifications()
        {

            List<ProffessionalQualificationModel> list = new List<ProffessionalQualificationModel>();
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Professional").ToList();
                foreach (var proffessionals in query)
                {
                    ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                    proffessional.EntryNo = proffessionals.Line_No;
                    proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                    proffessional.Institution = proffessionals.Institution_Company;
                    proffessional.Country = Convert.ToString(proffessionals.Country);
                    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJobApplicationAcademicQualifications()
        {

            List<AcademicQualificationModel> Qualifications = new List<AcademicQualificationModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Academic").ToList();
                foreach (var academics in query)
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    academic.Institution = academics.Institution_Company;
                    academic.Country = Convert.ToString(academics.Country);
                    academic.QualificationTitle = academics.Qualification_Category;
                    academic.specializationArea = academics.Specialized_Domain_Area;
                    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    academic.GraduationYear = academics.Graduation_Year;
                    academic.StartDate = Convert.ToString(academics.From_Date);
                    academic.EndDate = Convert.ToString(academics.To_Date);
                    Qualifications.Add(academic);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(Qualifications, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetApplicantWorkExperience()
        {

            List<EmploymentDetailsModel> list = new List<EmploymentDetailsModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Experience").ToList();
                foreach (var proffessionals in query)
                {
                    EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                    proffessional.EmployerName = proffessionals.Institution_Company;
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.Designation = proffessionals.Job_Description_Designation;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.TermsofService = proffessionals.Terms_of_Service;
                    proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                    proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    list.Add(proffessional);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCandidateApplicationworkExperience()
        {

            List<EmploymentDetailsModel> list = new List<EmploymentDetailsModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Experience").ToList();
                foreach (var proffessionals in query)
                {
                    EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.EmployerName = proffessionals.Institution_Company;
                    proffessional.Designation = proffessionals.Job_Description_Designation;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.TermsofService = proffessionals.Terms_of_Service;
                    proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                    proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    list.Add(proffessional);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetApplicantReferees()
        {

            List<RefereesModel> list = new List<RefereesModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.Referees.Where(x => x.No == ApplicantNumber).ToList();
                foreach (var referees in query)
                {
                    RefereesModel referee = new RefereesModel();
                    referee.EntryNumber = Convert.ToString(referees.Line_No);
                    referee.Refereetype = referees.Rererence_Type;
                    referee.SurName = Convert.ToString(referees.Name);
                    referee.FirstName = Convert.ToString(referees.Name);
                    referee.OtherNames = referees.Name;
                    referee.Designations = Convert.ToString(referees.Designation_Title);
                    referee.institution = Convert.ToString(referees.Institution);
                    referee.EmailAddress = Convert.ToString(referees.E_Mail);
                    referee.PhoneNumber = Convert.ToString(referees.Phone_No);
                    referee.Relationship = Convert.ToString(referees.Relationship);
                    referee.Country = Convert.ToString(referees.Country_Region_Code);
                    referee.knownyears = Convert.ToString(referees.Years_Known);
                    list.Add(referee);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public string getUploadedFileextension(HttpPostedFileBase filename)
        {
            return (Path.GetExtension(filename.FileName));
        }
        public JsonResult UploadDocumentsFiles(HttpPostedFileBase uploadfile)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                if (uploadfile == null)
                    return Json("uploadfilenull", JsonRequestBehavior.AllowGet);
                var rootFolder = Server.MapPath("~/DocumentsUploads");
                var subfolder = Path.Combine(rootFolder, "Applicant Folder/" + ApplicantNumber);
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);

                string fileName0 = Path.GetFileName(uploadfile.FileName);
                string ext0 = getUploadedFileextension(uploadfile);
                string savedF0 = fileName0;
                uploadfile.SaveAs(subfolder + "/" + savedF0);
                return Json("success*" + "File uploaded successfully");
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UploadJobApplicationDocumentsFiles(HttpPostedFileBase uploadfile)
        {
            try
            {
                var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                if (uploadfile == null)
                    return Json("uploadfilenull", JsonRequestBehavior.AllowGet);

                var rootFolder = Server.MapPath("~/DocumentsUploads");
                var subfolder = Path.Combine(rootFolder, "JobApplications/" + JobApplicationNumber);
                if (!Directory.Exists(subfolder))
                    Directory.CreateDirectory(subfolder);
                string fileName0 = Path.GetFileName(uploadfile.FileName);
                string ext0 = getUploadedFileextension(uploadfile);
                string savedF0 = fileName0;
                uploadfile.SaveAs(subfolder + "/" + savedF0);
                return Json("success*" + "File uploaded successfully");
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetApplicationReferees()
        {

            List<RefereesModel> list = new List<RefereesModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationReferees.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo).ToList();
                foreach (var referees in query)
                {
                    RefereesModel referee = new RefereesModel();
                    referee.EntryNumber = Convert.ToString(referees.Line_No);
                    referee.Refereetype = referees.Rererence_Type;
                    referee.SurName = Convert.ToString(referees.Name);
                    referee.FirstName = Convert.ToString(referees.Name);
                    referee.OtherNames = referees.Name;
                    referee.Designations = Convert.ToString(referees.Designation_Title);
                    referee.institution = Convert.ToString(referees.Institution);
                    referee.EmailAddress = Convert.ToString(referees.E_Mail);
                    referee.PhoneNumber = Convert.ToString(referees.Phone_No);
                    referee.Relationship = Convert.ToString(referees.Relationship);
                    referee.Country = Convert.ToString(referees.Country_Region_Code);
                    referee.knownyears = Convert.ToString(referees.Years_Known);
                    list.Add(referee);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetApplicantProffesionalBodies()
        {

            List<ProfessionalBodiesModel> list = new List<ProfessionalBodiesModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Proffessional Bodies").ToList();
                foreach (var proffessionals in query)
                {
                    ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalBody = proffessionals.Institution_Company;
                    proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                    proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                    proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                    proffessional.LicensingNumber = proffessionals.Licensing_Number;
                    proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                    list.Add(proffessional);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetApplicationProffesionalBodies()
        {

            List<ProfessionalBodiesModel> list = new List<ProfessionalBodiesModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Proffessional Bodies").ToList();
                foreach (var proffessionals in query)
                {
                    ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalBody = proffessionals.Institution_Company;
                    proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                    proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                    proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                    proffessional.LicensingNumber = proffessionals.Licensing_Number;
                    proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetApplicationProffessionalQualifications()
        {

            List<ProffessionalQualificationModel> list = new List<ProffessionalQualificationModel>();
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Professional").ToList();
                foreach (var proffessionals in query)
                {
                    ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                    proffessional.Institution = proffessionals.Institution_Company;
                    proffessional.Country = Convert.ToString(proffessionals.Country);
                    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateCandidateAcademicRegistration(AcademicQualificationModel AcademicModel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                if (string.IsNullOrEmpty(AcademicModel.Institution))
                {
                    return Json("missingfield*" + "Please Enter University/Institution/College", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.Country))
                {
                    return Json("missingfield*" + "Please select Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.QualificationTitle))
                {
                    return Json("missingfield*" + "Please Enter Academic Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.specializationArea))
                {
                    return Json("missingfield*" + "Please Select Specialization", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please Enter Attained Score", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please Enter Graduation Year", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.StartDate))
                {
                    return Json("missingfield*" + "Please Enter Start Date", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.EndDate))
                {
                    return Json("missingfield*" + "Please Enter End Date", JsonRequestBehavior.AllowGet);
                }
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tStartDate, tEnddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(AcademicModel.StartDate, usCulture.DateTimeFormat);
                tEnddate = DateTime.Parse(AcademicModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnUpdateAcademicQualifications(ApplicantNumber, Convert.ToInt32(1), Convert.ToInt32(AcademicModel.EducationLevel), AcademicModel.Institution, AcademicModel.Country,
                    AcademicModel.QualificationTitle, AcademicModel.specializationArea, Convert.ToInt32(AcademicModel.AttainedScore), AcademicModel.GraduationYear, tStartDate, tEnddate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteAcademicDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteAacademicDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult JobApplicantReferreeDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobApplicationRefereeDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteProffesionalQualificationDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteProffessionalQualificationDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult JobDeleteProffesionalQualificationDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalQualificationDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult JobDeleteEmploymentDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalQualificationDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteProffesionalQualificationBodiesDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteProffessionalQualificationBodiesDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult JobDeleteProffesionalQualificationBodiesDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalBodiesDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteCandidateWorkExperienceDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteWorkExperienceDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeletenJobAcademicDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobAcademicDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeletenJobProffesionalQualificationsDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalQualificationDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult DeleteCandidateRefreeDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteRefereeDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult JobApplicationDeleteCandidateRefreeDetails(int EntryNumber)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobApplicationRefereeDetails(EntryNumber, ApplicantNumber);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);

                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);

            }

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateApplicationAcademicRegistration(AcademicQualificationModel AcademicModel)
        {
            try
            {
                if (string.IsNullOrEmpty(AcademicModel.Institution))
                {
                    return Json("missingfield*" + "Please Enter University/Institution/College", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.Country))
                {
                    return Json("missingfield*" + "Please select Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.QualificationTitle))
                {
                    return Json("missingfield*" + "Please Enter Academic Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.specializationArea))
                {
                    return Json("missingfield*" + "Please Select Specialization", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please Enter Attained Score", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please Enter Graduation Year", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.StartDate))
                {
                    return Json("missingfield*" + "Please Enter Start Date", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(AcademicModel.EndDate))
                {
                    return Json("missingfield*" + "Please Enter End Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                DateTime tStartDate, tEnddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(AcademicModel.StartDate, usCulture.DateTimeFormat);
                tEnddate = DateTime.Parse(AcademicModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnApplicationAcademicQualifications(ApplicantNumber, JobApplicationNo, Convert.ToInt32(AcademicModel.EducationLevel), AcademicModel.Institution, AcademicModel.Country,
                    AcademicModel.QualificationTitle, AcademicModel.specializationArea, Convert.ToInt32(AcademicModel.AttainedScore), AcademicModel.GraduationYear, tStartDate, tEnddate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateCandidateProffessionalRegistration(ProffessionalQualificationModel ProffesionalModel)
        {
            try
            {
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalQualification))
                {
                    return Json("missingfield*" + "Please enter your Professional Qualification", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Institution))
                {
                    return Json("missingfield*" + "Please enter your Institution", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Country))
                {
                    return Json("missingfield*" + "Please enter your Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.QualificationTitle))
                {
                    return Json("missingfield*" + "Please enter your Qualification Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Speciality))
                {
                    return Json("missingfield*" + "Please enter your Speciality", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please select your Attained Score", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.CompletionYear))
                {
                    return Json("missingfield*" + "Please select your Completion Year", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.EndDate))
                {
                    return Json("missingfield*" + "Please enter End Date", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.StartDate))
                {
                    return Json("missingfield*" + "Please enter Start Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tStartDate, tEnddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(ProffesionalModel.StartDate, usCulture.DateTimeFormat);
                tEnddate = DateTime.Parse(ProffesionalModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnUpdateProffessionalQualifications(ProffesionalModel.EntryNo, ApplicantNumber, ProffesionalModel.ProffessionalQualification, ProffesionalModel.Institution, ProffesionalModel.Country,
                    ProffesionalModel.QualificationTitle, ProffesionalModel.Speciality, Convert.ToInt32(ProffesionalModel.AttainedScore), ProffesionalModel.CompletionYear, tStartDate, tEnddate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateApplicationProffessionalRegistration(ProffessionalQualificationModel ProffesionalModel)
        {
            try
            {
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalQualification))
                {
                    return Json("missingfield*" + "Please enter your Professional Qualification", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Institution))
                {
                    return Json("missingfield*" + "Please enter your Institution", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Country))
                {
                    return Json("missingfield*" + "Please enter your Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.QualificationTitle))
                {
                    return Json("missingfield*" + "Please enter your Qualification Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Speciality))
                {
                    return Json("missingfield*" + "Please enter your Speciality", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.AttainedScore))
                {
                    return Json("missingfield*" + "Please select your Attained Score", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.CompletionYear))
                {
                    return Json("missingfield*" + "Please select your Completion Year", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.EndDate))
                {
                    return Json("missingfield*" + "Please enter End Date", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.StartDate))
                {
                    return Json("missingfield*" + "Please enter Start Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tStartDate, tEnddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(ProffesionalModel.StartDate, usCulture.DateTimeFormat);
                tEnddate = DateTime.Parse(ProffesionalModel.EndDate, usCulture.DateTimeFormat);
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                var status = nav.FnApplicationProffessionalQualifications(ApplicantNumber, JobApplicationNo, ProffesionalModel.ProffessionalQualification, ProffesionalModel.Institution, ProffesionalModel.Country,
                    ProffesionalModel.QualificationTitle, ProffesionalModel.Speciality, Convert.ToInt32(ProffesionalModel.AttainedScore), ProffesionalModel.CompletionYear, tStartDate, tEnddate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateProffessionalBodiesRegistration(ProfessionalBodiesModel ProffesionalModel)
        {
            try
            {
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalBody))
                {
                    return Json("missingfield*" + "Please enter the Proffessional Body", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.RegistrationNo))
                {
                    return Json("missingfield*" + "Please enter the Registration Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipType))
                {
                    return Json("missingfield*" + "Please enter the Membership Type", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.licensingDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Licensing Date Renewal", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.LicensingNumber))
                {
                    return Json("missingfield*" + "Please enter the Licensing Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Membership Renewal Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tMemberDate, tLicenseDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tMemberDate = DateTime.Parse(ProffesionalModel.MembershipDateRenewal, usCulture.DateTimeFormat);
                tLicenseDate = DateTime.Parse(ProffesionalModel.licensingDateRenewal, usCulture.DateTimeFormat);
                var status = nav.FnProffessionaBodies(ApplicantNumber, ProffesionalModel.ProffessionalBody, ProffesionalModel.RegistrationNo, ProffesionalModel.MembershipType, tMemberDate, ProffesionalModel.LicensingNumber, tLicenseDate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateCandidateProffessionalBodiesRegistration(ProfessionalBodiesModel ProffesionalModel)
        {
            try
            {
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalBody))
                {
                    return Json("missingfield*" + "Please enter the Proffessional Body", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.RegistrationNo))
                {
                    return Json("missingfield*" + "Please enter the Registration Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipType))
                {
                    return Json("missingfield*" + "Please enter the Membership Type", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.licensingDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Licensing Date Renewal", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.LicensingNumber))
                {
                    return Json("missingfield*" + "Please enter the Licensing Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Membership Renewal Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tMemberDate, tLicenseDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tMemberDate = DateTime.Parse(ProffesionalModel.MembershipDateRenewal, usCulture.DateTimeFormat);
                tLicenseDate = DateTime.Parse(ProffesionalModel.licensingDateRenewal, usCulture.DateTimeFormat);
                var status = nav.FnUpdateProffessionaBodies(Convert.ToInt32(ProffesionalModel.EntryNumber), ApplicantNumber, ProffesionalModel.ProffessionalBody, ProffesionalModel.RegistrationNo, ProffesionalModel.MembershipType, tMemberDate, ProffesionalModel.LicensingNumber, tLicenseDate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateApplicationProffessionalBodiesRegistration(ProfessionalBodiesModel ProffesionalModel)
        {
            try
            {
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalBody))
                {
                    return Json("missingfield*" + "Please enter the Proffessional Body", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.RegistrationNo))
                {
                    return Json("missingfield*" + "Please enter the Registration Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipType))
                {
                    return Json("missingfield*" + "Please enter the Membership Type", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.licensingDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Licensing Date Renewal", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.LicensingNumber))
                {
                    return Json("missingfield*" + "Please enter the Licensing Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipDateRenewal))
                {
                    return Json("missingfield*" + "Please enter the Membership Renewal Date", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                DateTime tMemberDate, tLicenseDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tMemberDate = DateTime.Parse(ProffesionalModel.MembershipDateRenewal, usCulture.DateTimeFormat);
                tLicenseDate = DateTime.Parse(ProffesionalModel.licensingDateRenewal, usCulture.DateTimeFormat);
                var status = nav.FnApplicationProffessionaBodies(ApplicantNumber, JobApplicationNo, ProffesionalModel.ProffessionalBody, ProffesionalModel.RegistrationNo, ProffesionalModel.MembershipType, tMemberDate, ProffesionalModel.LicensingNumber, tLicenseDate);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult RegistrationUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var CandidateNo = Session["ApplicantNo"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/Candidates/");
            var subfolder = Path.Combine(rootFolder, CandidateNo);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }
            return View(uploadedFiles);
        }
        public JsonResult GetCandidateDocumentsUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var CandidateNo = Session["ApplicantNo"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/Candidates/");
            var subfolder = Path.Combine(rootFolder, CandidateNo);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(uploadedFiles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JobApplicationDocumentsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNo = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/JobApplications/");
            var subfolder = Path.Combine(rootFolder, JobApplicationNo);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return View(uploadedFiles);
        }
        public JsonResult GetJobUplicationDocumentsUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNo = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/JobApplications/");
            var subfolder = Path.Combine(rootFolder, JobApplicationNo);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(uploadedFiles, JsonRequestBehavior.AllowGet);
        }
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/DocumentsUploads/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateWorkWxperience(EmploymentDetailsModel EmployModel)
        {
            try
            {
                if (string.IsNullOrEmpty(EmployModel.EmployerName))
                {
                    return Json("missingfield*" + "Please enter your Employer Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.Designation))
                {
                    return Json("missingfield*" + "Please enter your Designation Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.EndDate))
                {
                    return Json("missingfield*" + "Please enter your Employment End", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the terms of service", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TotalYears))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }

                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tStartDate, tEndDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(EmployModel.StartDate, usCulture.DateTimeFormat);
                tEndDate = DateTime.Parse(EmployModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnWorkExperience(ApplicantNumber, EmployModel.EmployerName, EmployModel.Designation, tStartDate,
                   tEndDate, Convert.ToInt32(EmployModel.TermsofService), EmployModel.TotalYears, EmployModel.SummaryDetails);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateCandidateWorkWxperience(EmploymentDetailsModel EmployModel)
        {
            try
            {
                if (string.IsNullOrEmpty(EmployModel.EmployerName))
                {
                    return Json("missingfield*" + "Please enter your Employer Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.Designation))
                {
                    return Json("missingfield*" + "Please enter your Designation Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.EndDate))
                {
                    return Json("missingfield*" + "Please enter your Employment End", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the terms of service", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TotalYears))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }

                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                DateTime tStartDate, tEndDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(EmployModel.StartDate, usCulture.DateTimeFormat);
                tEndDate = DateTime.Parse(EmployModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnUpdateWorkExperience(Convert.ToInt32(EmployModel.EntryNumber), ApplicantNumber, EmployModel.EmployerName, EmployModel.Designation, tStartDate,
                   tEndDate, Convert.ToInt32(EmployModel.TermsofService), EmployModel.TotalYears, EmployModel.SummaryDetails);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateApplicationWorkWxperience(EmploymentDetailsModel EmployModel)
        {
            try
            {
                if (string.IsNullOrEmpty(EmployModel.EmployerName))
                {
                    return Json("missingfield*" + "Please enter your Employer Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.Designation))
                {
                    return Json("missingfield*" + "Please enter your Designation Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.EndDate))
                {
                    return Json("missingfield*" + "Please enter your Employment End", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the terms of service", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TotalYears))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    return Json("missingfield*" + "Please  the  Total Number of Years of relevant work experience for this job", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                DateTime tStartDate, tEndDate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(EmployModel.StartDate, usCulture.DateTimeFormat);
                tEndDate = DateTime.Parse(EmployModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnApplicationWorkExperience(ApplicantNumber, JobApplicationNo, EmployModel.EmployerName, EmployModel.Designation, tStartDate,
                   tEndDate, Convert.ToInt32(EmployModel.TermsofService), EmployModel.TotalYears, EmployModel.SummaryDetails);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CandidateReferees(RefereesModel RefModel)
        {
            try
            {
                if (string.IsNullOrEmpty(RefModel.Refereetype))
                {
                    return Json("missingfield*" + "Please referree Type", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Title))
                {
                    return Json("missingfield*" + "Please select Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.SurName))
                {
                    return Json("missingfield*" + "Please enter SurName", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.FirstName))
                {
                    return Json("missingfield*" + "Please enter First Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.OtherNames))
                {
                    return Json("missingfield*" + "Please enter Other Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Designations))
                {
                    return Json("missingfield*" + "Please enter Designation", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.institution))
                {
                    return Json("missingfield*" + "Please enter Institution Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.EmailAddress))
                {
                    return Json("missingfield*" + "Please enter Email Address", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.PhoneNumber))
                {
                    return Json("missingfield*" + "Please enter Phone Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Relationship))
                {
                    return Json("missingfield*" + "Please enter Relationship", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Country))
                {
                    return Json("missingfield*" + "Please select Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.knownyears))
                {
                    return Json("missingfield*" + "The Period from which the Referee have Known You", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var status = nav.FnCandidateReferees(ApplicantNumber, Convert.ToInt32(RefModel.Refereetype), RefModel.Title, RefModel.SurName,
                   RefModel.FirstName, RefModel.OtherNames, RefModel.Designations, RefModel.EmailAddress, RefModel.PhoneNumber, RefModel.Relationship, RefModel.Country, Convert.ToInt32(RefModel.knownyears), RefModel.institution);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult AppplicationCandidateReferees(RefereesModel RefModel)
        {
            try
            {
                if (string.IsNullOrEmpty(RefModel.Refereetype))
                {
                    return Json("missingfield*" + "Please referree Type", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Title))
                {
                    return Json("missingfield*" + "Please select Title", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.SurName))
                {
                    return Json("missingfield*" + "Please enter SurName", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.FirstName))
                {
                    return Json("missingfield*" + "Please enter First Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.OtherNames))
                {
                    return Json("missingfield*" + "Please enter Other Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Designations))
                {
                    return Json("missingfield*" + "Please enter Designation", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.institution))
                {
                    return Json("missingfield*" + "Please enter Institution Name", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.EmailAddress))
                {
                    return Json("missingfield*" + "Please enter Email Address", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.PhoneNumber))
                {
                    return Json("missingfield*" + "Please enter Phone Number", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Relationship))
                {
                    return Json("missingfield*" + "Please enter Relationship", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.Country))
                {
                    return Json("missingfield*" + "Please select Country", JsonRequestBehavior.AllowGet);
                }
                if (string.IsNullOrEmpty(RefModel.knownyears))
                {
                    return Json("missingfield*" + "The Period from which the Referee have Known You", JsonRequestBehavior.AllowGet);
                }
                var nav = new NavConnection().ObjNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                var status = nav.FnApplicationCandidateReferees(ApplicantNumber, JobApplicationNo, Convert.ToInt32(RefModel.Refereetype), RefModel.Title, RefModel.SurName,
                   RefModel.FirstName, RefModel.OtherNames, RefModel.Designations, RefModel.EmailAddress, RefModel.PhoneNumber, RefModel.Relationship, RefModel.Country, RefModel.knownyears, RefModel.institution);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //public void MoveAllCandidatefiles()
        //{
        //    var ApplicantNumber = Session["ApplicantNo"].ToString();
        //    var JobApplicationNo = Session["JobApplicationNumber"].ToString();
        //    var rootFolder = Server.MapPath("~/DocumentsUploads");
        //    var subfolder = Path.Combine(rootFolder, "Candidates/" + ApplicantNumber);
        //    var subfolder2 = Path.Combine(rootFolder, "JobApplications/" + JobApplicationNo);
        //    if (!Directory.Exists(subfolder))

        //        Directory.CreateDirectory(subfolder);

        //    string[] filePaths = Directory.GetFiles(subfolder);
        //    foreach (var filename in filePaths)
        //    {
        //         File.Copy(filename, Path.Combine(subfolder2, Path.GetFileName(filename)));

        //    }
        //}
        public void MoveAllCandidatefiles(string JobApplication)
        {
            var ApplicantNumber = Session["ApplicantNo"].ToString();
            var JobApplicationNo = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            var rootFolder = Server.MapPath("~/DocumentsUploads/");
            var subfolder = Path.Combine(rootFolder, "Candidates/" + ApplicantNumber + '_' + NewCandidateName);
            var subfolder2 = Path.Combine(rootFolder, "JobApplications/" + JobApplicationNo + '_' + NewCandidateName);
            var Folder1 = subfolder + "/" + "Academic & Professional Qualifications";
            var Folder2 = subfolder + "/" + "Chapter 6 Requirements";
            var Folder3 = subfolder + "/" + "Proposals & Published Journals";
            var Folder4 = subfolder + "/" + "Application Letter and CV";
            string[] filePaths = new string[0];
            string[] filePaths2 = new string[0];
            string[] filePaths3 = new string[0];
            string[] filePaths4 = new string[0];
            if (Directory.Exists(Folder1))
            {
                filePaths = Directory.GetFiles(Folder1);
            }
            if (Directory.Exists(Folder2))
            {
                filePaths2 = Directory.GetFiles(Folder2);
            }
            if (Directory.Exists(Folder3))
            {
                filePaths3 = Directory.GetFiles(Folder3);
            }
            if (Directory.Exists(Folder4))
            {
                filePaths4 = Directory.GetFiles(Folder4);
            }
            if (filePaths.Length != 0)
            {
                  var  AcademicsFolder= subfolder2 + "/" + "Academic & Professional Qualifications";
                if (!Directory.Exists(AcademicsFolder))
                    Directory.CreateDirectory(AcademicsFolder);
                // Create all the directories.
                foreach (string dirPath in Directory.GetDirectories(Folder1, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(Folder1, AcademicsFolder));
                }
                // Copy all the files & Replaces any files with the same name.
                foreach (string newPath in Directory.GetFiles( Folder1, "*.*", SearchOption.AllDirectories))
                {
                    System.IO.File.Copy(newPath, newPath.Replace(Folder1, AcademicsFolder), true);
                }
                string[] files = Directory.GetFiles(Folder1);
                foreach (string file in files)
                {
                    var FileNameDetails = Path.GetFileName(Folder1);
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNo, FileNameDetails, Folder1);
                }
            }
            if (filePaths2.Length != 0)
            {
                var Chapter6= subfolder2 + "/" + "Chapter 6 Requirements";
                if (!Directory.Exists(Chapter6))
                    Directory.CreateDirectory(Chapter6);
                // Create all the directories.
                foreach (string dirPath in Directory.GetDirectories(Folder2, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace( Folder2, Chapter6));
                }
                // Copy all the files & Replaces any files with the same name.
                foreach (string newPath in Directory.GetFiles( Folder2, "*.*", SearchOption.AllDirectories))
                {
                    System.IO.File.Copy(newPath, newPath.Replace(Folder2, Chapter6), true);
                }
                string[] files2 = Directory.GetFiles(Folder2);
                foreach (string file in files2)
                {
                    var FileNameDetails = Path.GetFileName(Folder2);
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNo, FileNameDetails, Chapter6);
                }
            }
            if (filePaths3.Length != 0)
            {
                var Proposals= subfolder2 + "/" + "Proposals & Published Journals";
                if (!Directory.Exists(Proposals))
                    Directory.CreateDirectory(Proposals);
                // Create all the directories.
                foreach (string dirPath in Directory.GetDirectories(Folder3, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(Folder3, Proposals));
                }
                // Copy all the files & Replaces any files with the same name.
                foreach (string newPath in Directory.GetFiles(Folder3, "*.*", SearchOption.AllDirectories))
                {
                    System.IO.File.Copy(newPath, newPath.Replace(Folder3, Proposals), true);
                }
                string[] files3 = Directory.GetFiles(Folder3);
                foreach (string file in files3)
                {
                    var FileNameDetails = Path.GetFileName(Folder3);
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNo, FileNameDetails, Proposals);
                }
            }

            if (filePaths4.Length != 0)
            {
                var Applications = subfolder2 + "/" + "Application Letter and CV";
                if (!Directory.Exists(Applications))
                    Directory.CreateDirectory(Applications);
                // Create all the directories.
                foreach (string dirPath in Directory.GetDirectories(Folder4, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(Folder4, Applications));
                }
                // Copy all the files & Replaces any files with the same name.
                foreach (string newPath in Directory.GetFiles(Folder4, "*.*", SearchOption.AllDirectories))
                {
                    System.IO.File.Copy(newPath, newPath.Replace(Folder4, Applications), true);
                }
                string[] files4 = Directory.GetFiles(Folder4);
                foreach (string file in files4)
                {
                    var FileNameDetails = Path.GetFileName(Folder4);
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNo, FileNameDetails, Applications);
                }
            }
        }

        [HttpPost]
        public JsonResult CandidateUploadFile()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;


                    // create the uploads folder if it doesn't exist
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var rootFolder = Server.MapPath("~/DocumentsUploads");
                    var subfolder = Path.Combine(rootFolder, "Candidates/" + ApplicantNumber);
                    if (!Directory.Exists(subfolder))
                        Directory.CreateDirectory(subfolder);

                    file.SaveAs(subfolder + "/" + fileName);
                    return Json("success*" + "File uploaded successfully", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }
            return Json("danger*" + "Kindly attach file Before you proceed", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult JobCandidateUploadFile()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;


                    // create the uploads folder if it doesn't exist
                    var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                    var rootFolder = Server.MapPath("~/DocumentsUploads");
                    var subfolder = Path.Combine(rootFolder, "JobApplications/" + JobApplicationNo);
                    if (!Directory.Exists(subfolder))
                        Directory.CreateDirectory(subfolder);

                    file.SaveAs(subfolder + "/" + fileName);
                    return Json("success*" + "File uploaded successfully", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }
            return Json("danger*" + "Kindly attach file Before you proceed", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ResetSupplierPassword(ChangePasswordModel passwordmodel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                var status = nav.FnResetPassword(passwordmodel.Email);
                var res = status.Split('*');
                switch (res[0])
                {
                    case "success":
                        return Json("success*" + res[1], JsonRequestBehavior.AllowGet);
                    case "emailnotfound":
                        return Json("emailnotfound*" + res[1], JsonRequestBehavior.AllowGet);
                    default:
                        return Json("danger*" + res[1], JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult ViewInternshipDetails(string JobReferenceNumber)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                model.OpenJobVacancies = GetAdvertisedJobVacancies(JobReferenceNumber);
                model.JobRequirements = GetJobRequirements(JobReferenceNumber);
                model.JobResponsibilities = GetJobResponsibilities(JobReferenceNumber);
                model.JobCheckList = GetJobCheckList(JobReferenceNumber);
                return View(model);


            }
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult InternshipApplicationForm(string VacancyID)
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.AcademicsQualification = GetAcademicQualifications(ApplicantNumber);
                model.ProffessionalQualification = GetProffessionalQualification(ApplicantNumber);
                model.ProffessionalBodies = GetProffessionalBodies(ApplicantNumber);
                model.WorkExperience = GetWorkExperience(ApplicantNumber);
                model.Referees = GetCandidateReferees(ApplicantNumber);
                model.JobCheckList = GetJobCheckList(VacancyID);
                return View(model);
            }
        }
        public ActionResult JobOverviewDetails(string JobReferenceNumber)
        {
            dynamic model = new ExpandoObject();
            model.OpenJobVacancies = GetAdvertisedJobVacancies(JobReferenceNumber);
            model.JobRequirements = GetJobRequirements(JobReferenceNumber);
            model.JobResponsibilities = GetJobResponsibilities(JobReferenceNumber);
            return View(model);
        }
        [HandleError]
        public ActionResult SingleJobView(string JobReferenceNumber)
        {
            dynamic model = new ExpandoObject();
            model.OpenJobVacancies = GetAdvertisedJobVacancies(JobReferenceNumber);
            model.JobRequirements = GetJobRequirements(JobReferenceNumber);
            model.JobResponsibilities = GetJobResponsibilities(JobReferenceNumber);
            model.PositionDetails = GetPositionDetails(JobReferenceNumber);
            model.ComPanyDetails = GetComapnyDetails();
            return View(model);


        }

        public ActionResult JobApplicationForm(string VacancyId)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["JobApplicationNumber"] == null)
            {
                return RedirectToAction("OpenJobVacancies", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                model.JobApplicationDetails = GetJobApplicationDetails(JobApplicationNumber);
                model.CandidateProfile = GetCandidateProfile(ApplicantNumber);
                model.AcademicsQualification = GetApplicationAcademicQualifications(ApplicantNumber, JobApplicationNumber);
                model.ProffessionalQualification = GetApplicationProffessionalQualification(ApplicantNumber, JobApplicationNumber);
                model.ProffessionalBodies = GetApplicationProffessionalBodies(ApplicantNumber, JobApplicationNumber);
                model.WorkExperience = GetApplicationWorkExperience(ApplicantNumber, JobApplicationNumber);
                model.Referees = GetApplicationCandidateReferees(ApplicantNumber, JobApplicationNumber);
                model.JobCheckList = GetJobCheckList(JobApplicationNumber);
                model.VacancyDeclarationDetails = GetVacancyDeclaration(JobApplicationNumber);
                model.JobDocumentsUploads = GetJobApplicationUploadedFiles(JobApplicationNumber);
                return View(model);
            }
        }

        public ActionResult AttachmentApplicationForm()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.AcademicsQualification = GetAcademicQualifications(ApplicantNumber);
                model.ProffessionalQualification = GetProffessionalQualification(ApplicantNumber);
                model.ProffessionalBodies = GetProffessionalBodies(ApplicantNumber);
                model.WorkExperience = GetWorkExperience(ApplicantNumber);
                model.Referees = GetCandidateReferees(ApplicantNumber);
                return View(model);
            }
        }
        [HttpGet]
        [HandleError]
        public ActionResult ViewAttachmentDetails(string JobReferenceNumber)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                model.OpenJobVacancies = GetAdvertisedJobVacancies(JobReferenceNumber);
                model.JobRequirements = GetJobRequirements(JobReferenceNumber);
                model.JobResponsibilities = GetJobResponsibilities(JobReferenceNumber);
                model.JobCheckList = GetJobCheckList(JobReferenceNumber);
                return View(model);


            }
        }
        [HttpGet]
        [HandleError]
        public ActionResult ViewJobDetails(string JobReferenceNumber)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                model.OpenJobVacancies = GetAdvertisedJobVacancies(JobReferenceNumber);
                model.JobRequirements = GetJobRequirements(JobReferenceNumber);
                model.JobResponsibilities = GetJobResponsibilities(JobReferenceNumber);
                model.JobCheckList = GetJobCheckList(JobReferenceNumber);
                model.WorkCondition = GetWorkCondition(JobReferenceNumber);
                return View(model);

            }
        }
        [HandleError]
        private static List<JobWorkCondition> GetWorkCondition(string JobReferenceNumber)
        {
            List<JobWorkCondition> list = new List<JobWorkCondition>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.WorkConditions.Where(x => x.Document_Type == "Job Vacancy" && x.Document_No == JobReferenceNumber).ToList();
                foreach (var openjobs in query)
                {
                    JobWorkCondition jobs = new JobWorkCondition();
                    jobs.Document_Type = openjobs.Document_Type;
                    jobs.Work_Condition_Category = openjobs.Working_Condition_Category;
                    jobs.Description = Convert.ToString(openjobs.Description);
                    jobs.Description = openjobs.Description;
                    list.Add(jobs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<CheckListModel> GetJobCheckList(string positionId)
        {
            List<CheckListModel> list = new List<CheckListModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.RequirementsChecklist.Where(x => x.Vacancy_No == positionId).ToList();
                foreach (var openjobs in query)
                {
                    CheckListModel jobs = new CheckListModel();
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Qualification_Category = openjobs.Qualification_Category;
                    jobs.Description = Convert.ToString(openjobs.Description);
                    jobs.Rating_Type = openjobs.Requirement_Type;
                    jobs.Requirement_Type = Convert.ToString(openjobs.Requirement_Type);
                    list.Add(jobs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<VacancyDeclarationModel> GetVacancyDeclaration(string ApplicationId)
        {
            List<VacancyDeclarationModel> list = new List<VacancyDeclarationModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationDeclaration.Where(x => x.Application_No == ApplicationId).ToList();
                foreach (var openjobs in query)
                {
                    VacancyDeclarationModel jobs = new VacancyDeclarationModel();
                    jobs.DeclarationDecsription = openjobs.Declaration_Statement;
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        [HandleError]
        private static List<CompanyInformationModel> GetComapnyDetails()
        {
            List<CompanyInformationModel> list = new List<CompanyInformationModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.CompanyInformation.ToList().Distinct();
                foreach (var companyinfo in query)
                {
                    CompanyInformationModel company = new CompanyInformationModel();
                    company.Name = companyinfo.Name;
                    company.Name2 = companyinfo.Name_2;
                    company.Vison = companyinfo.Vision;
                    company.Mission = companyinfo.Mission;
                    company.PhoneNumber = companyinfo.Phone_No;
                    company.EmailAddress = companyinfo.E_Mail;
                    company.County = companyinfo.County;
                    company.City = companyinfo.City;
                    company.Address = companyinfo.Address;
                    list.Add(company);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

        [HandleError]
        private static List<JobApplicationsModel> GetJobApplicationDetails(string JobReferenceNumber)
        {
            List<JobApplicationsModel> list = new List<JobApplicationsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplications.Where(x => x.Application_Status == "Open" && x.Application_No == JobReferenceNumber).ToList();
                foreach (var openApplications in query)
                {
                    JobApplicationsModel jobs = new JobApplicationsModel();
                    jobs.Application_No = openApplications.Application_No;
                    jobs.Vacancy_Id = openApplications.Vacancy_Id;
                    jobs.Job_Title_Designation = openApplications.Job_Title_Designation;
                    jobs.Work_Location_Details = openApplications.Work_Location_Details;
                    jobs.Employment_Type = openApplications.Employment_Type; ;
                    list.Add(jobs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<CompanyPositionModel> GetPositionDetails(string JobReferenceNumber)
        {
            List<CompanyPositionModel> list = new List<CompanyPositionModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var PositionId = "";
                var PositionNumbers = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Approval_Status == "Released" && x.Document_No == JobReferenceNumber && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in PositionNumbers)
                {
                    PositionId = openjobs.Position_ID;
                }

                var query = nav.CompanyPositions.Where(x => x.Position_ID == PositionId).ToList();
                foreach (var openjobs in query)
                {
                    CompanyPositionModel jobs = new CompanyPositionModel();
                    jobs.Position_ID = openjobs.Position_ID;
                    jobs.Executive_Summary_Job_Purpose = Convert.ToString(openjobs.Executive_Summary_Job_Purpose);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Seniority_Level = openjobs.Seniority_Level;
                    jobs.Default_Duty_Station = Convert.ToString(openjobs.Default_Duty_Station);
                    jobs.Designation_Group = Convert.ToString(openjobs.Designation_Group);
                    jobs.Average_Monthly_Salary_LCY = Convert.ToString(openjobs.Designation_Group);
                    jobs.Default_Probation_Period = Convert.ToString(openjobs.Default_Probation_Period);
                    jobs.Job_Title = Convert.ToString(openjobs.Job_Title);
                    jobs.Seniority_Level = Convert.ToString(openjobs.Seniority_Level);
                    list.Add(jobs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<AdvertisedJobPositions> GetAdvertisedJobVacancies(string jobId)
        {
            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Approval_Status == "Released" && x.Document_No == jobId).ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToDateTime(openjobs.Date_Published).ToString("MM/dd/yyyy");
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToDateTime(openjobs.Document_Date).ToString("MM/dd/yyyy");
                    jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.ApplicationClosingDateTime = jobs.Application_Closing_Date + " " + jobs.Application_Closing_Time;
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Default_Terms_of_Service_Code = openjobs.Default_Terms_of_Service_Code;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    jobs.Seniority_Level = Convert.ToString(openjobs.Seniority_Level);
                    list.Add(jobs);

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<JobResponsibilitiesModel> GetJobResponsibilities(string jobId)
        {
            List<JobResponsibilitiesModel> list = new List<JobResponsibilitiesModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobResponsibilities.Where(x => x.Document_Type == "Job Vacancy" && x.Document_No == jobId).ToList();
                foreach (var responsibilities in query)
                {
                    JobResponsibilitiesModel response = new JobResponsibilitiesModel();
                    response.Document_No = responsibilities.Document_No;
                    response.Document_Type = responsibilities.Document_Type;
                    response.Description = responsibilities.Description;
                    list.Add(response);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        [HandleError]
        private static List<JobRequirementModel> GetJobRequirements(string jobId)
        {
            List<JobRequirementModel> list = new List<JobRequirementModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobVacancyRequirement.Where(x => x.Document_Type == "Job Vacancy" && x.Document_No == jobId).ToList();
                foreach (var responsibilities in query)
                {
                    JobRequirementModel response = new JobRequirementModel();
                    response.Document_No = responsibilities.Document_No;
                    response.Document_Type = responsibilities.Document_Type;
                    response.Description = responsibilities.Description;
                    response.Requirement_Type = responsibilities.Requirement_Type;
                    list.Add(response);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return list;
        }
        public ActionResult JobView()
        {
            return View();
        }
        public ActionResult FAQs()
        {
            return View();
        }
        public ActionResult AdvertisedAttachment()
        {

            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Employment_Type == "Attachment" && x.Employment_Type == "Attachment" && x.Approval_Status == "Released").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult ApplicantProfileRegistration()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.CandidateProfile = GetCandidateProfile(ApplicantNumber);
                model.AcademicsQualification = GetAcademicQualifications(ApplicantNumber);
                model.ProffessionalQualification = GetProffessionalQualification(ApplicantNumber);
                model.ProffessionalBodies = GetProffessionalBodies(ApplicantNumber);
                model.WorkExperience = GetWorkExperience(ApplicantNumber);
                model.Referees = GetCandidateReferees(ApplicantNumber);
                model.UploadedDocuments = GetCandidateUploadedFiles(ApplicantNumber);
                return View(model);
            }

        }
        public ActionResult DocumentsUpload()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.CandidateProfile = GetCandidateProfile(ApplicantNumber);
                model.UploadedDocuments = GetCandidateUploadedFiles(ApplicantNumber);
                return View(model);
            }

        }
        [HttpGet]
        [HandleError]
        private static List<FileModel> GetCandidateUploadedFiles(string CandidateNumber)
        {
            var uploadedFiles = new List<FileModel>();
            var rootFolder = System.Web.Hosting.HostingEnvironment.MapPath("~/DocumentsUploads/Candidates/");
            var subfolder = Path.Combine(rootFolder, CandidateNumber);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return (uploadedFiles);
        }
        [HttpGet]
        [HandleError]
        private static List<FileModel> GetJobApplicationUploadedFiles(string ApplicationNumber)
        {
            var uploadedFiles = new List<FileModel>();
            var rootFolder = System.Web.Hosting.HostingEnvironment.MapPath("~/DocumentsUploads/JobApplications/");
            var subfolder = Path.Combine(rootFolder, ApplicationNumber);
            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);

            var files = Directory.GetFiles(subfolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;

                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return (uploadedFiles);
        }
        [HttpGet]
        [HandleError]
        private static List<ApplicantProfileMode> GetCandidateProfile(string ApplicantNumber)
        {

            List<ApplicantProfileMode> list = new List<ApplicantProfileMode>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicantProfile.Where(x => x.Candidate_No == ApplicantNumber).ToList();
                foreach (var profiles in query)
                {
                    ApplicantProfileMode profile = new ApplicantProfileMode();
                    profile.Prefix = profiles.Tittles;
                    profile.Disabled = Convert.ToInt32(profiles.Disabled);
                    profile.City = profiles.City;
                    profile.AlternativeEmailAddress = profiles.E_Mail;
                    profile.First_Name = profiles.First_Name;
                    profile.County_of_Residence = profiles.County_of_Birth;
                    profile.Disability_Description = profiles.Disability_Description;
                    profile.Last_Name = profiles.Last_Name;
                    profile.Middle_Name = profiles.Middle_Name;
                    profile.IDNumber = Convert.ToInt32(profiles.ID_Number);
                    profile.Passport_No = profiles.Passport_No;
                    profile.Nationality = profiles.Nationality;
                    profile.Religion = Convert.ToString(profiles.Religion);
                    profile.Post_Code = Convert.ToString(profiles.Post_Code);
                    profile.City = Convert.ToString(profiles.City);
                    profile.County_of_Birth = Convert.ToString(profiles.County_of_Birth);
                    profile.Ethnic_Group = Convert.ToString(profiles.Ethnic_Group);
                    profile.Mobile_Phone_No = Convert.ToString(profiles.Mobile_Phone_No);
                    profile.Phone_No = Convert.ToString(profiles.Phone_No);
                    profile.Marital_Status = Convert.ToString(profiles.Marital_Status);
                    profile.Address = Convert.ToString(profiles.Address);
                    profile.Disability_Code = Convert.ToString(profiles.Disability_Certificate_No);
                    profile.Email_Address = Convert.ToString(profiles.E_Mail);
                    profile.KRA_Pin = Convert.ToString(profiles.KRA_Pin);
                    profile.Gender = Convert.ToString(profiles.Gender);
                    profile.NSSF = Convert.ToString(profiles.NSSF_No);
                    profile.Mobile_Phone_No = Convert.ToString(profiles.Mobile_Phone_No);
                    profile.Phone_No = Convert.ToString(profiles.Phone_No);
                    profile.DOB = Convert.ToString(profiles.Birth_Date);
                    profile.NHIF = Convert.ToString(profiles.NHIF_No);
                    profile.Full_Names = Convert.ToString(profiles.Full_Names);
                    list.Add(profile);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        [HttpGet]
        [HandleError]
        private static List<AcademicQualificationModel> GetAcademicQualifications(string ApplicantNumber)
        {

            List<AcademicQualificationModel> list = new List<AcademicQualificationModel>();
            try
            {

                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Academic").ToList();
                foreach (var academics in query)
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    academic.Institution = academics.Institution_Company;
                    academic.Country = Convert.ToString(academics.Country);
                    academic.QualificationTitle = academics.Qualification_Category;
                    academic.specializationArea = academics.Specialized_Domain_Area;
                    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    academic.GraduationYear = academics.Graduation_Year;
                    academic.StartDate = Convert.ToString(academics.From_Date);
                    academic.EndDate = Convert.ToString(academics.To_Date);
                    list.Add(academic);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<AcademicQualificationModel> GetApplicationAcademicQualifications(string ApplicantNumber, string JobApplicationNo)
        {

            List<AcademicQualificationModel> list = new List<AcademicQualificationModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Academic" && x.Application_No == JobApplicationNo).ToList();
                foreach (var academics in query)
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    academic.Institution = academics.Institution_Company;
                    academic.Country = Convert.ToString(academics.Country);
                    academic.QualificationTitle = academics.Qualification_Category;
                    academic.specializationArea = academics.Specialized_Domain_Area;
                    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    academic.GraduationYear = academics.Graduation_Year;
                    academic.StartDate = Convert.ToString(academics.From_Date);
                    academic.EndDate = Convert.ToString(academics.To_Date);
                    list.Add(academic);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<ProffessionalQualificationModel> GetProffessionalQualification(string ApplicantNumber)
        {

            List<ProffessionalQualificationModel> list = new List<ProffessionalQualificationModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Professional").ToList();
                foreach (var proffessionals in query)
                {
                    ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                    proffessional.EntryNo = proffessionals.Line_No;
                    proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                    proffessional.Institution = proffessionals.Institution_Company;
                    proffessional.Country = Convert.ToString(proffessionals.Country);
                    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<ProffessionalQualificationModel> GetApplicationProffessionalQualification(string ApplicantNumber, string JobApplicationNo)
        {

            List<ProffessionalQualificationModel> list = new List<ProffessionalQualificationModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Professional" && x.Application_No == JobApplicationNo).ToList();
                foreach (var proffessionals in query)
                {
                    ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                    proffessional.Institution = proffessionals.Institution_Company;
                    proffessional.Country = Convert.ToString(proffessionals.Country);
                    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<ProfessionalBodiesModel> GetProffessionalBodies(string ApplicantNumber)
        {

            List<ProfessionalBodiesModel> list = new List<ProfessionalBodiesModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Proffessional Bodies").ToList();
                foreach (var proffessionals in query)
                {
                    ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalBody = proffessionals.Institution_Company;
                    proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                    proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                    proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                    proffessional.LicensingNumber = proffessionals.Licensing_Number;
                    proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);

                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<ProfessionalBodiesModel> GetApplicationProffessionalBodies(string ApplicantNumber, string JobApplicationNo)
        {

            List<ProfessionalBodiesModel> list = new List<ProfessionalBodiesModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Proffessional Bodies" && x.Application_No == JobApplicationNo).ToList();
                foreach (var proffessionals in query)
                {
                    ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.ProffessionalBody = proffessionals.Institution_Company;
                    proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                    proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                    proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                    proffessional.LicensingNumber = proffessionals.Licensing_Number;
                    proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<EmploymentDetailsModel> GetWorkExperience(string ApplicantNumber)
        {

            List<EmploymentDetailsModel> list = new List<EmploymentDetailsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Experience").ToList();
                foreach (var proffessionals in query)
                {
                    EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessional.EmployerName = proffessionals.Institution_Company;
                    proffessional.Designation = proffessionals.Job_Description_Designation;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.TermsofService = proffessionals.Terms_of_Service;
                    proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                    proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<EmploymentDetailsModel> GetApplicationWorkExperience(string ApplicantNumber, string JobApplicationNo)
        {

            List<EmploymentDetailsModel> list = new List<EmploymentDetailsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Experience" && x.Application_No == JobApplicationNo).ToList();
                foreach (var proffessionals in query)
                {
                    EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                    proffessional.EmployerName = proffessionals.Institution_Company;
                    proffessional.Designation = proffessionals.Job_Description_Designation;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.TermsofService = proffessionals.Terms_of_Service;
                    proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                    proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    list.Add(proffessional);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<RefereesModel> GetCandidateReferees(string ApplicantNumber)
        {

            List<RefereesModel> list = new List<RefereesModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.Referees.Where(x => x.No == ApplicantNumber).ToList();
                foreach (var referees in query)
                {
                    RefereesModel referee = new RefereesModel();
                    referee.EntryNumber = Convert.ToString(referees.Line_No);
                    referee.Refereetype = referees.Rererence_Type;
                    referee.SurName = Convert.ToString(referees.Name);
                    referee.FirstName = Convert.ToString(referees.Name);
                    referee.OtherNames = referees.Name;
                    referee.Designations = Convert.ToString(referees.Designation_Title);
                    referee.institution = Convert.ToString(referees.Institution);
                    referee.EmailAddress = Convert.ToString(referees.E_Mail);
                    referee.PhoneNumber = Convert.ToString(referees.Phone_No);
                    referee.Relationship = Convert.ToString(referees.Relationship);
                    referee.Country = Convert.ToString(referees.Country_Region_Code);
                    referee.knownyears = Convert.ToString(referees.Years_Known);
                    list.Add(referee);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        [HttpGet]
        [HandleError]
        private static List<RefereesModel> GetApplicationCandidateReferees(string ApplicantNumber, string JobApplicationNo)
        {

            List<RefereesModel> list = new List<RefereesModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationReferees.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplicationNo).ToList();
                foreach (var referees in query)
                {
                    RefereesModel referee = new RefereesModel();
                    referee.EntryNumber = Convert.ToString(referees.Line_No);
                    referee.Refereetype = referees.Rererence_Type;
                    referee.SurName = Convert.ToString(referees.Name);
                    referee.FirstName = Convert.ToString(referees.Name);
                    referee.OtherNames = referees.Name;
                    referee.Designations = Convert.ToString(referees.Designation_Title);
                    referee.institution = Convert.ToString(referees.Institution);
                    referee.EmailAddress = Convert.ToString(referees.E_Mail);
                    referee.PhoneNumber = Convert.ToString(referees.Phone_No);
                    referee.Relationship = Convert.ToString(referees.Relationship);
                    referee.Country = Convert.ToString(referees.Country_Region_Code);
                    referee.knownyears = Convert.ToString(referees.Years_Known);
                    list.Add(referee);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return list;

        }
        public ActionResult JobsGridView()
        {

            dynamic model = new ExpandoObject();
            model.OpenPositions = GetOpenJobAvertisements();
            return View(model);
        }

        public ActionResult ExpiredJobVacancies()
        {


            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                if (Session["ApplicantNo"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var nav = NavConnection.ReturnNav();
                    var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Closed" && x.Approval_Status == "Released" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                    foreach (var openjobs in query)
                    {
                        AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                        jobs.Job_No = openjobs.Job_No;
                        jobs.Document_No = openjobs.Document_No;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                        jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                        jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                        jobs.Employment_Type = openjobs.Employment_Type;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                        jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                        jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                        jobs.Work_Location_Details = openjobs.Work_Location_Details;
                        jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                        jobs.Vacancy_No = openjobs.Vacancy_No;
                        jobs.Vacancy_Status = openjobs.Vacancy_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                        jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                        jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                        jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                        list.Add(jobs);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult Personalinformation()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.CandidateProfile = GetCandidateProfile(ApplicantNumber);
                return View(model);


            }
        }
        public ActionResult WorkExperience()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.WorkExperience = GetWorkExperience(ApplicantNumber);
                return View(model);


            }
        }
        public ActionResult OpenJobVacancies()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var today = DateTime.Today;
                    var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff" && x.Employment_Type != "Internship" && x.Employment_Type != "Attachment").ToList();
                    foreach (var openjobs in query)
                    {
                        AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                        jobs.Job_No = openjobs.Job_No;
                        jobs.Document_No = openjobs.Document_No;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                        jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                        jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                        jobs.Employment_Type = openjobs.Employment_Type;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                        jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                        jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                        jobs.ApplicationClosingDateTime = jobs.Application_Closing_Date + " " + jobs.Application_Closing_Time;
                        jobs.Work_Location_Details = openjobs.Work_Location_Details;
                        jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                        jobs.Vacancy_No = openjobs.Vacancy_No;
                        jobs.Vacancy_Status = openjobs.Vacancy_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                        jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                        jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                        jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                        list.Add(jobs);

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return View(list);
            }
        }
        public ActionResult InternalJobVacancies()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
                try
                {
                    var nav = NavConnection.ReturnNav();
                    var today = DateTime.Today;
                    var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source == "Limited-Internal Staff").ToList();
                    foreach (var openjobs in query)
                    {
                        AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                        jobs.Job_No = openjobs.Job_No;
                        jobs.Document_No = openjobs.Document_No;
                        jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                        jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                        jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                        jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                        jobs.Employment_Type = openjobs.Employment_Type;
                        jobs.Document_Date = Convert.ToDateTime(openjobs.Document_Date).ToString("MM/dd/yyyy");
                        jobs.Application_Closing_Date = Convert.ToDateTime(openjobs.Application_Closing_Date).ToString("MM/dd/yyyy");
                        jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                        jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                        jobs.Work_Location_Details = openjobs.Work_Location_Details;
                        jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                        jobs.Vacancy_No = openjobs.Vacancy_No;
                        jobs.Vacancy_Status = openjobs.Vacancy_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Approval_Status = openjobs.Approval_Status;
                        jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                        jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                        jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                        jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                        jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                        list.Add(jobs);

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return View(list);
            }
        }
        public ActionResult OpenAttachmentsPositions()
        {
            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();

                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Employment_Type == "Internship" && x.Application_Closing_Date >= today && x.Vacancy_Status == "Published" && x.Approval_Status == "Released" && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult CancelledJobVacancies()
        {
            List<AdvertisedJobPositions> list = new List<AdvertisedJobPositions>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var today = DateTime.Today;
                var query = nav.AdvertisedVacancies.Where(x => x.Document_Type == "Job Vacancy" && x.Vacancy_Status == "Cancelled" && x.Approval_Status == "Released" && x.Application_Closing_Date >= today && x.Target_Candidate_Source != "Limited-Internal Staff").ToList();
                foreach (var openjobs in query)
                {
                    AdvertisedJobPositions jobs = new AdvertisedJobPositions();
                    jobs.Job_No = openjobs.Job_No;
                    jobs.Document_No = openjobs.Document_No;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Job_Grade_ID = openjobs.Job_Grade_ID;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Date_Published = Convert.ToString(openjobs.Date_Published);
                    jobs.Employment_Type = openjobs.Employment_Type;
                    jobs.Document_Date = Convert.ToString(openjobs.Document_Date);
                    jobs.Application_Closing_Date = Convert.ToString(openjobs.Application_Closing_Date);
                    jobs.Application_Closing_Time = Convert.ToString(openjobs.Application_Closing_Time);
                    jobs.No_of_Applications = Convert.ToString(openjobs.No_of_Applications);
                    jobs.Work_Location_Details = openjobs.Work_Location_Details;
                    jobs.Vacancy_Announcement_ID = openjobs.Vacancy_Announcement_ID;
                    jobs.Vacancy_No = openjobs.Vacancy_No;
                    jobs.Vacancy_Status = openjobs.Vacancy_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Approval_Status = openjobs.Approval_Status;
                    jobs.Duty_Station_ID = openjobs.Duty_Station_ID;
                    jobs.Hierarchically_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Target_Candidate_Source = openjobs.Target_Candidate_Source;
                    jobs.Functionally_Reports_To = openjobs.Hierarchically_Reports_To;
                    jobs.Estimate_Annual_Salary = Convert.ToString(openjobs.Estimate_Annual_Salary);
                    jobs.No_of_Openings = Convert.ToString(openjobs.No_of_Openings);
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(list);
        }
        public ActionResult ActiveJobApplications()
        {
            List<JobApplicationsModel> list = new List<JobApplicationsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var query = nav.JobApplications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_Status == "Open").ToList();
                foreach (var openjobs in query)
                {
                    JobApplicationsModel jobs = new JobApplicationsModel();
                    jobs.Application_No = openjobs.Application_No;
                    jobs.Candidate_No = openjobs.Candidate_No;
                    jobs.Vacancy_Id = Convert.ToString(openjobs.Vacancy_Id);
                    jobs.Professional_Summary = openjobs.Professional_Summary;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Application_Status = Convert.ToString(openjobs.Application_Status);
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
        public ActionResult ClosedJobApplications()
        {
            List<JobApplicationsModel> list = new List<JobApplicationsModel>();
            try
            {
                var nav = NavConnection.ReturnNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var query = nav.JobApplications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_Status == "Closed").ToList();
                foreach (var openjobs in query)
                {
                    JobApplicationsModel jobs = new JobApplicationsModel();
                    jobs.Application_No = openjobs.Application_No;
                    jobs.Candidate_No = openjobs.Candidate_No;
                    jobs.Vacancy_Id = Convert.ToString(openjobs.Vacancy_Id);
                    jobs.Professional_Summary = openjobs.Professional_Summary;
                    jobs.Job_Title_Designation = openjobs.Job_Title_Designation;
                    jobs.Application_Status = Convert.ToString(openjobs.Application_Status);
                    list.Add(jobs);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(list);
        }
        public ActionResult TrainingApplications()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                dynamic model = new ExpandoObject();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                model.CandidateProfile = GetCandidateProfile(ApplicantNumber);
                model.AcademicsQualification = GetAcademicQualifications(ApplicantNumber);
                model.ProffessionalQualification = GetProffessionalQualification(ApplicantNumber);
                model.ProffessionalBodies = GetProffessionalBodies(ApplicantNumber);
                model.WorkExperience = GetWorkExperience(ApplicantNumber);
                model.Referees = GetCandidateReferees(ApplicantNumber);
                return View(model);


            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("obadiahkorir@dynasoft..co.ke", "Dynasoft Business Solutions Ltd");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "********"; // Replace with actual password
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>We are excited to tell you that your E-recruitment account is" +
                " successfully created. Please click on the below link to verify your account" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        public ActionResult PostalCodeList()
        {
            List<DropdownListsModel> postacode = new List<DropdownListsModel>();
            try
            {
                //var nav = NavConnection.ReturnNav();
                //var query = nav.postcodes.ToList();
                //foreach (var postacodes in query)
                //{
                //    DropdownListsModel postcodes = new DropdownListsModel();
                //    postcodes.Code = postacodes.Code;
                //    postcodes.City = postacodes.City;
                //    postcodes.CountryName = postacodes.Country_Region_Code;
                //    postacode.Add(postcodes);
                //}


            }
            catch (Exception e)
            {

                throw;
            }
            return View(postacode);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            // Code for validating the Captcha  
            if (this.IsCaptchaValid("Validate your captcha"))
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        var nav = NavConnection.ReturnNav();
                        var user = nav.RecruitmentCandidates.Where(x => x.Authentication_Email == model.Email && x.Password_Value == model.Password && x.State == "Enabled" && x.Record_Type == "Job Applicant").ToList();
                        var result = user.FirstOrDefault();
                        if (result != null)
                        {
                            foreach (var applicant in user)
                            {
                                string fname = applicant.Full_Name;
                                string username = applicant.User_Name;
                                string phoneNumber = applicant.Mobile_Phone_No;
                                Session["email"] = applicant.Authentication_Email;
                                Session["password"] = applicant.Password_Value;
                                Session["name"] = applicant.Full_Name;
                                Session["email"] = applicant.Authentication_Email;
                                Session["userNo"] = applicant.Record_ID;
                                Session["username"] = username;
                                Session["fullname"] = fname;
                                Session["ApplicantNo"] = applicant.Record_ID;
                            }
                            //check if the contact is registered in the Applicant Table
                            var applicantprofile = nav.RecruitmentCandidates.ToList();
                            var AppliicantDetails = (from a in applicantprofile where a.Authentication_Email == (string)Session["email"] select a).ToList();
                            if (result.State == "Enabled" && result.Change_Password == true)
                            {
                                foreach (var applicantdetail in AppliicantDetails)
                                {
                                    string fname = applicantdetail.Full_Name;
                                    string username = applicantdetail.User_Name;
                                    string phoneNumber = applicantdetail.Mobile_Phone_No;
                                    Session["email"] = applicantdetail.Authentication_Email;
                                    Session["password"] = applicantdetail.Password_Value;
                                    Session["name"] = applicantdetail.Full_Name;
                                    Session["email"] = applicantdetail.Authentication_Email;
                                    Session["username"] = username; ;
                                    Session["fullname"] = fname;
                                    Session["ApplicantNo"] = applicantdetail.Record_ID;
                                    Session["IdNumber"] = applicantdetail.ID_Number;
                                    Session["MobileNumber"] = applicantdetail.Mobile_Phone_No;
                                }
                                return RedirectToAction("Dashboard", "Home");
                            }
                            else
                            {
                                return RedirectToAction("ChangePassword", "Home");
                            }
                            if (result.State != "Enabled")
                            {
                                TempData["error"] = "Your account is deactivated. Kindly Contact System Administrator for More Details";

                            }
                        }
                        var Employee = nav.HRPortalUsers.Where(x => x.employeeNo == model.Email && x.password == model.Password).ToList();
                        var Employeeresult = Employee.FirstOrDefault();
                        if (Employeeresult != null)
                        {
                            foreach (var applicant in Employee)
                            {
                                var Employeeuser = nav.ApplicantProfile.Where(x => x.Employee_No == model.Email&&x.Status=="Active").ToList();
                                var newresult = Employeeuser.FirstOrDefault();
                                if (newresult != null)
                                {
                                    foreach (var employeedetail in Employeeuser)
                                    {
                                        string fname = employeedetail.Full_Names;
                                        string username = employeedetail.First_Name;
                                        string phoneNumber = employeedetail.Mobile_Phone_No;
                                        Session["email"] = employeedetail.E_Mail;
                                        Session["password"] = applicant.password;
                                        Session["name"] = employeedetail.Full_Names;
                                        Session["email"] = employeedetail.E_Mail;
                                        Session["userNo"] = employeedetail.Employee_No;
                                        Session["username"] = username;
                                        Session["fullname"] = fname;
                                        Session["ApplicantNo"] = employeedetail.Candidate_No;
                                        Session["EmployeeNo"] = applicant.employeeNo;
                                    }
                                    return RedirectToAction("Dashboard", "Home");
                                }
                                else
                                    TempData["error"] = "Sorry,Your candidate account could not be found. Kindly liase with IT Department to have your Candidate Account Created in the System and then try again";
                            }
                        }
                        else
                        {
                            TempData["error"] = "The Email Address or Password provided is incorrect. Kindly try Again with the Correct Credentials";
                        }
                    }
                }

                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;

                }
            }
            else
            {
                TempData["error"] = "The reCapture Output is not correct.Kindly ensure you provide correct answer ";

            }
            return View(model);
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var nav = NavConnection.ReturnNav();
            var user = nav.RecruitmentCandidates.Where(x => x.Authentication_Email == emailID);
            return user != null;
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}