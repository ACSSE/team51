using Bursify.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bursify.Api.Students;
using Bursify.Data.EF.CampaignUser;

namespace Bursify.Web.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/Campaign")]
    public class CampaignController : ApiController
    {
        private readonly StudentApi _studentApi;

        public CampaignController(StudentApi studentApi)
        {
            _studentApi = studentApi;
        }
        
        //get all campaigns
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetAllCampaigns")]
        public HttpResponseMessage GetAllCampaigns(HttpRequestMessage request) //Get all campaigns
        {
            var campaigns = _studentApi.GetAllCampaigns();

            var model = new CampaignViewModel();

            var campaignVm = model.MultipleCampaignsMap(campaigns);
            
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

            var model = new CampaignViewModel();

            var campaignVm = model.MultipleCampaignsMap(campaigns);

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

            var model = new CampaignViewModel();

            var campaignVm = model.MultipleCampaignsMap(campaigns);

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

            var model = new CampaignViewModel();

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

            var model = new CampaignViewModel();

            var campaignVm = model.SingleCampaignMap(campaign);

            var response = request.CreateResponse(HttpStatusCode.OK, campaignVm);

            return response;
        }

        // add a new campaign or update an already existing one
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SaveCampaign")]
        public HttpResponseMessage SaveCampaign(HttpRequestMessage request, CampaignViewModel campaign)
        {
            var newCampaign = new Campaign
            {
                ID = campaign.CampaignId,
                StudentId = campaign.StudentId,
                CampaignName = campaign.CampaignName,
                Tagline = campaign.Tagline,
                Location = campaign.Location,
                Description = campaign.Description,
                AmountRequired = campaign.AmountRequired,
                CampaignType = campaign.CampaignType,
                VideoPath = campaign.VideoPath,
                PicturePath = campaign.PicturePath,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                AmountContributed = campaign.AmountContributed,
                FundUsage = campaign.FundUsage,
                ReasonsToSupport = campaign.ReasonsToSupport
            };

            _studentApi.SaveCampaign(newCampaign);

            var model = new CampaignViewModel();

            var campaignVm = model.SingleCampaignMap(newCampaign);

            var response = request.CreateResponse(HttpStatusCode.Created, campaignVm);

            return response;
        }

        //later and thinking
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("SponsorCampaign")]
        public HttpResponseMessage SponsorCampaign(HttpRequestMessage request)
        {
            return null;
        }
    }
}