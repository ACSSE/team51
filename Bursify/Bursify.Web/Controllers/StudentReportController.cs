using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.User;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
    [RoutePrefix("api/Report")]
    public class StudentReportController : ApiController
    {
        private readonly StudentApi _studentApi;

        public StudentReportController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetReport")]
        public HttpResponseMessage GetReport(HttpRequestMessage request, int reportId, int studentId)
        {
            var report = _studentApi.GetStudentReport(reportId, studentId);

            var reportVm = (new StudentReportViewModel()).MapSingleReport(report);

            var response = request.CreateResponse(HttpStatusCode.OK, reportVm);

            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllReports")]
        public HttpResponseMessage GetAllReports(HttpRequestMessage request, int studentId)
        {
            var reports = _studentApi.GetStudentReports(studentId);

            var reportVm = (new StudentReportViewModel()).MapMultipleReports(reports);

            var response = request.CreateResponse(HttpStatusCode.OK, reportVm);

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveReport")]
        public HttpResponseMessage SaveReport(HttpRequestMessage request, StudentReportViewModel reportViewModel)
        {
            var newReport = reportViewModel.ReverseMap();

            _studentApi.SaveStudentReport(newReport);

            var response = request.CreateResponse(HttpStatusCode.Created, reportViewModel);

            return response;
        }
        
    }
}
