using System.Collections.Generic;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.Entities.User;
using System.Linq;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignRepository : Repository<Campaign>
    {
        public CampaignRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Campaign> GetAllCampaigns()
        {
            return LoadAll();
        }


        public List<Campaign> GetActiveCampaigns()
        {
            return LoadAll().Where(x => x.Status == "Active").ToList();
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
    }
}