using AutoMapper;
using Bursify.Data.Repositories;
using Bursify.Data.UoW;
using Bursify.Entities;
using Bursify.Entities.CampaignEntities;
using Bursify.Web.Infrastructure.Core;
using Bursify.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Bursify.Web.Controllers
{
    [RoutePrefix("api/campaigns")]
    public class CampaignController : ApiControllerBase
    {

        private readonly IEntityBaseRepository<Campaign> _CampaignRepository;

        public CampaignController(IEntityBaseRepository<Campaign> CampaignRepository,
          IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _CampaignRepository = CampaignRepository;
        }

        [AllowAnonymous]
        [Route("viewCampaigns")]
        public HttpResponseMessage Get(HttpRequestMessage request) //Get all campaigns
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var campaings = _CampaignRepository.GetAll().OrderByDescending(c => c.StartDate).Take(6).ToList();

                IEnumerable<CampaignViewModel> campaingsVM = Mapper.Map<IEnumerable<Campaign>, IEnumerable<CampaignViewModel>>(campaings);

                response = request.CreateResponse<IEnumerable<CampaignViewModel>>(HttpStatusCode.OK, campaingsVM);

                return response;
            });
        }

        //Post a campaign
        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CampaignViewModel campaign)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                Campaign newCampaign = new Campaign();

                _CampaignRepository.Add(newCampaign);
                _unitOfWork.Commit();

                // Update view model
                campaign = Mapper.Map<Campaign, CampaignViewModel>(newCampaign);
                response = request.CreateResponse<CampaignViewModel>(HttpStatusCode.Created, campaign);
                return response;
            });
        }



    }
}