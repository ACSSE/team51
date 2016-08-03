using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Web.Models;

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

            var model = new StudentViewModel();

            var studentsVm = model.MapMultipleStudents(students);

            var response = request.CreateResponse(HttpStatusCode.OK, studentsVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudent")]
        public HttpResponseMessage GetStudent(HttpRequestMessage request, int studentId)
        {
            var student = _studentApi.GetStudent(studentId);

            var model = new StudentViewModel();

            var studentVm = model.MapSingleStudent(student);

            var response = request.CreateResponse(HttpStatusCode.OK, studentVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("SaveStudent")]
        public HttpResponseMessage SaveStudent(HttpRequestMessage request, StudentViewModel student)
        {
            var newStudent = new Student()
            {
                ID = student.ID,
                Surname = student.Surname,
                EducationLevel = student.EducationLevel,
                AverageMark = student.AverageMark,
                StudentNumber = student.StudentNumber,
                Age = student.Age,
                HasDisability = student.HasDisability,
                Race = student.Race,
                Gender = student.Gender,
                CurrentOccupation = student.CurrentOccupation,
                StudyField = student.StudyField,
                HighestAcademicAchievement = student.HighestAcademicAchievement,
                YearOfAcademicAchievement = student.YearOfAcademicAchievement,
                DateOfBirth = student.DateOfBirth,
                NumberOfViews = student.NumberOfViews
            };

            _studentApi.SaveStudent(newStudent);

            var model = new StudentViewModel();

            var studentVm = model.MapSingleStudent(newStudent);

            var response = request.CreateResponse(HttpStatusCode.Created, studentVm);

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
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
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

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.MultipleSponsorshipsMap(suggestions);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

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
    }
}
