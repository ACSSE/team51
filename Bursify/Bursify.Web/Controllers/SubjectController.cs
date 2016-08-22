using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.User;
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

            var subjectVm = SubjectViewModel.MapMultipleSubjects(subjects);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        //get all subjects for a specific level
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSubjects")]
        public HttpResponseMessage GetAllSubjects(HttpRequestMessage request, int requirementId)
        {
            var subjects = _studentApi.GetSubjects(requirementId);

            var subjectVm = SubjectViewModel.MapMultipleSubjects(subjects);

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

            var subjectVm = new SubjectViewModel().MapSingleSubject(subject);

            var response = request.CreateResponse(HttpStatusCode.OK, subjectVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddSubjects")]
        public HttpResponseMessage GetSubject(HttpRequestMessage request, List<Subject> subjects)
        {
            var mappedSubjects = SubjectViewModel.MapMultipleSubjects(subjects);
            var studentSubjects = new List<Subject>();

            foreach (var modelSubject in mappedSubjects)
            {
                studentSubjects.Add(modelSubject.ReverseMap());
            }

            _studentApi.AddSubjects(studentSubjects);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        #endregion
    }
}
