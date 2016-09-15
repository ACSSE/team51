using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
       [System.Web.Mvc.RoutePrefix("api/Sponsor")]
    public class SponsorController : ApiController
    {
        private readonly StudentApi _studentApi;
        private readonly SponsorApi _sponsorApi;

        public SponsorController(StudentApi studentApi, SponsorApi sponsorApi)
        {
            _studentApi = studentApi;
            _sponsorApi = sponsorApi;
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveSponsor")]
        public HttpResponseMessage SaveSponsor(HttpRequestMessage request, SponsorViewModel sponsor)
        {
            _sponsorApi.SaveSponsor(sponsor.ReverseMap());

            var response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllSponsors")]
        public HttpResponseMessage GetAllSponsors(HttpRequestMessage request)
        {
            var sponsors = _studentApi.GetAllSponsors();

            var sponsorVm = SponsorViewModel.MultipleSponsorsMap(sponsors);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetTopTenSponsors")]
        public HttpResponseMessage GetTopTenSponsors(HttpRequestMessage request)
        {
            var sponsors = _studentApi.GetTopTenSponsors();

            var sponsorVm = SponsorViewModel.MultipleSponsorsMap(sponsors);

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

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsorships")]
        public HttpResponseMessage GetSubjects(HttpRequestMessage request, int SponsorId)
        {
            var sponsoships = _sponsorApi.GetSponsorSponsorships(SponsorId);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsoships);

            return response;
        }
              
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudent")]
        public HttpResponseMessage GetStudent(HttpRequestMessage request, int Id)
        {
            var student = _studentApi.GetStudent(Id);

            StudentViewModel studentVM = new StudentViewModel();
            studentVM.MapSingleStudent(student);

            var response = request.CreateResponse(HttpStatusCode.OK, studentVM);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("OfferSponsorship")]
        public HttpResponseMessage OfferSponsorship(HttpRequestMessage request, int studentId, int sponsorshipId)
        {
            _sponsorApi.OfferSponsorship(studentId, sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudentsSponsored")]
        public HttpResponseMessage GetStudentsSponsored(HttpRequestMessage request, int sponsorshipId)
        {
            var students = _sponsorApi.GetStudentsSponsored(sponsorshipId);

            var s = StudentViewModel.MapMultipleStudents(students);
            
            var response = request.CreateResponse(HttpStatusCode.OK, s);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudentsApplying")]
        public HttpResponseMessage GetStudentsApplying(HttpRequestMessage request, int sponsorshipId)
        {
            var students = _sponsorApi.GetStudentsApplying(sponsorshipId);

            var s = StudentViewModel.MapMultipleStudents(students);

            var response = request.CreateResponse(HttpStatusCode.OK, s);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ApproveSponsorship")]
        public HttpResponseMessage ApproveSponsorship(HttpRequestMessage request, int studentId, int sponsorshipId)
        {
            bool status = _sponsorApi.ApproveSponsorship(studentId, sponsorshipId);

            var sponsorship = _studentApi.GetSponsorship(sponsorshipId);

            var sponsor = _sponsorApi.GetSponsor(sponsorship.SponsorId);

            sponsor.BursifyScore += 15;

            _sponsorApi.SaveSponsor(sponsor);

            HttpResponseMessage response = null;

            if (status)
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
            }
            else
            {
                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SponsorCampaign")]
        public HttpResponseMessage SponsorCampaign(HttpRequestMessage request,
            SponsorCampaignViewModel sponsorCampaignVM)
        {
            _sponsorApi.SponsorCampaign(sponsorCampaignVM.sponsorId, sponsorCampaignVM.Campaignid,
                sponsorCampaignVM.amount);

            var sponsor = _sponsorApi.GetSponsor(sponsorCampaignVM.sponsorId);

            sponsor.BursifyScore += Convert.ToInt32(sponsorCampaignVM.amount/100);

            _sponsorApi.SaveSponsor(sponsor);

            var response = request.CreateResponse(HttpStatusCode.OK, new {success = true});

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsoredCampaigns")]
        public HttpResponseMessage GetSponsoredCampaigns(HttpRequestMessage request,
            int sponsorId)
        {
            var campaigns = _sponsorApi.GetSupportedCampaigns(sponsorId);
            var campaignsVM = CampaignViewModel.MultipleCampaignsMap(campaigns);

            foreach (var c in campaignsVM)
            {
                var student = _studentApi.GetStudent(c.StudentId);
                c.Name = student.Firstname;
                c.Surname = student.Surname;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, campaignsVM);

            return response;
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ReportCampaign")]
        public HttpResponseMessage ReportCampaign(HttpRequestMessage request, ReportCampaignModel reportVM)
        {
            _sponsorApi.ReportCampaign(reportVM.userId, reportVM.camapignId, reportVM.reason);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}