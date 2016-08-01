using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.User;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Subject")]
    public class SubjectController : ApiController
    {
        private readonly StudentApi _studentApi;

        public SubjectController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }

        #region Subject

        //get all subjects
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSubjects")]
        public HttpResponseMessage GetAllSubjects(HttpRequestMessage request)
        {
            var subjects = _studentApi.GetSubjects();

            var model = new SubjectViewModel();

            var subjectVm = model.MapMultipleSubjects(subjects);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        //get all subjects for a specific level
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSubjects")]
        public HttpResponseMessage GetAllSubjects(HttpRequestMessage request, string educationLevel)
        {
            var subjects = _studentApi.GetSubjects(educationLevel);

            var model = new SubjectViewModel();

            var subjectVm = model.MapMultipleSubjects(subjects);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        //get all subjects for a specific level
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSubject")]
        public HttpResponseMessage GetSubject(HttpRequestMessage request, int subjectId)
        {
            var subject = _studentApi.GetSubject(subjectId);

            var model = new SubjectViewModel();

            var subjectVm = model.MapSingleSubject(subject);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        //add a new subject
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("PostSubject")]
        public HttpResponseMessage PostSubject(HttpRequestMessage request, SubjectViewModel subject)
        {
            var newSubject = new Subject()
            {
                Name = subject.Name,
                SubjectLevel = subject.SubjectLevel
            };

            _studentApi.AddSubject(newSubject);

            var model = new SubjectViewModel();

            var subjectVm = model.MapSingleSubject(newSubject);

            var response = request.CreateResponse(HttpStatusCode.Created, subjectVm);

            return response;
        }

        #endregion

        #region StudentSubject

        //get all subjects for a student
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllStudentSubjects")]
        public HttpResponseMessage GetAllStudentSubjects(HttpRequestMessage request, int studentId)
        {
            var subjects = _studentApi.GetAllSubjects(studentId);

            var model = new SubjectViewModel();

            var subjectVm = model.MapMultipleStudentSubjects(subjects);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        //add a subject for a student
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("PostStudentSubject")]
        public HttpResponseMessage PostStudentSubject(HttpRequestMessage request, SubjectViewModel studentSubject)
        {
            var newStudentSubject = new StudentSubject()
            {
                StudentId = studentSubject.StudentId,
                SubjectId = studentSubject.SubjectId,
                MarkAcquired = studentSubject.MarkAcquired
            };

            _studentApi.AddStudentSubject(newStudentSubject);

            var model = new SubjectViewModel();

            var subjectVm = model.MapSingleStudentSubject(newStudentSubject);

            var response = request.CreateResponse(HttpStatusCode.Created, subjectVm);

            return response;
        }

        #endregion
    }
}
