﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.SponsorUser;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Sponsorship")]
    public class SponsorshipController : ApiController
    {
        private readonly StudentApi _studentApi;

        public SponsorshipController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request)
        {
            var sponsorships = _studentApi.GetAllSponsorships();

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request, int userId)
        {
            var sponsorships = _studentApi.GetAllSponsorships(userId);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsorships")]
        public HttpResponseMessage GetAllSponsorships(HttpRequestMessage request, string type)
        {
            var sponsorships = _studentApi.GetAllSponsorships(type);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSearchSponsorships")]
        public HttpResponseMessage GetSearchSponsorships(HttpRequestMessage request, string criteria)
        {
            var sponsorships = _studentApi.SearchSponsorships(criteria);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.MultipleSponsorshipsMap(sponsorships);

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
            var newSponsorship = new Sponsorship()
            {
                ID = sponsorship.SponsorshipId,
                SponsorId = sponsorship.SponsorId,
                Name = sponsorship.Name,
                Description = sponsorship.Description,
                ClosingDate = sponsorship.ClosingDate,
                EssayRequired = sponsorship.EssayRequired,
                SponsorshipValue = sponsorship.SponsorshipValue,
                StudyFields = sponsorship.StudyFields,
                Province = sponsorship.Province,
                AverageMarkRequired = sponsorship.AverageMarkRequired,
                EducationLevel = sponsorship.EducationLevel,
                PreferredInstitutions = sponsorship.PreferredInstitutions,
                ExpensesCovered = sponsorship.ExpensesCovered,
                TermsAndConditions = sponsorship.TermsAndConditions
            };

            _studentApi.SaveSponsorship(newSponsorship);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(newSponsorship);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }
    }
}