using System.Collections.Generic;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Uow;

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

        //user method in membershipApi
        //public Campaign EndorseCampaign(int id)
        //{
        //    var campaignEndorsement = FindSingle(campaign => campaign.ID == id);

        //    campaignEndorsement.NumberOfUpVotes += 1;

        //    return campaignEndorsement;
        //}
    }
}