using System.Collections.Generic;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.Entities.User;
using System.Linq;
using System;
using System.Data.Entity.SqlServer;
using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignRepository : Repository<Campaign>
    {
        private readonly DataSession _dataSession;

        public CampaignRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public List<Campaign> GetAllCampaigns()
        {
            var campaigns = _dataSession.UnitOfWork.Context.Set<Campaign>()
                .Where(campaign => campaign.Status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                .ToList();

            return campaigns;
        }

        public Campaign GetCampaign(int campaignId)
        {
            return FindSingle(campaign =>
                campaign.ID == campaignId);
        }

        public Campaign GetCampaign(int campaignId, int userId)
        {
            return FindSingle(id => 
                    id.ID == campaignId
                 && id.StudentId == userId);
        }

        public IEnumerable<Campaign> FindCampaigns(string criteria)
        {
            var filteredCampaigns = FindMany(campaign => 
                                  campaign.Location.ToUpper().Contains(criteria)
                               || campaign.Description.ToUpper().Contains(criteria)
                               || campaign.CampaignName.ToUpper().Contains(criteria)
                               || campaign.CampaignType.ToUpper().Contains(criteria)
                               || campaign.FundUsage.ToUpper().Contains(criteria)
                               || campaign.ReasonsToSupport.ToUpper().Contains(criteria));
           
            return filteredCampaigns;
        }

        public IEnumerable<Campaign> GetUserCampaigns(int userId)
        {
            var userCampaigns = FindMany(campaign =>
                                campaign.StudentId == userId);

            return userCampaigns;
        }

        public Campaign EndorseCampaign(BursifyUser user, int campaignId)
        {
                var campaign = user.Upvotes.FirstOrDefault(x => x.ID == campaignId);

                if (campaign == null)
                {
                    campaign = LoadById(campaignId);
                    user.Upvotes.Add(campaign);
                }

                return campaign;
        }

        public bool IsEndorsed(BursifyUser user, int campaignId)
        {
                var campaign = user.Upvotes.FirstOrDefault(x => x.ID == campaignId);

                if (campaign == null)
                {
                    return false;
                }
                return true;
         }

        public int GetCampaignNumbersByStatus(string status)
        {
            return FindMany(x => x.Status.ToUpper().Equals(status.ToUpper())).Count;
        }

        public List<Campaign> GetSimilarCampaigns(int campaignId)
        {
            var current = LoadById(campaignId);

            var campaigns = _dataSession.UnitOfWork.Context.Set<Campaign>()
                .Where(campaign => campaign.CampaignType.Equals(current.CampaignType) && campaign.ID != current.ID)
                .Take(3)
                .ToList();

            return campaigns;
        }

        public Dictionary<int?, double> GetFundingPerDay(int campaignId)
        {
            /*var applications = _dataSession.UnitOfWork.Context.Set<StudentSponsorship>()
                .Where(x => x.SponsorshipId == sponsorshipId)
                .GroupBy(x => SqlFunctions.DatePart("week", x.ApplicationDate))
                .ToDictionary(v => v.Key, v => v.Count());*/

            var dailyFunding = _dataSession.UnitOfWork.Context.Set<CampaignSponsor>()
                .Where(x => x.CampaignId == campaignId)
                .GroupBy(x => SqlFunctions.DatePart("day", x.DateOfContribution))
                .ToDictionary(v => v.Key, v => v.Sum(c => c.AmountContributed));

            return dailyFunding;
        }
    }
}