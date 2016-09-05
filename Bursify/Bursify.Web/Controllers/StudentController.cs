using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Web.Models;
using Bursify.Web.Utility.ModelClasses;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        private readonly StudentApi _studentApi;

        public StudentController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllStudents")]
        public HttpResponseMessage GetAllStudents(HttpRequestMessage request)
        {
            var students = _studentApi.GetAllStudents();

            var studentsVm = StudentViewModel.MapMultipleStudents(students);

            foreach (var model in studentsVm)
            {
                var report = _studentApi.GetMostRecentReport(model.ID);
                model.InstitutionName = _studentApi.GetInstitution(model.InstitutionID).Name;

                if (report != null)
                {
                    model.AverageMark = report.Average;
                }
            }

            var response = request.CreateResponse(HttpStatusCode.OK, studentsVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudent")]
        public HttpResponseMessage GetStudent(HttpRequestMessage request, int studentId)
        {
            var student = _studentApi.GetStudent(studentId);

            var model = new StudentViewModel(student);

            var report = _studentApi.GetMostRecentReport(studentId);
            model.InstitutionName = _studentApi.GetInstitution(model.InstitutionID).Name;

            if (report != null)
            {
                model.AverageMark = report.Average;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, model);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAddresses")]
        public HttpResponseMessage GetAddresses(HttpRequestMessage request, int userId)
        {
            var addresses = _studentApi.GetAddressofUser(userId);

            var addressVm = UserAddressViewModel.MapMultipleAddresses(addresses);

            var response = request.CreateResponse(HttpStatusCode.OK, addressVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("SaveStudent")]
        public HttpResponseMessage SaveStudent(HttpRequestMessage request, StudentViewModel student)
        {
            var newStudent = student.ReverseMap();

            _studentApi.SaveStudent(newStudent);

            var model = new StudentViewModel();

            var studentVm = model.MapSingleStudent(newStudent);

            var response = request.CreateResponse(HttpStatusCode.Created, studentVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("SaveAddress")]
        public HttpResponseMessage SaveAddress(HttpRequestMessage request, UserAddressViewModel address)
        {
            var newAddress = address.ReverseMap();

            _studentApi.SaveAddress(newAddress);

            var response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SavePersonalDetails")]
        public HttpResponseMessage SavePersonalDetails(HttpRequestMessage request, PersonalDetails details)
        {
            var user = _studentApi.GetStudent(details.StudentId);
            var bursifyUser = _studentApi.GetUserInfo(details.StudentId);

            if (user == null) return null;

            user.Firstname = details.Firstname;
            user.Surname = details.Surname;
            user.Headline = details.Headline;

            bursifyUser.Biography = details.Biograpghy;

            _studentApi.SaveStudent(user);

            _studentApi.UpdateUser(bursifyUser);

            var response = request.CreateResponse(HttpStatusCode.Accepted);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveContactDetails")]
        public HttpResponseMessage SaveContactDetails(HttpRequestMessage request, ContactDetails details)
        {
            var user = _studentApi.GetUserInfo(details.StudentId);
            var student = _studentApi.GetStudent(details.StudentId);
            var address = _studentApi.GetAddress(details.StudentId, details.AddressType);

            user.CellphoneNumber = details.CellphoneNumber;
            user.Email = details.Email;

            student.GuardianPhone = details.GuardianPhoneNumber;
            student.GuardianRelationship = details.GuardianRelationship;
            student.GuardianEmail = details.GuardianEmail;

            address.StreetAddress = details.StreetAddress;
            address.City = details.City;
            address.Province = details.Province;
            address.PostalCode = details.PostalCode;

            _studentApi.UpdateUser(user);
            _studentApi.SaveStudent(student);
            _studentApi.SaveAddress(address);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveEducationDetails")]
        public HttpResponseMessage SaveEducationDetails(HttpRequestMessage request, Education education)
        {
            Institution institution = null;
            var student = _studentApi.GetStudent(education.StudentId);
            var schoolExists = _studentApi.InstitutionExists(education.InstitutionName);

            if (schoolExists)
            {
                institution = _studentApi.GetInstitution(education.InstitutionName);                
            }
            else
            {
                institution = new Institution()
                {
                    Name = education.InstitutionName,
                    Type = education.CurrentOccupation
                };

                _studentApi.SaveInstitution(institution);
            }

            student.InstitutionID = institution.ID;
            student.StudyField = education.StudyField;
            student.CurrentOccupation = education.CurrentOccupation;

            _studentApi.SaveStudent(student);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ApplyForSponsorship")]
        public HttpResponseMessage ApplyForSponsorship(HttpRequestMessage request,
            StudentSponsorshipViewModel application)
        {
            var newApplication = new StudentSponsorship()
            {
                StudentId = application.StudentId,
                SponsorshipId = application.SponsorshipId,
                ApplicationDate = application.ApplicationDate,
                SponsorshipOffered = application.SponsorshipOffered,
                Status = application.Status
            };

            _studentApi.ApplyForSponsorship(newApplication);

            var model = new StudentSponsorshipViewModel();

            var applicationVm = model.MapSIngleStudentSponsorship(newApplication);

            var response = request.CreateResponse(HttpStatusCode.Created, applicationVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ConfirmSponsorship")]
        public HttpResponseMessage ConfirmSponsorship(HttpRequestMessage request, int studentId, int sponsorshipId,
            string confirmationMessage)
        {
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                var confirmed = _studentApi.ConfirmSponsorship(studentId, sponsorshipId, confirmationMessage);

                if (confirmed)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new {success = true});
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new {success = false});
                }
            }

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsorshipSuggestions")]
        public HttpResponseMessage GetSponsorshipSuggestions(HttpRequestMessage request, int studentId)
        {
            var suggestions = _studentApi.LoadSponsorshipSuggestions(studentId);

            var sponsorshipsVm = SponsorshipViewModel.MultipleSponsorshipsMap(suggestions);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipsVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetInstitution")]
        public HttpResponseMessage GetInstitution(HttpRequestMessage request, int userId)
        {
            var institution = _studentApi.GetInstitution(userId);

            var model = new InstitutionViewModel();

            var institutionVm = model.MapSingleInstitution(institution);

            var response = request.CreateResponse(HttpStatusCode.OK, institutionVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetInstitution")]
        public HttpResponseMessage GetInstitution(HttpRequestMessage request, string name, int userId)
        {
            var institution = _studentApi.GetExistingInstitution(name, userId);
            HttpResponseMessage response = null;

            if (institution != null)
            {
                response = request.CreateResponse(HttpStatusCode.OK, new {exists = true, institution.ID});
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new {exists = false});
            }

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveInstitution")]
        public HttpResponseMessage SaveInstitution(HttpRequestMessage request, InstitutionViewModel institution)
        {
            var newInstitution = new Institution()
            {
                ID = institution.ID,
                Name = institution.Name,
                Type = institution.Type,
                Website = institution.Website
            };

            _studentApi.SaveInstitution(newInstitution);

            var model = new InstitutionViewModel();

            var institutionVm = model.MapSingleInstitution(newInstitution);

            var response = request.CreateResponse(HttpStatusCode.Created, institutionVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveInstitution")]
        public HttpResponseMessage SaveInstitution(HttpRequestMessage request, string name, string type, string website)
        {
            var existing = _studentApi.GetInstitution(name);
            HttpResponseMessage response = null;

            if (existing == null)
            {
                var newInstitution = new Institution()
                {
                    Name = name,
                    Type = type,
                    Website = website
                };

                _studentApi.SaveInstitution(newInstitution);

                var model = new InstitutionViewModel();

                var institutionVm = model.MapSingleInstitution(newInstitution);

                response = request.CreateResponse(HttpStatusCode.Created, institutionVm);
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, existing.ID);
            }

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberSupportedCampaign")]
        public HttpResponseMessage GetNumberSupportedCampaign(HttpRequestMessage request, int campaignId)
        {
            int number = _studentApi.GetNumberOfCampaignSupporters(campaignId);

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetStudyFields")]
        public HttpResponseMessage GetStudyFields(HttpRequestMessage request, int studentId)
        {
            var student = _studentApi.GetStudent(studentId);
            var studyFields = new List<string>();

            if (student.StudyField.Contains(","))
            {
                studyFields = student.StudyField.Split(',').ToList();
            }
            else
            {
                studyFields.Add(student.StudyField);
            }

            var response = request.CreateResponse(HttpStatusCode.OK, studyFields);

            return response;
        }
    }
}