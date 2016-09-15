using System;
using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Campaign")]
    public class CampaignController : ApiController
    {
        private readonly StudentApi _studentApi;
        private readonly SponsorApi _sponsorApi;

        public CampaignController(StudentApi studentApi, SponsorApi sponsorApi)
        {
            _studentApi = studentApi;
            _sponsorApi = sponsorApi;
        }

        //get all campaigns
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllCampaigns")]
        public HttpResponseMessage GetAllCampaigns(HttpRequestMessage request) //Get all campaigns
        {
            var campaigns = _studentApi.GetAllCampaigns();

            var campaignVm = CampaignViewModel.MultipleCampaignsMap(campaigns);

            foreach (var model in campaignVm)
            {
                var student = _studentApi.GetStudent(model.StudentId);

                model.Name = student.Firstname;
                model.Surname = student.Surname;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        //get all campaigns for a user
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllCampaigns")]
        public HttpResponseMessage GetAllCampaigns(HttpRequestMessage request, int userId)
        {
            var campaigns = _studentApi.GetAllCampaigns(userId);

            var campaignVm = CampaignViewModel.MultipleCampaignsMap(campaigns);

            var student = _studentApi.GetStudent(userId);

            foreach (var model in campaignVm)
            {
                
                model.Name = student.Firstname;
                model.Surname = student.Surname;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        //get all campaigns meeting user's search criteria
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllCampaigns")]
        public HttpResponseMessage GetAllCampaigns(HttpRequestMessage request, string searchCriteria)
        {
            var campaigns = _studentApi.SearchCampaigns(searchCriteria);

            var campaignVm = CampaignViewModel.MultipleCampaignsMap(campaigns);

            foreach (var c in campaignVm)
            {
                var student = _studentApi.GetStudent(c.StudentId);
                c.Name = student.Firstname;
                c.Surname = student.Surname;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        //get a single campaign
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaign")]
        public HttpResponseMessage GetCampaign(HttpRequestMessage request, int campaignId)
        {
            var campaign = _studentApi.GetSingleCampaign(campaignId);

            var model = new CampaignViewModel(campaign);

            var student = _studentApi.GetStudent(campaign.StudentId);
            model.Name = student.Firstname;
            model.Surname = student.Surname;

            var campaignVm = model.SingleCampaignMap(campaign);

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        //get a single campaign for a user
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaign")]
        public HttpResponseMessage GetCampaign(HttpRequestMessage request, int campaignId, int userId)
        {
            var campaign = _studentApi.GetSingleCampaign(campaignId, userId);

            var model = new CampaignViewModel(campaign);

            var student = _studentApi.GetStudent(campaign.StudentId);
            model.Name = student.Firstname;
            model.Surname = student.Surname;

            model.SingleCampaignMap(campaign);

            var response = request.CreateResponse(HttpStatusCode.OK, model);

            return response;
        }

        // add a new campaign or update an already existing one
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveCampaign")]
        public HttpResponseMessage SaveCampaign(HttpRequestMessage request, CampaignViewModel campaign)
        {
            var newCampaign = campaign.ReverseMap();

            _studentApi.SaveCampaign(newCampaign);

            var campaignVm = new CampaignViewModel(newCampaign);

            var student = _studentApi.GetStudent(campaignVm.StudentId);

            campaignVm.Name = student.Firstname;
            campaignVm.Surname = student.Surname;

            var response = request.CreateResponse(HttpStatusCode.Created, campaignVm);

            return response;
        }
       
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaignAccount")]
        public HttpResponseMessage GetCampaignAccount(HttpRequestMessage request, int campaignId)
        {
            var account = _studentApi.GetCampaignAccount(campaignId);

            var accountVm = new AccountViewModel(account);

            var response = request.CreateResponse(HttpStatusCode.OK, accountVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveCampaignAccount")]
        public HttpResponseMessage SaveCampaignAccount(HttpRequestMessage request, AccountViewModel account)
        {
            var newAccount = account.ReverseMap();

            _studentApi.SaveCampaignAccount(newAccount);

            var response = request.CreateResponse(HttpStatusCode.Created, account);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("EndorseCampaign")]
        public HttpResponseMessage EndorseCampaign(HttpRequestMessage request,int userId, int campaignId)
        {
            var campaign = _studentApi.EndorseCampaign(userId, campaignId);

            var user = _studentApi.GetUserInfo(userId);

            if (user.UserType.Equals("Sponsor", StringComparison.OrdinalIgnoreCase))
            {
                var sponsor = _studentApi.GetSponsor(user.ID);

                sponsor.BursifyScore += 1;

                _sponsorApi.SaveSponsor(sponsor);
            }

            CampaignViewModel campaignVM = new CampaignViewModel();
            campaignVM.SingleCampaignMap(campaign);

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVM);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("IsEndorsed")]
        public HttpResponseMessage IsEndorsed(HttpRequestMessage request, int userId, int campaignId)
        {
            var success = _studentApi.IsEndorsed(userId, campaignId);
                   
            var response = request.CreateResponse(HttpStatusCode.OK, success);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetNumberCampaignsByStudent")]
        public HttpResponseMessage GetNumberCampaignsByStudent(HttpRequestMessage request, int Id)
        {
            int number = _studentApi.GetNumberOfCampaignsByID(Id);

            var response = request.CreateResponse(HttpStatusCode.OK, number);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetSimilarCampaigns")]
        public HttpResponseMessage GetSimilarCampaigns(HttpRequestMessage request, int campaignId)
        {
            var campaigns = _studentApi.GetSimilarCampaigns(campaignId);

            var campaignVm = CampaignViewModel.MultipleCampaignsMap(campaigns);

            foreach (var c in campaignVm)
            {
                var student = _studentApi.GetStudent(c.StudentId);
                c.Name = student.Firstname;
                c.Surname = student.Surname;
            }

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaignFunders")]
        public HttpResponseMessage GetCampaignFunders(HttpRequestMessage request, int campaignId)
        {
            var sponsorNames = _studentApi.GetCampaignFunders(campaignId);

            var response = request.CreateResponse(HttpStatusCode.OK, sponsorNames);

            return response;
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("DelCampaign")]
        public HttpResponseMessage DelCampaign(HttpRequestMessage request, int campaignId)
        {
            _studentApi.RemoveCampaign(campaignId);

            var response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}