using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Web.Models;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Sponsor")]
    public class SponsorController : ApiController
    {
        private readonly StudentApi _studentApi;
        private SponsorApi sponsorApi;

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

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddSponsorship")]
        public HttpResponseMessage AddSponsorship(HttpRequestMessage request, SponsorshipViewModel sponsorshipVM, List<SponsorshipRequirement> requirementsVM)
        {
            var sponsorship = new Sponsorship
            {
                Name = sponsorshipVM.Name,
                EducationLevel = sponsorshipVM.EducationLevel,
                ClosingDate = sponsorshipVM.ClosingDate,
                SponsorshipValue = sponsorshipVM.SponsorshipValue,
                AverageMarkRequired = sponsorshipVM.AverageMarkRequired,
                Description = sponsorshipVM.Description,
                EssayRequired = sponsorshipVM.EssayRequired,
                ExpensesCovered = sponsorshipVM.ExpensesCovered,
                PreferredInstitutions = sponsorshipVM.PreferredInstitutions,
                Province = sponsorshipVM.Province,
                SponsorId = sponsorshipVM.SponsorId,
                SponsorshipType = sponsorshipVM.SponsorshipType,
                StudyFields = sponsorshipVM.StudyFields,
                TermsAndConditions = sponsorshipVM.TermsAndConditions
            };

            sponsorApi.AddSponsorship(sponsorship);

            List<SponsorshipRequirement> requirements = new List<SponsorshipRequirement>();

            foreach (var r in requirementsVM)
            {
                requirements.Add(new SponsorshipRequirement
                {
                    SubjectId = r.SubjectId,
                    RequiredMark = r.RequiredMark,
                    SponsorshipId = r.SubjectId,
                });
            }

            if (requirements.Count != 0)
            {
                sponsorApi.AddRequirements(requirements);
            }
            
            var response = request.CreateResponse(HttpStatusCode.OK, sponsorship);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("AddRequirements")]
        public HttpResponseMessage AddRequirements(HttpRequestMessage request, List<SponsorshipRequirement> requirementsVM)
        {
            List<SponsorshipRequirement> requirements = new List<SponsorshipRequirement>();
            foreach (var r in requirementsVM)
            {
                requirements.Add(new SponsorshipRequirement
                {
                    SubjectId = r.SubjectId,
                    RequiredMark = r.RequiredMark,
                    SponsorshipId = r.SubjectId,
                });
            }

            if (requirements.Count != 0)
            {
                sponsorApi.AddRequirements(requirements);
            }

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudent")]
        public HttpResponseMessage GetStudent(HttpRequestMessage request, int Id)
        {
            var student = sponsorApi.GetStudent(Id);

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
            sponsorApi.OfferSponsorship(studentId, sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudentSponsored")]
        public HttpResponseMessage GetStudentsSponsored(HttpRequestMessage request, int sponsorshipId)
        {
            var students = sponsorApi.GetStudentsSponsored(sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK, students);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetStudentApplying")]
        public HttpResponseMessage GetStudentsApplying(HttpRequestMessage request, int sponsorshipId)
        {
            var students = sponsorApi.GetStudentsApplying(sponsorshipId);

            var response = request.CreateResponse(HttpStatusCode.OK, students);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ApproveSponsorship")]
        public HttpResponseMessage ApproveSponsorship(HttpRequestMessage request, ApproveSponsorshipViewModel approveVm)
        {
            bool status = sponsorApi.ApproveSponsorship(approveVm.studentId, approveVm.campaignId, approveVm.confirmation);

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
            sponsorApi.SponsorCampaign(sponsorCampaignVM.sponsorId, sponsorCampaignVM.Campaignid,
                sponsorCampaignVM.amount);

            var response = request.CreateResponse(HttpStatusCode.OK, new {success = true});

            return response;
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSponsoredCampaigns")]
        public HttpResponseMessage GetSponsoredCampaigns(HttpRequestMessage request,
            int sponsorId)
        {
            var campaigns = sponsorApi.GetSupportedCampaigns(sponsorId);

            var response = request.CreateResponse(HttpStatusCode.OK, campaigns);

            return response;
        }


        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("ReportCampaign")]
        public HttpResponseMessage ReportCampaign(HttpRequestMessage request, ReportCampaignModel reportVM)
        {
            sponsorApi.ReportCampaign(reportVM.userId, reportVM.camapignId, reportVM.reason);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}