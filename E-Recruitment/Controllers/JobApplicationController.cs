using E_Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Recruitment.Controllers
{
    public class JobApplicationController : Controller
    {
        // GET: CadindateProfile
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                
                ApplicantProfileMode profile = new ApplicantProfileMode();
                try
                {
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicantProfile.Where(x => x.Candidate_No == ApplicantNumber).ToList();
                        foreach (var profiles in query)
                        {

                        profile.Prefix = profiles.Tittles;
                        profile.Disabled = Convert.ToInt32(profiles.Disabled);
                        profile.City = profiles.City;
                        profile.Gender = profiles.Gender;
                        profile.AlternativeEmailAddress = profiles.E_Mail;
                        profile.First_Name = profiles.First_Name;
                        profile.County_of_Residence = profiles.County_of_Birth;
                        profile.Disability_Description = profiles.Disability_Description;
                        profile.Last_Name = profiles.Last_Name;
                        profile.Surname = profiles.Last_Name;
                        profile.Othernames = profiles.Middle_Name;
                        profile.skillscompetencies = profiles.Skills_Competences;
                        profile.Middle_Name = profiles.Middle_Name;
                        profile.IDNumber = profiles.ID_Number;
                        profile.Passport_No = profiles.Passport_No;
                        profile.Nationality = profiles.Nationality;
                        profile.Religion = profiles.Religion;
                        profile.Post_Code = profiles.Post_Code;
                        profile.City = profiles.City;
                        profile.County_of_Birth = profiles.County_of_Birth;
                        profile.Ethnic_Group = profiles.Ethnic_Group;
                        profile.Mobile_Phone_No = profiles.Mobile_Phone_No;
                        profile.Phone_No = profiles.Phone_No;
                        profile.Marital_Status = profiles.Marital_Status;
                        profile.Address = profiles.Address;
                        profile.Disability_Code = profiles.Disability_Certificate_No;
                        profile.Email_Address = profiles.E_Mail;
                        profile.KRA_Pin = profiles.KRA_Pin;
                        profile.DOB = Convert.ToDateTime(profiles.Birth_Date).ToString("MM/dd/yyyy");
                        profile.NSSF = profiles.NSSF_No;
                        profile.NHIF = profiles.NHIF_No;
                        profile.Full_Names = profiles.Full_Names;
                        profile.ManagementYears = Convert.ToInt32(profiles.Management_Experience_Yrs);
                        profile.workexperienceYears = Convert.ToInt32(profiles.Relevant_Work_Experience_Yrs);

                    }
                   
                    return View("Index", profile);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpPost]
        public ActionResult UploadCandidateStatutoryAttachDocuments(HttpPostedFileBase[] statutory)
        {
            try
            {
                foreach (HttpPostedFileBase file in statutory)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var ApplicantNumber = Session["ApplicantNo"].ToString();
                        var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                        var CandidateName = Session["fullname"].ToString();
                        var NewCandidateName = CandidateName.Replace(' ', '_');
                        string CandidatePath = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Chapter 6 Requirements"));
                        if (!Directory.Exists(CandidatePath))
                            Directory.CreateDirectory(CandidatePath);
                        string path = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Chapter 6 Requirements"), Path.GetFileName(file.FileName));
                        var FileNameDetails = Path.GetFileName(file.FileName);
                        file.SaveAs(path);
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNumber, FileNameDetails, path);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success"] = "Applicant File(s) were uploaded successfully";
                        }else
                        {
                            TempData["error"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload";
                        }
                    }
                    else
                    {
                        TempData["success"] = "The File Attached has been Uploaded Successfully.But you have not attached all the Chapter 6 Documents";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload" + ex.Message;

            }
            return Redirect("CandidateAttachDocuments");
        }
        [HttpPost]
        public ActionResult UploadCandidateApplicationLetterAttachDocuments(HttpPostedFileBase[] applicationletter)
        {
            try
            {
                foreach (HttpPostedFileBase file in applicationletter)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var ApplicantNumber = Session["ApplicantNo"].ToString();
                        var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                        var CandidateName = Session["fullname"].ToString();
                        var NewCandidateName = CandidateName.Replace(' ', '_');
                        string CandidatePath = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Application Letter and CV"));
                        if (!Directory.Exists(CandidatePath))
                            Directory.CreateDirectory(CandidatePath);
                        string path = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Application Letter and CV"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        var FileNameDetails = Path.GetFileName(file.FileName);
                        file.SaveAs(path);
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNumber, FileNameDetails, path);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success1"] = "Applicant File(s) were uploaded successfully";
                        }
                        else
                        {
                            TempData["error1"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload";
                        }
                    }
                    else
                    {
                        TempData["success1"] = "The File Attached has been Uploaded Successfully.But you have not attached all the Documents for this Section";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error1"] = "Candidate File(s) could not be uploaded.Kindly Attach Documents to Upload" + ex.Message;

            }
            return Redirect("CandidateAttachDocuments");
        }
        [HttpPost]
        public ActionResult UploadCandidateProffessionalQualificationsAttachDocuments(HttpPostedFileBase[] qualifications)
        {
            try
            {
                foreach (HttpPostedFileBase file in qualifications)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                        var CandidateName = Session["fullname"].ToString();
                        var NewCandidateName = CandidateName.Replace(' ', '_');
                        string CandidatePath = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"));
                        if (!Directory.Exists(CandidatePath))
                            Directory.CreateDirectory(CandidatePath);
                        string path = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        var ApplicantNumber = Session["ApplicantNo"].ToString();
                        var FileNameDetails = Path.GetFileName(file.FileName);
                        file.SaveAs(path);
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNumber, FileNameDetails, path);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success2"] = "Applicant File(s) were uploaded successfully";
                        }
                        else
                        {
                            TempData["error2"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload";
                        }
                    }
                    else
                    {
                        TempData["success2"] = "The File Attached has been Uploaded Successfully.But you have not attached all the Documents for this Section";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error2"] = "Candidate File(s) could not be uploaded.Kindly Attach Documents to Upload" + ex.Message;

            }
            return Redirect("CandidateAttachDocuments");
        }
        [HttpPost]
        public ActionResult UploadCandidateJournalsAttachDocuments(HttpPostedFileBase[] proposals)
        {
            try
            {
                foreach (HttpPostedFileBase file in proposals)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                        var CandidateName = Session["fullname"].ToString();
                        var NewCandidateName = CandidateName.Replace(' ', '_');
                        string CandidatePath = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Proposals & Published Journals"));
                        if (!Directory.Exists(CandidatePath))
                            Directory.CreateDirectory(CandidatePath);
                        string path = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Proposals & Published Journals"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        var ApplicantNumber = Session["ApplicantNo"].ToString();
                        var FileNameDetails = Path.GetFileName(file.FileName);
                        file.SaveAs(path);
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNumber, FileNameDetails, path);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success3"] = "Applicant File(s) were uploaded successfully";
                        }
                        else
                        {
                            TempData["error3"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload";
                        }
                    }
                    else
                    {
                        TempData["success3"] = "The File Attached has been Uploaded Successfully.But you have not attached all the Documents for this Section";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Candidate File(s) could not be uploaded.Kindly Attach Documents to Upload" + ex.Message;

            }
            return Redirect("CandidateAttachDocuments");
        }
        [HttpPost]
        public ActionResult UploadCandidateAttachDocuments(HttpPostedFileBase[] files)
        {
            try
            {
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                        string CandidatePath = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber));
                        if (!Directory.Exists(CandidatePath))
                            Directory.CreateDirectory(CandidatePath);
                        string path = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        var ApplicantNumber = Session["ApplicantNo"].ToString();
                        var FileNameDetails = Path.GetFileName(file.FileName);
                        file.SaveAs(path);
                        var nav = new NavConnection().ObjNav();
                        var status = nav.FnCreateCandidateDocumentsLink(ApplicantNumber, JobApplicationNumber, FileNameDetails, path);
                        var res = status.Split('*');
                        if (res[0] == "success")
                        {
                            TempData["success"] = "Applicant File(s) were uploaded successfully";
                        }
                        else
                        {
                            TempData["error"] = "Applicant File(s) could not be uploaded.Kindly Attach Documents to Upload";
                        }
                    }
                    else
                    {
                        TempData["error"] = "Candidate File(s) could not be uploaded.Kindly Attach Documents to Upload";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Candidate File(s) could not be uploaded.Kindly Attach Documents to Upload" + ex.Message;

            }
            return Redirect("CandidateAttachDocuments");
        }
        public ActionResult DeleteAcademicQualificationsCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);
                TempData["success"] = "Candidate File(s) Was successfully Deleted";
            }
            return Redirect("CandidateAttachDocuments");
        }
        public ActionResult DeleteChapter6CandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Chapter 6 Requirements"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);
                TempData["success"] = "Candidate File(s) Was successfully Deleted";
            }
            return Redirect("CandidateAttachDocuments");
        }
        public ActionResult DeleteApplicationLetterCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Application Letter and CV"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);
                TempData["success1"] = "Candidate File(s) Was successfully Deleted";
            }
            return Redirect("CandidateAttachDocuments");
        }
        public ActionResult DeleteJournalsCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Proposals & Published Journals"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);
                TempData["success2"] = "Candidate File(s) Was successfully Deleted";
            }
            return Redirect("CandidateAttachDocuments");
        }
        public ActionResult DownloadChapter6CandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Chapter 6 Requirements"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            byte[] fileBytes = GetFile(FullFilNamePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FullFilNamePath);
        }
        public ActionResult DownloadApplicationLetterCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Application Letter and CV"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            byte[] fileBytes = GetFile(FullFilNamePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FullFilNamePath);
        }
        public ActionResult DownloadAcademicQualificationsCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            byte[] fileBytes = GetFile(FullFilNamePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FullFilNamePath);
        }
        public ActionResult DownloadJournalsCandidateFile(string FileName)
        {
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"));
            var FullFilNamePath = rootFolder + "/" + FileName;
            byte[] fileBytes = GetFile(FullFilNamePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FullFilNamePath);
        }
        
        public JsonResult GetCandidateDocumentsChapter6UploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Chapter 6 Requirements"));
            var subfolder = Path.Combine(rootFolder);
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            var files = Directory.GetFiles(rootFolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;
                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(new { data = uploadedFiles }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCandidateDocumentsApplicationsLetterUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Application Letter and CV"));
            var subfolder = Path.Combine(rootFolder);
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            var files = Directory.GetFiles(rootFolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;
                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(new { data = uploadedFiles }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCandidateDocumentsAcademicQualificationsUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Academic & Professional Qualifications"));
            var subfolder = Path.Combine(rootFolder);
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            var files = Directory.GetFiles(rootFolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;
                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(new { data = uploadedFiles }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCandidateDocumentsJournalsUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
            var CandidateName = Session["fullname"].ToString();
            var NewCandidateName = CandidateName.Replace(' ', '_');
            string rootFolder = Path.Combine(Server.MapPath("~/DocumentsUploads/JobApplications/" + JobApplicationNumber + '_' + NewCandidateName + "/Proposals & Published Journals"));
            var subfolder = Path.Combine(rootFolder);
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);

            var files = Directory.GetFiles(rootFolder);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new FileModel { FileName = Path.GetFileName(file) };
                uploadedFile.Size = fileInfo.Length;
                uploadedFile.Path = (subfolder) + "/" + Path.GetFileName(file);
                uploadedFiles.Add(uploadedFile);
            }

            return Json(new { data = uploadedFiles }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Personalinformation()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var nav = NavConnection.ReturnNav();
                var PrefixList = new SelectList(new[]
              {
                new { ID = "0", Name = "-----Choose Salutation----- " },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Miss" },
                new { ID = "6", Name = "Ms" }, },
                "ID", "Name", 0);
                ViewBag.Prefix = PrefixList;

                var GenderList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Gender----- " },
                new { ID = "1", Name = "Male" },
                new { ID = "2", Name = "Female" },
                new { ID = "3", Name = "Other" }, },
                   "ID", "Name", 0);
                ViewBag.Gender = GenderList;

                var MaritalList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Marital Status----- " },
                new { ID = "1", Name = "Single" },
                new { ID = "2", Name = "Married" },
                new { ID = "3", Name = "Divorced" },
                new { ID = "3", Name = "Others" },},
                 "ID", "Name", 0);
                ViewBag.Marital = MaritalList;

                var RelegionList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Religion----- " },
                new { ID = "1", Name = "Christianity" },
                new { ID = "2", Name = "Islam" },
                new { ID = "3", Name = "Hinduism" },
                new { ID = "3", Name = "Buddhism" },
                new { ID = "3", Name = "Folk Religion" },
                new { ID = "3", Name = "Others" },},
                "ID", "Name", 0);
                ViewBag.Religion = RelegionList;

                var DisabledList = new SelectList(new[]
             {
                new { ID = "0", Name = "-----Are you Disabled----- " },
                new { ID = "1", Name = "No" },
                new { ID = "2", Name = "Yes" },},
               "ID", "Name", 0);
                ViewBag.Disabled = DisabledList;

                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var countieslist = nav.Counties.ToList();
                var allcountieslist = new SelectList(countieslist, "Code", "County_Name");
                ViewBag.Counties = allcountieslist;

                var postcodeslist = nav.postcodes.ToList();
                var allpostcodeslist = new SelectList(postcodeslist, "Code", "City");
                ViewBag.PostCodes = allpostcodeslist;

                var ethnicitylist = nav.EthnicBackground.ToList();
                var allethnicitylist = new SelectList(ethnicitylist, "Code", "Ethnic_group");
                ViewBag.Ethnicity = allethnicitylist;

                try
                {
                    ApplicantProfileMode profile = new ApplicantProfileMode();

                    string ApplicantNo = Convert.ToString(Session["ApplicantNo"]);
                    var query = nav.ApplicantProfile.Where(x => x.Candidate_No == ApplicantNo).ToList();

                    foreach (var profiles in query)
                    {

                        profile.Prefix = profiles.Tittles;
                        profile.Disabled = Convert.ToInt32(profiles.Disabled);
                        profile.City = profiles.City;
                        profile.Gender = profiles.Gender;
                        profile.AlternativeEmailAddress = profiles.E_Mail;
                        profile.First_Name = profiles.First_Name;
                        profile.County_of_Residence = profiles.County_of_Birth;
                        profile.Disability_Description = profiles.Disability_Description;
                        profile.Last_Name = profiles.Last_Name;
                        profile.Middle_Name = profiles.Middle_Name;
                        profile.IDNumber = profiles.ID_Number;
                        profile.Passport_No = profiles.Passport_No;
                        profile.Nationality = profiles.Nationality;
                        profile.Religion = profiles.Religion;
                        profile.Post_Code = profiles.Post_Code;
                        profile.City = profiles.City;
                        profile.County_of_Birth = profiles.County_of_Birth;
                        profile.Ethnic_Group = profiles.Ethnic_Group;
                        profile.Mobile_Phone_No = profiles.Mobile_Phone_No;
                        profile.Phone_No = profiles.Phone_No;
                        profile.Marital_Status = profiles.Marital_Status;
                        profile.Address = profiles.Address;
                        profile.Disability_Code = profiles.Disability_Certificate_No;
                        profile.Email_Address = profiles.E_Mail;
                        profile.KRA_Pin = profiles.KRA_Pin;
                        profile.DOB = Convert.ToDateTime(profiles.Birth_Date).ToString("MM/dd/yyyy");
                        profile.NSSF = profiles.NSSF_No;
                        profile.NHIF = profiles.NHIF_No;
                        profile.Full_Names = profiles.Full_Names;

                    }
                    return View("Personalinformation", profile);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public ActionResult AcademicQualifications()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var nav = NavConnection.ReturnNav();

                var EducationLevelList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Educationl Level----- " },
                new { ID = "1", Name = "Post Doctorate" },
                new { ID = "2", Name = "PHD" },
                new { ID = "3", Name = "Masters" },
                new { ID = "4", Name = "Degree" },
                new { ID = "5", Name = "Post Graduate Diploma" },
                new { ID = "6", Name = "Diploma" },
                new { ID = "7", Name = "Certificate" }, },
                "ID", "Name", 0);
                ViewBag.EducationLevel = EducationLevelList;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "1", Name = "First Class Hons" },
                new { ID = "2", Name = "Second Class Upper" },
                new { ID = "3", Name = "Second Class Lower" },
                new { ID = "4", Name = "Destinction" },
                new { ID = "5", Name = "Pass" },
                new { ID = "6", Name = "Credit" },
                new { ID = "7", Name = "Others" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;

                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var specializationlist = nav.SpecializationAreas.ToList();
                var allspecializationlist = new SelectList(specializationlist, "Code", "Description");
                ViewBag.Specialization = allspecializationlist;


                try
                {
                    //AcademicQualificationModel academic = new AcademicQualificationModel();
                    //string ApplicantNo = Convert.ToString(Session["ApplicantNo"]);
                    //var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNo && x.Qualification_Category == "Academic").ToList();
                    //foreach (var academics in query)
                    //{
                    //    academic.Institution = academics.Institution_Company;
                    //    academic.Country = Convert.ToString(academics.Country);
                    //    academic.QualificationTitle = academics.Qualification_Category;
                    //    academic.specializationArea = academics.Specialized_Domain_Area;
                    //    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    //    academic.GraduationYear = academics.Graduation_Year;
                    //    academic.StartDate = Convert.ToString(academics.From_Date);
                    //    academic.EndDate = Convert.ToString(academics.To_Date);

                    // }
                    return View("AcademicQualifications");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

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
                var nav = NavConnection.ReturnNav();

                var EducationLevelList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Educationl Level----- " },
                new { ID = "1", Name = "Post Doctorate" },
                new { ID = "2", Name = "PHD" },
                new { ID = "3", Name = "Masters" },
                new { ID = "4", Name = "Degree" },
                new { ID = "5", Name = "Post Graduate Diploma" },
                new { ID = "6", Name = "Diploma" },
                new { ID = "7", Name = "Certificate" }, },
                "ID", "Name", 0);
                ViewBag.EducationLevel = EducationLevelList;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "1", Name = "First Class Hons" },
                new { ID = "2", Name = "Second Class Upper" },
                new { ID = "3", Name = "Second Class Lower" },
                new { ID = "4", Name = "Destinction" },
                new { ID = "5", Name = "Pass" },
                new { ID = "6", Name = "Credit" },
                new { ID = "7", Name = "Others" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;

                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var specializationlist = nav.SpecializationAreas.ToList();
                var allspecializationlist = new SelectList(specializationlist, "Code", "Description");
                ViewBag.Specialization = allspecializationlist;


                try
                {
                    //AcademicQualificationModel academic = new AcademicQualificationModel();
                    //string ApplicantNo = Convert.ToString(Session["ApplicantNo"]);
                    //var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNo && x.Qualification_Category == "Academic").ToList();
                    //foreach (var academics in query)
                    //{
                    //    academic.Institution = academics.Institution_Company;
                    //    academic.Country = Convert.ToString(academics.Country);
                    //    academic.QualificationTitle = academics.Qualification_Category;
                    //    academic.specializationArea = academics.Specialized_Domain_Area;
                    //    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    //    academic.GraduationYear = academics.Graduation_Year;
                    //    academic.StartDate = Convert.ToString(academics.From_Date);
                    //    academic.EndDate = Convert.ToString(academics.To_Date);

                    // }
                    return View("EducationBackground");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AcademicQualifications(AcademicQualificationModel AcademicModel)
        {
            try
            {
                var navQueries = NavConnection.ReturnNav();

                var EducationLevelList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Educationl Level----- " },
                new { ID = "1", Name = "Post Doctorate" },
                new { ID = "2", Name = "PHD" },
                new { ID = "3", Name = "Masters" },
                new { ID = "4", Name = "Degree" },
                new { ID = "5", Name = "Post Graduate Diploma" },
                new { ID = "6", Name = "Diploma" },
                new { ID = "7", Name = "Certificate" }, },
                "ID", "Name", 0);
                ViewBag.EducationLevel = EducationLevelList;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "1", Name = "First Class Hons" },
                new { ID = "2", Name = "Second Class Upper" },
                new { ID = "3", Name = "Second Class Lower" },
                new { ID = "4", Name = "Destinction" },
                new { ID = "5", Name = "Pass" },
                new { ID = "6", Name = "Credit" },
                new { ID = "7", Name = "Others" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;

                var countrieslist = navQueries.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var specializationlist = navQueries.SpecializationAreas.ToList();
                var allspecializationlist = new SelectList(specializationlist, "Code", "Description");
                ViewBag.Specialization = allspecializationlist;
                bool haserrors = false;
                var nav = new NavConnection().ObjNav();
                if (string.IsNullOrEmpty(AcademicModel.Institution))
                {
                    ModelState.AddModelError("Institution", "Please enter the Institution Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.Country))
                {
                    ModelState.AddModelError("Country", "Please enter the Country Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.QualificationTitle))
                {
                    ModelState.AddModelError("QualificationTitle", "Please enter the Qualifications Title");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.specializationArea))
                {
                    ModelState.AddModelError("specializationArea", "Please enter the Specialization Qualifications");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    ModelState.AddModelError("AttainedScore", "Please enter the Attained Score");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.AttainedScore))
                {
                    ModelState.AddModelError("AttainedScore", "Please enter the Attained Score");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.StartDate))
                {
                    ModelState.AddModelError("StartDate", "Please enter the Start Date");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(AcademicModel.EndDate))
                {
                    ModelState.AddModelError("EndDate", "Please enter the End Date");
                    haserrors = true;
                }
                if (haserrors == false)
                {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                DateTime tStartDate, tEnddate;
                CultureInfo usCulture = new CultureInfo("es-ES");
                tStartDate = DateTime.Parse(AcademicModel.StartDate, usCulture.DateTimeFormat);
                tEnddate = DateTime.Parse(AcademicModel.EndDate, usCulture.DateTimeFormat);
                var status = nav.FnApplicationAcademicQualifications(ApplicantNumber, JobApplicationNo, Convert.ToInt32(AcademicModel.EducationLevel), AcademicModel.Institution, AcademicModel.Country,
                    AcademicModel.QualificationTitle, AcademicModel.specializationArea, Convert.ToInt32(AcademicModel.AttainedScore), AcademicModel.GraduationYear, tStartDate, tEnddate);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Academic Details has been saved successfully";
                }
                else
                {
                    TempData["error"] = "The Academic Details could not be saved" + res[1];
                }

                }
                else
                {
                        TempData["error"] = "The Academic  Details could not be saved Kindly fill in all the Required information with (*) Asterick";
                    
                }
                }
            catch (Exception ex)
            {
                TempData["error"] = "The Academic Details could not be saved" + ex.Message;
            }
            return View("AcademicQualifications");
        }
        [HttpGet]
        public JsonResult GetApplicantAcademicQualifications()
        {

            List<AcademicQualificationModel> Qualifications = new List<AcademicQualificationModel>();
            try
            {

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Academic" && x.Application_No == JobApplicationNumber).ToList();
                foreach (var academics in query)
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    academic.EntryNo = academics.Line_No;
                    academic.Institution = academics.Institution_Company;
                    academic.EducationLevel = academics.Education_Level;
                    academic.Country = Convert.ToString(academics.Country);
                    academic.QualificationTitle = academics.Qualification_Category;
                    academic.specializationArea = academics.Specialized_Domain_Area;
                    academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                    academic.GraduationYear = academics.Graduation_Year;
                    academic.StartDate = Convert.ToDateTime(academics.From_Date).ToString();
                    academic.EndDate = Convert.ToString(academics.To_Date);
                    Qualifications.Add(academic);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = Qualifications }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCandidateRefereeDetails()
        {

            List<RefereesModel> RefereeList = new List<RefereesModel>();
            try
            {
                
                var nav = NavConnection.ReturnNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
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
                    RefereeList.Add(referee);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = RefereeList }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetApplicantEmploymentDetails()
        {

            List<EmploymentDetailsModel> EmploymentDetails = new List<EmploymentDetailsModel>();
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
                    proffessional.StartDate = Convert.ToDateTime(proffessionals.From_Date).ToString("MM/dd/yyyy");
                    proffessional.EndDate = Convert.ToDateTime(proffessionals.To_Date).ToString("MM/dd/yyyy");
                    proffessional.TermsofService = proffessionals.Terms_of_Service;
                    proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                    proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    EmploymentDetails.Add(proffessional);
                }

            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = EmploymentDetails }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("Referees")]
        public ActionResult CandidateReferees(RefereesModel RefModel)
        {
            try
            {


                var navQueries = NavConnection.ReturnNav();
                var RefreeList = new SelectList(new[]
                {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
               "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var countrieslist = navQueries.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;
                bool haserrors = false;
                if (string.IsNullOrEmpty(RefModel.Refereetype))
                {
                    ModelState.AddModelError("Refereetype", "Please enter referee Type");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.Title))
                {
                    ModelState.AddModelError("Title", "Please select Title");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.SurName))
                {
                    ModelState.AddModelError("SurName", "Please enter SurName");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.FirstName))
                {
                    ModelState.AddModelError("FirstName", "Please enter First Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.OtherNames))
                {
                    ModelState.AddModelError("OtherNames", "Please enter Other Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.Designations))
                {
                    ModelState.AddModelError("Designations", "Please enter Designation");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.institution))
                {
                    ModelState.AddModelError("institution", "Please enter Institution Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.EmailAddress))
                {
                    ModelState.AddModelError("EmailAddress", "Please enter Email Address");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.PhoneNumber))
                {
                    ModelState.AddModelError("PhoneNumber", "Please enter Phone Number");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.Relationship))
                {
                    ModelState.AddModelError("Relationship", "Please enter Relationship");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.Country))
                {
                    ModelState.AddModelError("Country", "Please enter Country Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(RefModel.knownyears))
                {
                    ModelState.AddModelError("knownyears", "The Period from which the Referee have Known You");
                    haserrors = true;
                }
                if (haserrors == false)
                {
                    var nav = new NavConnection().ObjNav();
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                    var status = nav.FnApplicationCandidateReferees(ApplicantNumber, JobApplicationNo, Convert.ToInt32(RefModel.Refereetype), RefModel.Title, RefModel.SurName,
                       RefModel.FirstName, RefModel.OtherNames, RefModel.Designations, RefModel.EmailAddress, RefModel.PhoneNumber, RefModel.Relationship, RefModel.Country, RefModel.knownyears, RefModel.institution);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        TempData["success"] = "The Referee Details has been submitted successfully";
                    }
                    else
                    {
                        TempData["error"] = "The Referee Details  could not be submitted" + res[1];
                    }
                }
                else
                {
                    TempData["error"] = "The Referee  Details could not be saved Kindly fill in all the Required information with (*) Asterick";

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Referee Details  could not be submitted" + ex.Message;
            }
            return View("Referees");
        }
        [HttpGet]
        public JsonResult GetProffessionalQualification()
        {

            List<ProffessionalQualificationModel> proffessionalList = new List<ProffessionalQualificationModel>();

            try
            {
                
                var nav = NavConnection.ReturnNav();
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Professional").ToList();
                foreach (var proffessionals in query)
                {
                    ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                    proffessional.EntryNo = proffessionals.Line_No;
                    proffessional.ProffessionalQualification = proffessionals.Proffessional_Qualification;
                    proffessional.Institution = proffessionals.Institution_Company;
                    proffessional.Country = Convert.ToString(proffessionals.Country);
                    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    proffessionalList.Add(proffessional);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = proffessionalList }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProffessionalBodiesQualification()
        {

            List<ProfessionalBodiesModel> proffessionalList = new List<ProfessionalBodiesModel>();

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
                    proffessional.MembershipDateRenewal = Convert.ToDateTime(proffessionals.Member_Renewal_Date).ToString("MM/dd/yyyy");
                    proffessional.LicensingNumber = proffessionals.Licensing_Number;
                    proffessional.licensingDateRenewal = Convert.ToDateTime(proffessionals.Licensing_Renewal_Date).ToString("MM/dd/yyyyy");
                    proffessionalList.Add(proffessional);

                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = proffessionalList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("EmploymentExperience")]
        public ActionResult SubmitEmploymentExperience(EmploymentDetailsModel EmployModel)
        {
            try
            {
                bool haserrors = false;
                if (string.IsNullOrEmpty(EmployModel.EmployerName))
                {
                    ModelState.AddModelError("EmployerName", "Please enter your Employer Name");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(EmployModel.Designation))
                {
                    ModelState.AddModelError("Designation", "Please enter your Designation Title");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(EmployModel.EndDate))
                {
                    ModelState.AddModelError("EndDate", "Please enter your Employment End");
                    haserrors = true;

                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    ModelState.AddModelError("TermsofService", "Please  the terms of service");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(EmployModel.TotalYears))
                {
                    ModelState.AddModelError("TotalYears", "Please  the  Total Number of Years of relevant work experience for this job");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(EmployModel.TermsofService))
                {
                    ModelState.AddModelError("TermsofService", "Please the  Total Number of Years of relevant work experience for this job");
                    haserrors = true;
                }
                if (haserrors == false)
                {
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
                    if (res[0] == "success")
                    {
                        TempData["success"] = "The Eduction Details has bee submitted successfully";
                    }
                    else
                    {
                        TempData["error"] = "The Eduction Details could not be saved.Kindly try agin later." + res[1];
                    }
                }
                else
                {
                    TempData["error"] = "The Emplyoment  Details could not be saved Kindly fill in all the Required information with (*) Asterick";

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Eduction Details could not be saved.Kindly try agin later." + ex.Message;
            }
            return RedirectToAction("EmploymentExperience");
        }
        [HttpGet]
        public JsonResult GetAllCandidateProffessionalBodies()
        {

            List<ProfessionalBodiesModel> proffesionalbodieslist = new List<ProfessionalBodiesModel>();
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
                    proffesionalbodieslist.Add(proffessional);
                }


            }
            catch (Exception e)
            {

                throw;
            }
            return Json(new { data = proffesionalbodieslist }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditAcademicQualifcations(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var navQueries = NavConnection.ReturnNav();

                var EducationLevelList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Educationl Level----- " },
                new { ID = "1", Name = "Post Doctorate" },
                new { ID = "2", Name = "PHD" },
                new { ID = "3", Name = "Masters" },
                new { ID = "4", Name = "Degree" },
                new { ID = "5", Name = "Post Graduate Diploma" },
                new { ID = "6", Name = "Diploma" },
                new { ID = "7", Name = "Certificate" }, },
                "ID", "Name", 0);
                ViewBag.EducationLevel = EducationLevelList;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "1", Name = "First Class Hons" },
                new { ID = "2", Name = "Second Class Upper" },
                new { ID = "3", Name = "Second Class Lower" },
                new { ID = "4", Name = "Destinction" },
                new { ID = "5", Name = "Pass" },
                new { ID = "6", Name = "Credit" },
                new { ID = "7", Name = "Others" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;


                try
                {
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Academic").ToList();
                    foreach (var academics in query)
                    {
                        academic.EducationLevel = academics.Education_Level;
                        academic.Institution = academics.Institution_Company;
                        academic.Country = Convert.ToString(academics.Country);
                        academic.QualificationTitle = academics.Qualification_Category;
                        academic.specializationArea = academics.Specialized_Domain_Area;
                        academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                        academic.GraduationYear = academics.Graduation_Year;
                        academic.StartDate = Convert.ToDateTime(academics.From_Date).ToString("MM/dd/yyyy");
                        academic.EndDate = Convert.ToDateTime(academics.To_Date).ToString("MM/dd/yyyy");

                    }

                    var countrieslist = navQueries.Countries.ToList();
                    ViewBag.Countries = new SelectList(countrieslist, "Code", "Name", academic.Country);

                    var specializationlist = navQueries.SpecializationAreas.ToList();
                    ViewBag.Specialization = new SelectList(specializationlist, "Code", "Description", academic.specializationArea);


                    return View("EditAcademicQualifications", academic);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpGet]
        public ActionResult DeleteAcademicQualifications(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                try
                {
                   
                    AcademicQualificationModel academic = new AcademicQualificationModel();
                    var nav = NavConnection.ReturnNav();
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Academic" &&x.Line_No==id).ToList();
                    foreach (var academics in query)
                    {
                        academic.EducationLevel = academics.Education_Level;
                        academic.Institution = academics.Institution_Company;
                        academic.Country = Convert.ToString(academics.Country);
                        academic.QualificationTitle = academics.Qualification_Category;
                        academic.specializationArea = academics.Specialized_Domain_Area;
                        academic.AttainedScore = Convert.ToString(academics.Attained_Score);
                        academic.GraduationYear = academics.Graduation_Year;
                        academic.StartDate = Convert.ToDateTime(academics.From_Date).ToString("MM/dd/yyyy").ToString();
                        academic.EndDate = Convert.ToDateTime(academics.To_Date).ToString("MM/dd/yyyy").ToString();

                    }
                    return View("DeleteAcademicQualifications", academic);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DeleteAcademicQualifications")]
        public ActionResult DeleteAcademicQualificationsDetails(int id)
        {
            bool status = false;
            try
            {
                var navQueries = NavConnection.ReturnNav();

                var EducationLevelList = new SelectList(new[]
                {
                new { ID = "0", Name = "-----Choose Educationl Level----- " },
                new { ID = "1", Name = "Post Doctorate" },
                new { ID = "2", Name = "PHD" },
                new { ID = "3", Name = "Masters" },
                new { ID = "4", Name = "Degree" },
                new { ID = "5", Name = "Post Graduate Diploma" },
                new { ID = "6", Name = "Diploma" },
                new { ID = "7", Name = "Certificate" }, },
                "ID", "Name", 0);
                ViewBag.EducationLevel = EducationLevelList;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "1", Name = "First Class Hons" },
                new { ID = "2", Name = "Second Class Upper" },
                new { ID = "3", Name = "Second Class Lower" },
                new { ID = "4", Name = "Destinction" },
                new { ID = "5", Name = "Pass" },
                new { ID = "6", Name = "Credit" },
                new { ID = "7", Name = "Others" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;

                var countrieslist = navQueries.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var specializationlist = navQueries.SpecializationAreas.ToList();
                var allspecializationlist = new SelectList(specializationlist, "Code", "Description");
                ViewBag.Specialization = allspecializationlist;

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var processstatus = nav.FnDeleteJobAcademicDetails(id, ApplicantNumber);
                var res = processstatus.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Academic Details has been Deleted Successfully";
                    status = true;
                }
                else
                {
                    TempData["error"] = "The Academic Details Could not be deleted.Kindly Try Again Letter" + res[1];
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Academic Details Could not be deleted.Kindly Try Again Letter" + ex.Message;

            }
            return View("AcademicQualifications");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ApplicantProfileMode profileModel)
        {
            try
            {
                var nav = new NavConnection().ObjNav();
                if (string.IsNullOrEmpty(profileModel.Email_Address))
                {
                    TempData["error"] = "Please enter your Valid Email Address";
                }
                if (profileModel.Ethnic_Group == null)
                {
                    TempData["error"] = "Please enter a valid  Ethinicity Value";
                }
                if (string.IsNullOrEmpty(profileModel.Religion))
                {
                    TempData["error"] = "Please select the Religion";
                }
                if (string.IsNullOrEmpty(profileModel.Prefix))
                {
                    TempData["error"] = "Please select the Prefix";
                }
                if (string.IsNullOrEmpty(profileModel.First_Name))
                {
                    TempData["error"] = "Please Enter your First Name";
                }
                if (string.IsNullOrEmpty(profileModel.Othernames))
                {
                    profileModel.Othernames = "";
                }
                if (string.IsNullOrEmpty(profileModel.Surname))
                {
                    TempData["error"] = "Please Enter your SurName";
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
                 profileModel.Othernames, Convert.ToInt32(profileModel.Gender), Convert.ToInt32(profileModel.IDNumber), profileModel.Passport_No, profileModel.Nationality,Convert.ToInt32( profileModel.Religion), dateofbirth, profileModel.County_of_Birth,
                 profileModel.County_of_Residence, profileModel.Ethnic_Group, profileModel.NHIF, profileModel.NSSF, profileModel.Mobile_Phone_No, profileModel.KRA_Pin, Convert.ToInt32(profileModel.Marital_Status), profileModel.Address, profileModel.Disability_Code, profileModel.Disability_Description, profileModel.Phone_No, profileModel.areyoudisabled, profileModel.Post_Code, profileModel.skillscompetencies,profileModel.ManagementYears,profileModel.workexperienceYears,Convert.ToInt32(profileModel.EducationLevel));
                var res = status.Split('*');
                if (res[0] == "Success")
                {
                    TempData["success"] = "Personal Information Details has been successfully saved";
                }
                else
                {
                    TempData["error"] = "Personal Information Details could not be saved" + res[1];

                }
            }
            catch (Exception ex)
            {
                return Json("danger*" + ex.Message, JsonRequestBehavior.AllowGet);
            }
            return View("Index", profileModel);
        }
        [HttpGet]
        public ActionResult ProfessionalQualifications()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;


                ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                try
                {

                    //var ApplicantNumber = Session["ApplicantNo"].ToString();
                    //var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    //var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Professional").ToList();
                    //foreach (var proffessionals in query)
                    //{

                    //    proffessional.EntryNo = proffessionals.Line_No;
                    //    proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                    //    proffessional.Institution = proffessionals.Institution_Company;
                    //    proffessional.Country = Convert.ToString(proffessionals.Country);
                    //    proffessional.QualificationTitle = proffessionals.Qualification_Category;
                    //    proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                    //    proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                    //    proffessional.CompletionYear = proffessionals.Graduation_Year;
                    //    proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                    //    proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                    //    proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    //}
                }
                catch (Exception e)
                {

                    throw;
                }
                return View("ProfessionalQualifications");
            }

        }
        public ActionResult EditProfessionalQualifications(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var nav = NavConnection.ReturnNav();

                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;


                ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Professional" && x.Line_No == id).ToList();
                    foreach (var proffessionals in query)
                    {

                        proffessional.EntryNo = proffessionals.Line_No;
                        proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                        proffessional.Institution = proffessionals.Institution_Company;
                        proffessional.Country = Convert.ToString(proffessionals.Country);
                        proffessional.QualificationTitle = proffessionals.Qualification_Category;
                        proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                        proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                        proffessional.CompletionYear = proffessionals.Graduation_Year;
                        proffessional.StartDate = Convert.ToDateTime(proffessionals.From_Date).ToString("MM/dd/yyyy");
                        proffessional.EndDate = Convert.ToDateTime(proffessionals.To_Date).ToString("MM/dd/yyyy");
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                    var countrieslist = nav.Countries.ToList();
                    ViewBag.Countries = new SelectList(countrieslist, "Code", "Name", proffessional.Country);


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("EditProfessionalQualifications", proffessional);
            }

        }
        [HttpGet]
        public ActionResult DeleteProffessionalQualifications(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var nav = NavConnection.ReturnNav();

                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;


                ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                try
                {
                    
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Professional" && x.Line_No== id).ToList();
                    foreach (var proffessionals in query)
                    {

                        proffessional.EntryNo = proffessionals.Line_No;
                        proffessional.ProffessionalQualification = proffessionals.Qualification_Code;
                        proffessional.Institution = proffessionals.Institution_Company;
                        proffessional.Country = Convert.ToString(proffessionals.Country);
                        proffessional.QualificationTitle = proffessionals.Qualification_Category;
                        proffessional.Speciality = proffessionals.Specialized_Domain_Area;
                        proffessional.AttainedScore = Convert.ToString(proffessionals.Attained_Score);
                        proffessional.CompletionYear = proffessionals.Graduation_Year;
                        proffessional.StartDate = Convert.ToDateTime(proffessionals.From_Date).ToString("MM/dd/yyyy");
                        proffessional.EndDate = Convert.ToDateTime(proffessionals.To_Date).ToString("MM/dd/yyyy");
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                    var countrieslist = nav.Countries.ToList();
                    ViewBag.Countries = new SelectList(countrieslist, "Code", "Name", proffessional.Country);


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("DeleteProffessionalQualifications", proffessional);
            }

        }
        public ActionResult ProffessionalQualifications()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;


                ProffessionalQualificationModel proffessional = new ProffessionalQualificationModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Professional").ToList();
                    foreach (var proffessionals in query)
                    {

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
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View("ProffessionalQualifications", proffessional);
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProfessionalQualifications(ProffessionalQualificationModel ProffesionalModel)
        {
            try
            {
                var navQueries = NavConnection.ReturnNav();
                var countrieslist = navQueries.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;


                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;
                bool haserrors = false;
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalQualification))
                {
                    ModelState.AddModelError("ProffessionalQualification", "Please enter your Professional Qualification");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Institution))
                {
                    ModelState.AddModelError("Institution", "Please enter your Institution");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Country))
                {
                    ModelState.AddModelError("Country", "Please enter your Country");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.QualificationTitle))
                {
                    ProffesionalModel.QualificationTitle = "";
                }
                if (string.IsNullOrEmpty(ProffesionalModel.Speciality))
                {
                    ProffesionalModel.Speciality = "";
                }
                if (string.IsNullOrEmpty(ProffesionalModel.AttainedScore))
                {
                    ModelState.AddModelError("AttainedScore", "Please select your Attained Score");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.CompletionYear))
                {
                    ModelState.AddModelError("CompletionYear", "Please select your Completion Year");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.EndDate))
                {
                    ModelState.AddModelError("EndDate", "Please enter End Date");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.StartDate))
                {
                    ModelState.AddModelError("StartDate", "Please enter Start Date");
                    haserrors = true;
                }
                if (haserrors == false)
                {
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
                    if (res[0] == "success")
                    {
                        TempData["success"] = "The Proffessional Details has been submitted successfully";
                    }
                    else
                    {
                        TempData["error"] = "The Proffessional Details could not be sumitted" + res[1];
                    }
                }
                else
                {
                    TempData["error"] = "The Proffessional  Details could not be saved Kindly fill in all the Required information with (*) Asterick";

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Proffessional Details could not be sumitted" + ex.Message;
            }
            return View("ProfessionalQualifications");

        }
        public ActionResult RegistrationMembership()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                try
                {
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Proffessional Bodies").ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.ProffessionalBody = proffessionals.Institution_Company;
                        proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                        proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                        proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                        proffessional.LicensingNumber = proffessionals.Licensing_Number;
                        proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                return View("RegistrationMembership");
            }
        }

        public ActionResult EditRegistrationMembership(int id)
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Proffessional Bodies"&&x.Line_No==id).ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.ProffessionalBody = proffessionals.Institution_Company;
                        proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                        proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                        proffessional.MembershipDateRenewal = Convert.ToDateTime(proffessionals.Member_Renewal_Date).ToString("yyyy/MM/dd");
                        proffessional.LicensingNumber = proffessionals.Licensing_Number;
                        proffessional.licensingDateRenewal = Convert.ToDateTime(proffessionals.Licensing_Renewal_Date).ToString("yyyy/MM/dd");
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                return View("EditRegistrationMembership", proffessional);
            }
        }
        [HttpGet]
        public ActionResult DeleteRegistrationMembership(int id)
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Proffessional Bodies" &&x.Line_No==id).ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.ProffessionalBody = proffessionals.Institution_Company;
                        proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                        proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                        proffessional.MembershipDateRenewal = Convert.ToDateTime(proffessionals.Member_Renewal_Date).ToString("yyyy/MM/dd");
                        proffessional.LicensingNumber = proffessionals.Licensing_Number;
                        proffessional.licensingDateRenewal = Convert.ToDateTime(proffessionals.Licensing_Renewal_Date).ToString("yyyy/MM/dd");
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                return View("DeleteRegistrationMembership", proffessional);
            }
        }
        public ActionResult ProffessionalBodies()
        {

            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                ProfessionalBodiesModel proffessional = new ProfessionalBodiesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.JobApplicantsQualification.Where(x => x.Candidate_No == ApplicantNumber && x.Qualification_Category == "Proffessional Bodies").ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.ProffessionalBody = proffessionals.Institution_Company;
                        proffessional.RegistrationNo = proffessionals.Membership_Registration_No;
                        proffessional.MembershipType = Convert.ToString(proffessionals.Membership_Type);
                        proffessional.MembershipDateRenewal = Convert.ToString(proffessionals.Member_Renewal_Date);
                        proffessional.LicensingNumber = proffessionals.Licensing_Number;
                        proffessional.licensingDateRenewal = Convert.ToString(proffessionals.Licensing_Renewal_Date);
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
                return View("ProffessionalBodies");
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegistrationMembership(ProfessionalBodiesModel ProffesionalModel)
        {
            try
            {
                bool haserrors = false;
                if (string.IsNullOrEmpty(ProffesionalModel.ProffessionalBody))
                {
                    ModelState.AddModelError("ProffessionalBody", "Please enter the Proffessional Body");
                    haserrors = true;

                }
                if (string.IsNullOrEmpty(ProffesionalModel.RegistrationNo))
                {
                    ModelState.AddModelError("RegistrationNo", "Please enter the Registration Number");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipType))
                {
                    ModelState.AddModelError("MembershipType", "Please enter the Membership Type");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.licensingDateRenewal))
                {
                    ModelState.AddModelError("licensingDateRenewal", "Please enter the License Date of Renewal");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.LicensingNumber))
                {
                    ModelState.AddModelError("LicensingNumber", "Please enter the License  Number");
                    haserrors = true;
                }
                if (string.IsNullOrEmpty(ProffesionalModel.MembershipDateRenewal))
                {
                    ModelState.AddModelError("MembershipDateRenewal", "Please enter the Membership Date of Renewal");
                    haserrors = true;
                }
                if (haserrors == false)
                {
                    var nav = new NavConnection().ObjNav();
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplicationNo = Session["JobApplicationNumber"].ToString();
                    DateTime tMemberDate, tLicenseDate;
                    CultureInfo usCulture = new CultureInfo("es-ES");
                    tMemberDate = DateTime.Parse(ProffesionalModel.MembershipDateRenewal, usCulture.DateTimeFormat);
                    tLicenseDate = DateTime.Parse(ProffesionalModel.licensingDateRenewal, usCulture.DateTimeFormat);
                    var status = nav.FnApplicationProffessionaBodies(ApplicantNumber, JobApplicationNo, ProffesionalModel.ProffessionalBody, ProffesionalModel.RegistrationNo, ProffesionalModel.MembershipType, tMemberDate, ProffesionalModel.LicensingNumber, tLicenseDate);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        TempData["success"] = "The Registration and Membership to Professional Bodies has been successfully saved";
                    }
                    else
                    {
                        TempData["error"] = "The Registration and Membership to Professional Bodies could not be saved.Kindly try Again" + res[0];

                    }

                }
                else
                {
                    TempData["error"] = "The Registration of Membership  Details could not be saved Kindly fill in all the Required information with (*) Asterick";

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Registration and Membership to Professional Bodies could not be saved.Kindly try Again" + ex.Message;
            }
            return View("RegistrationMembership");
        }
      
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

        [HttpGet]
        public ActionResult CandidateAttachDocuments()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult UploadFiles(HttpPostedFileBase[] files)
        //{

        //    //iterating through multiple file collection   
        //        foreach (HttpPostedFileBase file in files)
        //        {
        //            //Checking file is available to save.  
        //            if (file != null)
        //            {
        //                var InputFileName = Path.GetFileName(file.FileName);
        //                var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
        //                //Save file to server folder  
        //                file.SaveAs(ServerSavePath);
        //                //assigning file uploaded status to ViewBag for showing message to user.  
        //                ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
        //            }

        //        }

        //}
        [HttpGet]
        public ActionResult DocumentsUpload()
        {
            return View();
        }
       
        public ActionResult DeleteCandidateFile(string FileName)
        {
            var ApplicationNumber = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/JobApplications/" + ApplicationNumber);
            var FullFilNamePath = rootFolder + "/" + FileName;
            if (System.IO.File.Exists(FullFilNamePath))
            {

                System.IO.File.Delete(FullFilNamePath);
                TempData["success"] = "Candidate File(s) Was successfully Deleted";
            }
            return Redirect("CandidateAttachDocuments");
        }

        public ActionResult DownloadCandidateFile(string FileName)
        {
            var CandidateNo = Session["ApplicantNo"].ToString();
            var ApplicationNumber = Session["JobApplicationNumber"].ToString();
            var rootFolder = Server.MapPath("~/DocumentsUploads/JobApplications/" + ApplicationNumber);
            var FullFilNamePath = rootFolder + "/" + FileName;
            byte[] fileBytes = GetFile(FullFilNamePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, FullFilNamePath);
        }
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        public JsonResult GetCandidateDocumentsUploadsList()
        {
            var uploadedFiles = new List<FileModel>();
            var CandidateNo = Session["ApplicantNo"].ToString();
            var ApplicationNumber = Session["JobApplicationNumber"].ToString();
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

            return Json(new { data = uploadedFiles }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EmploymentExperience()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var TermsofServiceList = new SelectList(new[]
                {
                new { ID = "0", Name = "--Choose Terms of Service-- " },
                new { ID = "1", Name = "Permanent and Pensionable" },
                new { ID = "2", Name = "Contract" },
                new { ID = "3", Name = "Casual" },
                new { ID = "4", Name = "Internship" },},
                   "ID", "Name", 0);
                ViewBag.TermsofService = TermsofServiceList;


                EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Experience").ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EmployerName = proffessionals.Institution_Company;
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.Designation = proffessionals.Job_Description_Designation;
                        proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                        proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                        proffessional.TermsofService = proffessionals.Terms_of_Service;
                        proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                        proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);

                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("EmploymentExperience");
            }
        }
        [HttpGet]
        public ActionResult EditEmploymentExperience(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var TermsofServiceList = new SelectList(new[]
                {
                new { ID = "0", Name = "--Choose Terms of Service-- " },
                new { ID = "1", Name = "Permanent and Pensionable" },
                new { ID = "2", Name = "Contract" },
                new { ID = "3", Name = "Casual" },
                new { ID = "4", Name = "Internship" },},
                   "ID", "Name", 0);
                ViewBag.TermsofService = TermsofServiceList;


                EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Experience" &&x.Line_No==id).ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EmployerName = proffessionals.Institution_Company;
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.Designation = proffessionals.Job_Description_Designation;
                        proffessional.StartDate = Convert.ToDateTime(proffessionals.From_Date).ToString("yyyy/MM/dd");
                        proffessional.EndDate = Convert.ToDateTime(proffessionals.To_Date).ToString("yyyy/MM/dd");
                        proffessional.TermsofService = proffessionals.Terms_of_Service;
                        proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                        proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);

                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("EditEmploymentExperience", proffessional);
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DeleteEmploymentExperience")]
        public ActionResult DeleteEmploymentExperienceDetails(int id)
        {
            try
            {
                var TermsofServiceList = new SelectList(new[]
                {
                new { ID = "0", Name = "--Choose Terms of Service-- " },
                new { ID = "1", Name = "Permanent and Pensionable" },
                new { ID = "2", Name = "Contract" },
                new { ID = "3", Name = "Casual" },
                new { ID = "4", Name = "Internship" },},
                "ID", "Name", 0);
                ViewBag.TermsofService = TermsofServiceList;


                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalQualificationDetails(id, ApplicantNumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Employment Details has been submitted successfully";
                }
                else
                {
                    TempData["error"] = "The Employment Details could not be deleted.Kindly try again";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Employment Details could not be Deleted.Kindly try Again Later" + ex.Message;

            }
            return View("EmploymentExperience");

        }

        [HttpGet]
        public ActionResult DeleteEmploymentExperience(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var TermsofServiceList = new SelectList(new[]
                {
                new { ID = "0", Name = "--Choose Terms of Service-- " },
                new { ID = "1", Name = "Permanent and Pensionable" },
                new { ID = "2", Name = "Contract" },
                new { ID = "3", Name = "Casual" },
                new { ID = "4", Name = "Internship" },},
               "ID", "Name", 0);
                ViewBag.TermsofService = TermsofServiceList;


                EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Experience").ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EmployerName = proffessionals.Institution_Company;
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.Designation = proffessionals.Job_Description_Designation;
                        proffessional.StartDate = Convert.ToDateTime(proffessionals.From_Date).ToString("MM/dd/yyyy");
                        proffessional.EndDate = Convert.ToDateTime(proffessionals.To_Date).ToString("MM/dd/yyyy");
                        proffessional.TermsofService = proffessionals.Terms_of_Service;
                        proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                        proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return View("DeleteEmploymentExperience", proffessional);
            }
        }
        [HttpGet]
        public ActionResult WorkExperience()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var TermsofServiceList = new SelectList(new[]
                {



                new { ID = "0", Name = "--Choose Terms of Service-- " },
                new { ID = "1", Name = "Permanent and Pensionable" },
                new { ID = "2", Name = "Contract" },
                new { ID = "3", Name = "Casual" },
                new { ID = "4", Name = "Internship" },},
                   "ID", "Name", 0);
                ViewBag.TermsofService = TermsofServiceList;


                EmploymentDetailsModel proffessional = new EmploymentDetailsModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var nav = NavConnection.ReturnNav();
                    var query = nav.ApplicationQualifications.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo && x.Qualification_Category == "Experience").ToList();
                    foreach (var proffessionals in query)
                    {
                        proffessional.EmployerName = proffessionals.Institution_Company;
                        proffessional.EntryNumber = Convert.ToString(proffessionals.Line_No);
                        proffessional.Designation = proffessionals.Job_Description_Designation;
                        proffessional.StartDate = Convert.ToString(proffessionals.From_Date);
                        proffessional.EndDate = Convert.ToString(proffessionals.To_Date);
                        proffessional.TermsofService = proffessionals.Terms_of_Service;
                        proffessional.TotalYears = Convert.ToString(proffessionals.Experience_Years);
                        proffessional.SummaryDetails = Convert.ToString(proffessionals.Duties_and_Resposibilities);

                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("WorkExperience");
            }
        }
        public ActionResult Referees()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var RefreeList = new SelectList(new[]
             {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
                "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                RefereesModel referee = new RefereesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationReferees.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo).ToList();
                    foreach (var referees in query)
                    {
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
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("Referees");
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubmitCandidateProfile(VacancyDeclarationModel model)

        {
            if (model.accespted == true)
            {
                try
                {
                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplicationNumber = Session["JobApplicationNumber"].ToString();
                    var nav = new NavConnection().ObjNav();
                    var status = nav.FnSubmitApplication(ApplicantNumber, JobApplicationNumber);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        TempData["success"] = "Your Job Application Details has been submitted successfully. Kindly Check your email Address for your Complete Job Application Summary";
                    }
                    else
                    {
                        TempData["error"] = "Your Job Application Details could not be sumitted successfully. Please fill in all the details and try again" + res[1];
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Your Job Application Details could not be sumitted successfully. Please fill in all the details and try again" + ex.Message;
                }
            }
            else
            {
                TempData["error"] = "Your Job Application Details could not be sumitted successfully. Please fill in all the details and Accept our Terms and Conditions";

            }
            return Redirect("DeclarationForms");
        }
        [HttpGet]
        public ActionResult EditReferees(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var RefreeList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
                "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                RefereesModel referee = new RefereesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationReferees.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo).ToList();
                    foreach (var referees in query)
                    {
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
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("EditReferees", referee);
            }
        }
      
        public ActionResult DeclarationForms()
        {

            
            try
            {
                VacancyDeclarationModel list = new VacancyDeclarationModel();
                var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = NavConnection.ReturnNav();
                var query = nav.ApplicationDeclaration.Where(x => x.Application_No == JobApplplicationNo).ToList();
                foreach (var openjobs in query)
                {
                    list.DeclarationDecsription = openjobs.Declaration_Statement;
                }
                return View("DeclarationForms", list);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DeleteRegistrationMembership")]
        public ActionResult DeleteProffesionalQualificationBodiesDetails(int id)
        {
            try
            {
                var ApplicantNumber = Session["ApplicantNo"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalBodiesDetails(id, ApplicantNumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Registration of Membership Details has been Deleted Successfully";
                }
                else
                {
                    TempData["error"] = "The Registration of Membership Details Could not be Deleted.Kindly Try Again";

                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Registration of Membership Details Could not be Deleted.Kindly Try Again" + ex.Message;

            }
            return View("RegistrationMembership");

        }
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DeleteProffessionalQualifications")]
        public ActionResult DeleteProffessionalQualificationsDetails(int id)
        {
            try
            {
                var navQuery = NavConnection.ReturnNav();
                var countrieslist = navQuery.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;
                var AttainedScoreList = new SelectList(new[]
               {
                new { ID = "0", Name = "-----Choose Attained Score----- " },
                new { ID = "4", Name = "Destinction" },
                new { ID = "4", Name = "Pass" },
                new { ID = "5", Name = "Credit" }, },
               "ID", "Name", 0);
                ViewBag.AttainedScore = AttainedScoreList;
                var ApplicantNumber = Session["ApplicantNo"].ToString();

                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobProffesionalQualificationDetails(id, ApplicantNumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Proffessional Qualifications Details Selected has been Deleted successfully";
                }
                else
                {
                    TempData["error"] = "The Proffessional Qualifications Details could not be Deleted successfully" + res[1];
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Proffessional Qualifications Details could not be Deleted successfully" + ex.Message;

            }
            return View("ProfessionalQualifications");

        }
        [HttpGet]
        public ActionResult DeleteReferees(int id)
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var RefreeList = new SelectList(new[]
             {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
                "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                RefereesModel referee = new RefereesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                    var query = nav.ApplicationReferees.Where(x => x.Candidate_No == ApplicantNumber && x.Application_No == JobApplplicationNo&&x.Line_No==id).ToList();
                    foreach (var referees in query)
                    {

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
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("DeleteReferees", referee);
            }
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ActionName("DeleteReferees")]
        public ActionResult DeleteCandidateRefreeDetails(int id)
        {
            try
            {
                var RefreeList = new SelectList(new[]
         {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
            "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var navQuery = NavConnection.ReturnNav();
                var countrieslist = navQuery.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                var ApplicantNumber = Session["ApplicantNo"].ToString();
                //var JobApplplicationNo = Session["JobApplicationNumber"].ToString();
                var nav = new NavConnection().ObjNav();
                var status = nav.FnDeleteJobApplicationRefereeDetails(id, ApplicantNumber);
                var res = status.Split('*');
                if (res[0] == "success")
                {
                    TempData["success"] = "The Candidate Details has been deleted Successfully";

                }
                else
                {
                    TempData["error"] = "The Candidate Details could not deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "The Candidate Details could not deleted Successfully" + ex.Message;

            }
            return View("Referees");

        }
        public ActionResult MyReferees()
        {
            if (Session["ApplicantNo"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {

                var RefreeList = new SelectList(new[]
             {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Previous Employer" },
                new { ID = "2", Name = "Current Employer" },
                new { ID = "3", Name = "Other Referee" },},
                "ID", "Name", 0);
                ViewBag.Referee = RefreeList;

                var TitlesList = new SelectList(new[]
                 {
                new { ID = "0", Name = "--Choose Referee Type--" },
                new { ID = "1", Name = "Prof" },
                new { ID = "2", Name = "Doctor" },
                new { ID = "3", Name = "Mr" },
                new { ID = "4", Name = "Mrs" },
                new { ID = "5", Name = "Ms" },},
                 "ID", "Name", 0);
                ViewBag.Titles = TitlesList;

                var nav = NavConnection.ReturnNav();
                var countrieslist = nav.Countries.ToList();
                var list = new SelectList(countrieslist, "Code", "Name");
                ViewBag.Countries = list;

                RefereesModel referee = new RefereesModel();
                try
                {

                    var ApplicantNumber = Session["ApplicantNo"].ToString();
                    var query = nav.Referees.Where(x => x.No == ApplicantNumber).ToList();
                    foreach (var referees in query)
                    {

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
                    }


                }
                catch (Exception e)
                {

                    throw;
                }
                return View("MyReferees");
            }
        }
    }
}