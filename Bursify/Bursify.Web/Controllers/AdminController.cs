using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Administrators;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{ 

    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private AdminApi adminApi;

        public AdminController(AdminApi admin)
        {
            this.adminApi = admin;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddInstitution")]
        public HttpResponseMessage AddInstitution(HttpRequestMessage request, InstitutionViewModel institutionVm)
        {
            HttpResponseMessage response = null;

            if (institutionVm.Type.ToUpper().Equals("HIGHSCHOOL"))
            {
                adminApi.AddHighSchool(institutionVm.Name, institutionVm.Website);
            } else if (institutionVm.Type.ToUpper().Equals("UNIVERSITY"))
            {
                adminApi.AddUniversity(institutionVm.Name, institutionVm.Website);
            } else if (institutionVm.Type.ToUpper().Equals("COLLEGE"))
            {
                adminApi.AddCollege(institutionVm.Name, institutionVm.Website);
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            response = request.CreateResponse(HttpStatusCode.OK, new { success = true });

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddSubject")]
        public HttpResponseMessage AddSubject(HttpRequestMessage request, SubjectViewModel subjectVm)
        {
            adminApi.AddSubject(subjectVm.ReverseMap());

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("VerifyUser")]
        public HttpResponseMessage VerifyUser(HttpRequestMessage request,  int userId)
        {
            adminApi.VerifyUser(userId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("DeactivateUser")]
        public HttpResponseMessage DeactivateUser(HttpRequestMessage request, int userId)
        {
            adminApi.DeactivateUser(userId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("BanCampaign")]
        public HttpResponseMessage BanCampaign(HttpRequestMessage request, int campaignId)
        {
            adminApi.BanCampaign(campaignId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberActiveCampaigns")]
        public HttpResponseMessage GetNumberActiveCampaigns(HttpRequestMessage request)
        {
            int number = adminApi.GetNumberActiveCampaigns();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberCompletedCampaigns")]
        public HttpResponseMessage GetNumberCompletedCampaigns(HttpRequestMessage request)
        {
            int number = adminApi.GetNumberCompletedCampaigns();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberCancelledCampaigns")]
        public HttpResponseMessage GetNumberCancelledCampaigns(HttpRequestMessage request)
        {
            int number = adminApi.GetNumberCancelledCampaigns();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberOfRegisteredUsers")]
        public HttpResponseMessage GetNumberOfRegisteredUsers(HttpRequestMessage request)
        {
            int number = adminApi.GetNumberOfRegisteredUsers();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberOfInactiveUsers")]
        public HttpResponseMessage GetNumberOfInactiveUsers(HttpRequestMessage request)
        {
            int number = adminApi.GetNumberOfInactiveUsers();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetRegisteredStudents")]
        public HttpResponseMessage GetRegisteredStudents(HttpRequestMessage request)
        {
            int number = adminApi.GetRegisteredStudents();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetRegisteredSponsors")]
        public HttpResponseMessage GetRegisteredSponsors(HttpRequestMessage request)
        {
            int number = adminApi.GetRegisteredSponsors();

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetReportedCampaigns")]
        public HttpResponseMessage GetReportedCampaigns(HttpRequestMessage request)
        {
            var campaigns = adminApi.GetReportedCampaigns();

            var campaignVm = CampaignViewModel.MultipleCampaignsMap(campaigns);

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("RemoveCampaign")]
        public HttpResponseMessage RemoveCampaign(HttpRequestMessage request, int Id)
        {
            adminApi.RemoveCampaign(Id);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetUserReport")]
        public HttpResponseMessage GetUserReport(HttpRequestMessage request)
        {
            int registered = adminApi.GetNumberOfRegisteredUsers();
            int inactive = adminApi.GetNumberOfInactiveUsers();
            int students = adminApi.GetRegisteredStudents();
            int sponsors = adminApi.GetRegisteredSponsors();

            var report = new AdminUserReport(registered, inactive, students, sponsors);

            var response = request.CreateResponse(HttpStatusCode.OK, report);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaignReport")]
        public HttpResponseMessage GetCampaignReport(HttpRequestMessage request)
        {
            int active = adminApi.GetNumberActiveCampaigns();
            int completed = adminApi.GetNumberCompletedCampaigns();
            int cancelled = adminApi.GetNumberCancelledCampaigns();

            var report = new AdminCampaignReport(active, completed, cancelled);

            var response = request.CreateResponse(HttpStatusCode.OK, report);

            return response;
        }
    }
}