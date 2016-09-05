using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;
using Bursify.Web.Models;
using Bursify.Web.Utility.ModelClasses;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Sponsorship")]
    public class SponsorshipController : ApiController
    {
        private readonly StudentApi _studentApi;
        private readonly SponsorApi _sponsorApi;

        public SponsorshipController(StudentApi studentApi, SponsorApi sponsorApi)
        {
            _studentApi = studentApi;
            _sponsorApi = sponsorApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request)
        {
            var sponsorships = _studentApi.GetAllSponsorships();

            var sponsorshipVm = SponsorshipViewModel.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request, int userId)
        {
            var sponsorships = _studentApi.GetAllSponsorships(userId);

            var sponsorshipVm = SponsorshipViewModel.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request, string type)
        {
            var sponsorships = _studentApi.GetAllSponsorships(type);

            var sponsorshipVm = SponsorshipViewModel.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSearchSponsorships")]
        public HttpResponseMessage GetSearchSponsorships(HttpRequestMessage request, string criteria)
        {
            var sponsorships = _studentApi.SearchSponsorships(criteria);

            var sponsorshipVm = SponsorshipViewModel.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsorship")]
        public HttpResponseMessage GetSponsorships(HttpRequestMessage request, int sponsorshipId)
        {
            var sponsorship = _studentApi.GetSponsorship(sponsorshipId);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(sponsorship);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsorship")]
        public HttpResponseMessage GetSponsorships(HttpRequestMessage request, int sponsorshipId, int userId)
        {
            var sponsorship = _studentApi.GetSponsorship(sponsorshipId, userId);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(sponsorship);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveSponsorship")]
        public HttpResponseMessage SaveSponsorship(HttpRequestMessage request, SponsorshipViewModel sponsorship)
        {
            var newSponsorship = sponsorship.ReverseMap();

            _studentApi.SaveSponsorship(newSponsorship);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(newSponsorship);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetApplicants")]
        public HttpResponseMessage GetApplicants(HttpRequestMessage request, int sponsorshipId)
        {
            var students = _sponsorApi.GetStudentsApplying(sponsorshipId);

            var data = students.Select(applicant => 
                                    new Applicant(applicant.ID, applicant.Firstname, 
                                    applicant.Surname,
                                    _studentApi.GetUserInfo(applicant.ID).ProfilePicturePath, 
                                    applicant.Age, 
                                    _studentApi.GetAddress(applicant.ID, "Residential").Province, 
                                    applicant.EducationLevel, 
                                    _studentApi.GetMostRecentReport(applicant.ID).Average, 
                                    applicant.Gender)).ToList();
          
            var response = request.CreateResponse(HttpStatusCode.OK, new { count = data.Count, data });

            return response;
        }
    }
}
