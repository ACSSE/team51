using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Bursify.Api.Students;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Sponsor")]
    public class SponsorController : ApiController
    {
        private readonly StudentApi _studentApi;

        public SponsorController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsors")]
        public HttpResponseMessage GetAllSponsors(HttpRequestMessage request)
        {
            var sponsors = _studentApi.GetAllSponsors();

            var model = new SponsorViewModel();

            var sponsorVm = model.MultipleSponsorsMap(sponsors);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetTopTenSponsors")]
        public HttpResponseMessage GetTopTenSponsors(HttpRequestMessage request)
        {
            var sponsors = _studentApi.GetTopTenSponsors();

            var model = new SponsorViewModel();

            var sponsorVm = model.MultipleSponsorsMap(sponsors);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsor")]
        public HttpResponseMessage GetSponsor(HttpRequestMessage request, int userId)
        {
            var sponsor = _studentApi.GetSponsor(userId);

            var model = new SponsorViewModel();

            var sponsorVm = model.SingleSponsorMap(sponsor);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorVm);

            return response;
        }
    }
}