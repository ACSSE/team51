using System;
using Bursify.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Bursify.Api.Students;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Uow;

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

        //get a single campaign
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetCampaign")]
        public HttpResponseMessage GetCampaign(HttpRequestMessage request)
        {
            var campaign = _studentApi.GetSingleCampaign(5);

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
                CampaignId = campaign.CampaignId,
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

            var model = new CampaignViewModel();

            var campaignVm = model.SingleCampaignMap(newCampaign);

            _studentApi.SaveCampaign(campaignVm);

            var response = request.CreateResponse(HttpStatusCode.Created, campaignVm);

            return response;
        }
    }
}