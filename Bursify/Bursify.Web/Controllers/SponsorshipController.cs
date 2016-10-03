using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;
using Bursify.Web.Models;
using Bursify.Data.EF.Entities.SponsorUser;

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

            foreach (var sponsorship in sponsorshipVm)
            {
                sponsorship.ApplicantCount = _sponsorApi.GetStudentsApplying(sponsorship.ID).Count;
                sponsorship.SponsorPicturePath = _sponsorApi.GetUserInfo(sponsorship.SponsorId).ProfilePicturePath;
            }

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

            foreach(var sponsorship in sponsorshipVm)
            {
                sponsorship.ApplicantCount = _sponsorApi.GetStudentsApplying(sponsorship.ID).Count;
                sponsorship.SponsorPicturePath = _sponsorApi.GetUserInfo(sponsorship.SponsorId).ProfilePicturePath;
            }

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

            foreach (var sponsorship in sponsorshipVm)
            {
                sponsorship.ApplicantCount = _sponsorApi.GetStudentsApplying(sponsorship.ID).Count;
                sponsorship.SponsorPicturePath = _sponsorApi.GetUserInfo(sponsorship.SponsorId).ProfilePicturePath;
            }

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
        public HttpResponseMessage GetSponsorship(HttpRequestMessage request, int sponsorshipId)
        {
            var sponsorship = _studentApi.GetSponsorship(sponsorshipId);

            sponsorship.NumberOfViews += 1;
            _studentApi.SaveSponsorship(sponsorship);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(sponsorship);

            sponsorshipVm.ApplicantCount = _sponsorApi.GetStudentsApplying(sponsorshipVm.ID).Count;
            sponsorshipVm.SponsorPicturePath = _sponsorApi.GetUserInfo(sponsorshipVm.SponsorId).ProfilePicturePath;

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddRequirements")]
        public HttpResponseMessage AddRequirements(HttpRequestMessage request, List<RequirementViewModel> requirementsVM)
        {
            List<Requirement> requirements = new List<Requirement>();
            foreach (var r in requirementsVM)
            {
                requirements.Add(r.ReverseMap());
            }

            if (requirements.Count != 0)
            {
                _studentApi.AddRequirements(requirements);
            }

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsorship")]
        public HttpResponseMessage GetSponsorship(HttpRequestMessage request, int sponsorshipId, int userId)
        {
            var sponsorship = _studentApi.GetSponsorship(sponsorshipId, userId);

            var model = new SponsorshipViewModel();

            var sponsorshipVm = model.SingleSponsorshipMap(sponsorship);

            sponsorshipVm.ApplicantCount = _sponsorApi.GetStudentsApplying(sponsorshipVm.ID).Count;
            sponsorshipVm.SponsorPicturePath = _sponsorApi.GetUserInfo(sponsorshipVm.SponsorId).ProfilePicturePath;

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

            var sponsor = _sponsorApi.GetSponsor(newSponsorship.SponsorId);

            var points = newSponsorship.Rating*10;

            sponsor.BursifyScore += points;

            _sponsorApi.SaveSponsor(sponsor);

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
                                    _studentApi.GetInstitution(applicant.InstitutionID).Name,
                                    _studentApi.GetUserInfo(applicant.ID).ProfilePicturePath,
                                    applicant.Age,
                                    _studentApi.GetAddress(applicant.ID, "Residential").Province,
                                    applicant.EducationLevel,
                                    _studentApi.GetMostRecentReport(applicant.ID).Average,
                                    applicant.Gender)).ToList();

            var response = request.CreateResponse(HttpStatusCode.OK, new { count = data.Count, data });

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSimilar")]
        public HttpResponseMessage GetSimilar(HttpRequestMessage request, int sponsorshipId)
        {
            var sponsorships = _studentApi.GetSimilarSponsorships(sponsorshipId);

            var sponsorshipVm = SponsorshipViewModel.MultipleSponsorshipsMap(sponsorships);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorshipVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetApplicantsPerWeek")]
        public HttpResponseMessage GetApplicantsPerWeek(HttpRequestMessage request, int sponsorshipId)
        {
            var applicantions = _studentApi.GetSponsorApplicantsPerWeek(sponsorshipId);

            var data = WeekApplicant.MapApplicants(applicantions);

            var response = request.CreateResponse(HttpStatusCode.OK, new {count = data.Count, data});

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetMaleFemaleRatio")]
        public HttpResponseMessage GetMaleFemaleRatio(HttpRequestMessage request, int sponsorshipId)
        {
            var ratio = _studentApi.GetMaleFemaleRatio(sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK, ratio);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetApplicantsPerprovince")]
        public HttpResponseMessage GetApplicantsPerprovince(HttpRequestMessage request, int sponsorshipId)
        {
            var data = _studentApi.GetApplicantsPerprovince(sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK, new { count = data.Count, data});

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetApplicantOverallAverage")]
        public HttpResponseMessage GetApplicantOverallAverage(HttpRequestMessage request, int sponsorshipId)
        {
            var applicantAverage = Math.Round(_studentApi.GetApplicantOverallAverage(sponsorshipId), 2);
            
            var response = request.CreateResponse(HttpStatusCode.OK, new { average = applicantAverage });

            return response;
        }
    }
}
